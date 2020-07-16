using Newtonsoft.Json.UnityConverters.Configuration;
using UnityEditor;
using UnityEngine;

namespace Newtonsoft.Json.UnityConverters.Editor
{
    public static class UnityConvertersConfigMenu
    {

        [MenuItem("Edit/Json.NET converters settings...", false, 250)]
        public static void OpenOrCreateConfig()
        {
            var config = GetOrCreateConfig();

            EditorUtility.FocusProjectWindow();
            EditorWindow inspectorWindow = EditorWindow.GetWindow(typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow"));
            inspectorWindow.Focus();

            Selection.activeObject = config;
        }

        private static UnityConvertersConfig GetOrCreateConfig()
        {
            var config = Resources.Load<UnityConvertersConfig>(UnityConvertersConfig.PATH);

            if (config)
            {
                return config;
            }

            config = ScriptableObject.CreateInstance<UnityConvertersConfig>();

            AssetDatabase.CreateAsset(config, UnityConvertersConfig.PATH);
            AssetDatabase.SaveAssets();

            return config;
        }
    }
}
