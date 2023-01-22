using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GlobalReferencesSO))]
public class GlobalReferencesSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Fetch all serializable objects"))
        {
            FetchAllSerializableObjects();
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