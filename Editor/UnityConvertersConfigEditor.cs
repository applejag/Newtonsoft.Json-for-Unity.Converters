using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.UnityConverters.Configuration;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;
// Unity 2020 also has a type cache: UnityEditor.TypeCache:
// https://docs.unity3d.com/2019.2/Documentation/ScriptReference/TypeCache.html
using TypeCache = Newtonsoft.Json.UnityConverters.Utility.TypeCache;

namespace Newtonsoft.Json.UnityConverters.Editor
{
    using Editor = UnityEditor.Editor;

    [CustomEditor(typeof(UnityConvertersConfig))]
    public class UnityConvertersConfigEditor : Editor
    {
        private SerializedProperty _useUnityContractResolver;
        private SerializedProperty _useAllOutsideConverters;
        private SerializedProperty _outsideConverters;
        private SerializedProperty _useAllUnityConverters;
        private SerializedProperty _unityConverters;
        private SerializedProperty _useAllJsonNetConverters;
        private SerializedProperty _jsonNetConverters;
        private SerializedProperty _autoSyncConverters;

        private AnimBool _outsideConvertersShow;
        private AnimBool _unityConvertersShow;
        private AnimBool _jsonNetConvertersShow;
        private AnimBool _autoSyncConvertersShow;

        private bool _isDirty;

        private static class Styles
        {
            public static GUIStyle headerStyle;
            public static GUIStyle boldHeaderStyle;

            static Styles()
            {
                headerStyle = new GUIStyle { fontSize = 20, wordWrap = true, normal = EditorStyles.label.normal };
                boldHeaderStyle = new GUIStyle { fontSize = 20, fontStyle = FontStyle.Bold, wordWrap = true, normal = EditorStyles.label.normal };
            }
        }

        private void OnEnable()
        {
            var config = (UnityConvertersConfig)target;
            var grouped = UnityConverterInitializer.FindGroupedConverters(config);

            // Hack around the "SerializedObjectNotCreatableException: Object at index 0 is null"
            // error message
            try
            {
                _ = serializedObject;
            }
            catch (Exception)
            {
                return;
            }

            _useUnityContractResolver = serializedObject.FindProperty(nameof(UnityConvertersConfig.useUnityContractResolver));
            _useAllOutsideConverters = serializedObject.FindProperty(nameof(UnityConvertersConfig.useAllOutsideConverters));
            _outsideConverters = serializedObject.FindProperty(nameof(UnityConvertersConfig.outsideConverters));
            _useAllUnityConverters = serializedObject.FindProperty(nameof(UnityConvertersConfig.useAllUnityConverters));
            _unityConverters = serializedObject.FindProperty(nameof(UnityConvertersConfig.unityConverters));
            _useAllJsonNetConverters = serializedObject.FindProperty(nameof(UnityConvertersConfig.useAllJsonNetConverters));
            _jsonNetConverters = serializedObject.FindProperty(nameof(UnityConvertersConfig.jsonNetConverters));
            _autoSyncConverters = serializedObject.FindProperty(nameof(UnityConvertersConfig.autoSyncConverters));

            _outsideConvertersShow = new AnimBool(_outsideConverters.isExpanded);
            _unityConvertersShow = new AnimBool(_unityConverters.isExpanded);
            _jsonNetConvertersShow = new AnimBool(_jsonNetConverters.isExpanded);
            _autoSyncConvertersShow = new AnimBool(!_autoSyncConverters.boolValue);

            _outsideConvertersShow.valueChanged.AddListener(Repaint);
            _unityConvertersShow.valueChanged.AddListener(Repaint);
            _jsonNetConvertersShow.valueChanged.AddListener(Repaint);

            serializedObject.Update();
            AddAndSetupConverters(_outsideConverters, grouped.outsideConverters, _useAllOutsideConverters.boolValue);
            AddAndSetupConverters(_unityConverters, grouped.unityConverters, _useAllUnityConverters.boolValue);
            AddAndSetupConverters(_jsonNetConverters, grouped.jsonNetConverters, _useAllJsonNetConverters.boolValue);

            serializedObject.ApplyModifiedProperties();
        }

        public override void OnInspectorGUI()
        {
            _isDirty = false;
            EditorGUILayout.LabelField("Settings for the converters of", Styles.headerStyle);
            EditorGUILayout.LabelField("Newtonsoft.Json-for-Unity.Converters", Styles.boldHeaderStyle);

            serializedObject.Update();

            EditorGUILayout.Space();

            ToggleLeft(_useUnityContractResolver, "Custom 'Newtonsoft.Json.Serialization.IContractResolver' defined to" +
                " properly handle the 'UnityEngine.SerializeFieldAttribute' attribute and correctly creates" +
                " 'UnityEngine.ScriptableObject' via 'ScriptableObject.Create()' instead of the default" +
                " 'new ScriptableObject()'.");

            EditorGUILayout.Space();

            FoldedConverters(_useAllOutsideConverters, _outsideConverters, _outsideConvertersShow,
                "Registers all classes outside of the 'Newtonsoft.Json.*' namespace" +
                " that derive from 'Newtonsoft.Json.JsonConverter' that has a default constructor.");

            EditorGUILayout.Space();

            FoldedConverters(_useAllUnityConverters, _unityConverters, _unityConvertersShow,
                "Registers all classes inside of the 'Newtonsoft.Json.UnityConverters.*' namespace.");

            EditorGUILayout.Space();

            FoldedConverters(_useAllJsonNetConverters, _jsonNetConverters, _jsonNetConvertersShow,
                "Registers all classes inside of the 'Newtonsoft.Json.UnityConverters.*' namespace.");

            EditorGUILayout.Space();

            ToggleLeft(_autoSyncConverters,
                "Automatic synchronization of JsonConverter types is enabled by default," +
                " but can induce a heavy spike on each assembly reload (such as when entering play mode) on bigger projects.");
            _autoSyncConvertersShow.target = !_autoSyncConverters.boolValue;
            if (EditorGUILayout.BeginFadeGroup(_autoSyncConvertersShow.faded))
            {
                EditorGUILayout.HelpBox("The Newtonsoft.Json-for-Unity.Converters package will no longer automatically" +
                    " look for new JsonConverters.\n\n" +
                    "Having this automatic scan disabled reduces the load spike caused on larger projects every time you enter play mode," +
                    " but you must instead remember to press the sync button below every time you add a new JsonConverter.",
                    MessageType.Warning);
                if (GUILayout.Button("Manual Converter Sync Now"))
                {
                    var grouped = ConverterGrouping.Create(UnityConverterInitializer.FindConverters());
                    AddAndSetupConverters(_outsideConverters, grouped.outsideConverters, _useAllOutsideConverters.boolValue);
                    AddAndSetupConverters(_unityConverters, grouped.unityConverters, _useAllUnityConverters.boolValue);
                    AddAndSetupConverters(_jsonNetConverters, grouped.jsonNetConverters, _useAllJsonNetConverters.boolValue);
                }
            }
            EditorGUILayout.EndFadeGroup();

            serializedObject.ApplyModifiedProperties();

            if (_isDirty)
            {
                UnityConverterInitializer.RefreshSettingsFromConfig();
            }
        }

        private void AddAndSetupConverters(SerializedProperty arrayProperty, IList<Type> converterTypes, bool newAreEnabledByDefault)
        {
            var elements = EnumerateArrayElements(arrayProperty).ToArray();
            var elementTypes = elements
                .Select(e => TypeCache.FindType(
                    name: e.FindPropertyRelative(nameof(ConverterConfig.converterName)).stringValue,
                    assemblyName: e.FindPropertyRelative(nameof(ConverterConfig.converterAssembly)).stringValue
                ))
                .ToArray();

            // Refresh missing fields on existing types
            for (int i = 0; i < elements.Length; i++)
            {
                SerializedProperty elem = elements[i];
                Type type = elementTypes[i];

                var assemblyNameProp = elem.FindPropertyRelative(nameof(ConverterConfig.converterAssembly));
                if (string.IsNullOrEmpty(assemblyNameProp.stringValue))
                {
                    assemblyNameProp.stringValue = type.Assembly.GetName().Name;
                }
            }

            Type[] missingConverters = converterTypes
                .Where(type => !elementTypes.Contains(type))
                .ToArray();

            // Cleanup excess types
            for (int i = elementTypes.Length - 1; i >= 0; i--)
            {
                if (converterTypes.Contains(elementTypes[i]))
                {
                    continue;
                }
                string typeName = arrayProperty.GetArrayElementAtIndex(i).FindPropertyRelative(nameof(ConverterConfig.converterName)).stringValue;
                Debug.Log($"Removed type from JsonConverter list: \"{typeName}\"", target);
                arrayProperty.DeleteArrayElementAtIndex(i);
            }

            foreach (Type converterType in missingConverters)
            {
                int nextIndex = arrayProperty.arraySize;
                arrayProperty.InsertArrayElementAtIndex(nextIndex);

                SerializedProperty elemProp = arrayProperty.GetArrayElementAtIndex(nextIndex);
                SerializedProperty enabledProp = elemProp.FindPropertyRelative(nameof(ConverterConfig.enabled));
                SerializedProperty converterNameProp = elemProp.FindPropertyRelative(nameof(ConverterConfig.converterName));
                SerializedProperty assemblyNameProp = elemProp.FindPropertyRelative(nameof(ConverterConfig.converterAssembly));

                enabledProp.boolValue = newAreEnabledByDefault;
                converterNameProp.stringValue = converterType.FullName;
                assemblyNameProp.stringValue = converterType.Assembly.GetName().Name;
            }
        }

        private static IEnumerable<SerializedProperty> EnumerateArrayElements(SerializedProperty arrayProperty)
        {
            for (int i = 0; i < arrayProperty.arraySize; i++)
            {
                yield return arrayProperty.GetArrayElementAtIndex(i);
            }
        }

        private void FoldedConverters(
            SerializedProperty useAllBoolProperty,
            SerializedProperty convertersArrayProperty,
            AnimBool foldoutAnim,
            string tooltip)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            ToggleLeft(useAllBoolProperty, tooltip);

            EditorGUI.BeginDisabledGroup(useAllBoolProperty.boolValue || convertersArrayProperty.arraySize == 0);
            FoldoutConvertersList(convertersArrayProperty, foldoutAnim);
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();
        }

        private static void ToggleLeft(SerializedProperty property, string tooltip)
        {
            var content = new GUIContent {
                text = property.displayName,
                tooltip = tooltip,
            };

            property.boolValue = EditorGUILayout.ToggleLeft(content, property.boolValue);
        }

        private void FoldoutConvertersList(SerializedProperty property, AnimBool fadedAnim)
        {
            string displayName = $"{property.displayName} ({(property.arraySize == 0 ? "none found" : property.arraySize.ToString())})";

            EditorGUI.indentLevel++;
            property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, displayName, true);
            EditorGUI.indentLevel--;
            fadedAnim.target = property.isExpanded;

            if (EditorGUILayout.BeginFadeGroup(fadedAnim.faded))
            {
                EditorGUI.indentLevel++;

                var allConfigsWithType = EnumerateArrayElements(property)
                    .Select(o => (
                        serializedProperty: o,
                        type: TypeCache.FindType(
                            name: o.FindPropertyRelative(nameof(ConverterConfig.converterName)).stringValue,
                            assemblyName: o.FindPropertyRelative(nameof(ConverterConfig.converterAssembly)).stringValue
                        )
                    ))
                    .Where(o => o.type != null)
                    .OrderBy(o => o.type.FullName);

                foreach (var namespaceGroup in allConfigsWithType.GroupBy(o => GetTypeNamespace(o.type)))
                {
                    var groupLabel = new GUIContent {
                        tooltip = GetNamespaceTooltip(namespaceGroup),
                        text = GetNamespaceHeader(namespaceGroup),
                    };
                    EditorGUILayout.LabelField(groupLabel, EditorStyles.boldLabel);

                    EditorGUI.indentLevel++;
                    foreach (var configWithType in namespaceGroup.OrderBy(o => o.type?.Name))
                    {
                        SerializedProperty enabledProp = configWithType.serializedProperty.FindPropertyRelative(nameof(ConverterConfig.enabled));
                        if (configWithType.type != null)
                        {
                            var toggleContent = new GUIContent {
                                text = configWithType.type.Name,
                                tooltip = configWithType.type.AssemblyQualifiedName,
                            };

                            bool oldValue = enabledProp.boolValue;
                            enabledProp.boolValue = EditorGUILayout.ToggleLeft(toggleContent, enabledProp.boolValue);

                            if (oldValue != enabledProp.boolValue)
                            {
                                _isDirty = true;
                            }
                        }
                        else
                        {
                            if (enabledProp.boolValue)
                            {
                                enabledProp.boolValue = false;
                            }

                            SerializedProperty converterNameProp = configWithType.serializedProperty.FindPropertyRelative(nameof(ConverterConfig.converterName));
                            EditorGUI.BeginDisabledGroup(true);
                            EditorGUILayout.ToggleLeft($"Unknown type: {converterNameProp.stringValue}", false);
                            EditorGUI.EndDisabledGroup();
                        }
                    }
                    EditorGUI.indentLevel--;
                    EditorGUILayout.Space();
                }

                EditorGUI.indentLevel--;
            }

            EditorGUILayout.EndFadeGroup();
        }


        private static string GetNamespaceHeader(IGrouping<string, (SerializedProperty serializedProperty, Type type)> namespaceGroup)
        {
            return $"{namespaceGroup.Key ?? "<Misconfigured converters>"} ({namespaceGroup.Count()})";
        }

        private static string GetNamespaceTooltip(IGrouping<string, (SerializedProperty serializedProperty, Type type)> namespaceGroup)
        {
            switch (namespaceGroup.Key)
            {
            case "global::":
                return "Converters found with a default constructor from the global namespace.";

            case null:
                return "Converters that was found in the configuration but was" +
                   " unable to map them to existing types. Maybe the type got renamed, or moved to a different" +
                   " namespace?";

            default:
                return $"Converters found with a default constructor from the namespace '{namespaceGroup.Key}'.";
            }
        }

        private static string GetTypeNamespace(Type type)
        {
            return type is null ? null : (type.Namespace ?? "global::");
        }
    }
}
