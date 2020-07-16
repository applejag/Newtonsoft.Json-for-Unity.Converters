using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.UnityConverters.Configuration;
using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

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

        private IList<Type> _outsideConverterTypes;
        private IList<Type> _unityConverterTypes;
        private IList<Type> _jsonNetConverterTypes;
                
        private AnimBool _outsideConvertersShow;
        private AnimBool _unityConvertersShow;
        private AnimBool _jsonNetConvertersShow;

        private readonly Dictionary<string, Type> _converterTypeByName
            = new Dictionary<string, Type>();

        private GUIStyle _headerStyle;
        private GUIStyle _boldHeaderStyle;

        private bool _isDirty;

        private void OnEnable()
        {
            _outsideConverterTypes = UnityConverterInitializer.FindCustomConverters().ToArray();
            _unityConverterTypes = UnityConverterInitializer.FindUnityConverters().ToArray();
            _jsonNetConverterTypes = UnityConverterInitializer.FindJsonNetConverters().ToArray();

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

            _outsideConvertersShow = new AnimBool(_outsideConverters.isExpanded);
            _unityConvertersShow = new AnimBool(_unityConverters.isExpanded);
            _jsonNetConvertersShow = new AnimBool(_jsonNetConverters.isExpanded);

            _outsideConvertersShow.valueChanged.AddListener(Repaint);
            _unityConvertersShow.valueChanged.AddListener(Repaint);
            _jsonNetConvertersShow.valueChanged.AddListener(Repaint);
            _headerStyle = new GUIStyle { fontSize = 20, wordWrap = true };
            _boldHeaderStyle = new GUIStyle { fontSize = 20, fontStyle = FontStyle.Bold, wordWrap = true };

            serializedObject.Update();
            AddAndSetupConverters(_outsideConverters, _outsideConverterTypes, _useAllOutsideConverters.boolValue);
            AddAndSetupConverters(_unityConverters, _unityConverterTypes, _useAllUnityConverters.boolValue);
            AddAndSetupConverters(_jsonNetConverters, _jsonNetConverterTypes, _useAllJsonNetConverters.boolValue);
            serializedObject.ApplyModifiedProperties();
        }

        public override void OnInspectorGUI()
        {
            _isDirty = false;
            EditorGUILayout.LabelField("Settings for the converters of", _headerStyle);
            EditorGUILayout.LabelField("Newtonsoft.Json-for-Unity.Converters", _boldHeaderStyle);

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

            serializedObject.ApplyModifiedProperties();

            if (_isDirty)
            {
                UnityConverterInitializer.RefreshSettingsFromConfig();
            }
        }

        private void AddAndSetupConverters(SerializedProperty arrayProperty, IList<Type> converterTypes, bool newAreEnabledByDefault)
        {
            var converterTypesByName = converterTypes.ToDictionary(o => o.AssemblyQualifiedName);

            AddMissingConverters(arrayProperty, converterTypesByName.Keys, newAreEnabledByDefault);
            SetupConvertersIntoDictionary(arrayProperty, converterTypesByName);
        }

        private static void AddMissingConverters(SerializedProperty arrayProperty, IEnumerable<string> converterNames, bool newAreEnabledByDefault)
        {
            var elements = EnumerateArrayElements(arrayProperty);

            string[] missingConverters = converterNames
                .Where(name => elements.All(e => e.FindPropertyRelative(nameof(ConverterConfig.converterName)).stringValue != name))
                .ToArray();

            foreach (string converterName in missingConverters)
            {
                int nextIndex = arrayProperty.arraySize;
                arrayProperty.InsertArrayElementAtIndex(nextIndex);
                SerializedProperty elemProp = arrayProperty.GetArrayElementAtIndex(nextIndex);

                SerializedProperty enabledProp = elemProp.FindPropertyRelative(nameof(ConverterConfig.enabled));
                SerializedProperty converterNameProp = elemProp.FindPropertyRelative(nameof(ConverterConfig.converterName));

                enabledProp.boolValue = newAreEnabledByDefault;
                converterNameProp.stringValue = converterName;
            }
        }

        private void SetupConvertersIntoDictionary(SerializedProperty arrayProperty, Dictionary<string, Type> typesByName)
        {
            foreach (var elemProp in EnumerateArrayElements(arrayProperty))
            {
                var converterNameProp = elemProp.FindPropertyRelative(nameof(ConverterConfig.converterName));

                if (typesByName.TryGetValue(converterNameProp.stringValue, out Type type))
                {
                    _converterTypeByName[converterNameProp.stringValue] = type;
                }
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
                    .Select(o => _converterTypeByName.TryGetValue(o.FindPropertyRelative(nameof(ConverterConfig.converterName)).stringValue, out var type)
                        ? (serializedProperty: o, type)
                        : (o, null));

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
                            EditorGUILayout.ToggleLeft($"Unkown type: {converterNameProp.stringValue}", false);
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
