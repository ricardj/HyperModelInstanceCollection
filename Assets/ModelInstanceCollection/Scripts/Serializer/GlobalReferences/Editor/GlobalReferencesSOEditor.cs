using UnityEditor;
using UnityEngine;

namespace ModelInstanceCollection
{
    [CustomEditor(typeof(GlobalReferencesSO))]
    public class GlobalReferencesSOEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Fetch all serializable objects"))
            {
                FetchAllSerializableObjects();
                GlobalReferencesSO.get.RefreshList();
            }
        }

        private static void FetchAllSerializableObjects()
        {
            string[] targetFiles = AssetDatabase.FindAssets("t:SerializableScriptableObject");
            foreach (string item in targetFiles)
            {

                string path = AssetDatabase.GUIDToAssetPath(item);
                SerializableScriptableObject newSerializableScriptable = AssetDatabase.LoadAssetAtPath<SerializableScriptableObject>(path);
                GlobalReferencesSO.get.AddScriptable(newSerializableScriptable);

            }
        }
    }
}