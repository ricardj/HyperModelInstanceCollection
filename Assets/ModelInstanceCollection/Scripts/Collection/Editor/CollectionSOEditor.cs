using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(ITypelessCollectionSO))]
public class CollectionSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.LabelField("Development options");
        ITypelessCollectionSO collectionSO = (ITypelessCollectionSO)target;
        GUILayout.Label("Current Items: " + collectionSO.GetCount());
        //if (GUILayout.Button("Add Item instance"))
        //{
        //}
    }
}
