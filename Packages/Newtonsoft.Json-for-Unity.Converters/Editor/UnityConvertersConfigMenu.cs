using System.IO;
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
            var config = Resources.Load<UnityConvertersConfig>(UnityConvertersConfig.PATH_FOR_RESOURCES_LOAD);

            if (config)
            {
                return config;
            }

            config = ScriptableObject.CreateInstance<UnityConvertersConfig>();

            string directory = Path.GetDirectoryName(UnityConvertersConfig.PATH);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            AssetDatabase.CreateAsset(config, UnityConvertersConfig.PATH);
            AssetDatabase.SaveAssets();

            return config;
        }
    }
}
