using System;
using System.Linq;
using UnityEditor;
using UnityEngine;


namespace ModelInstanceCollection
{
    [CustomEditor(typeof(CollectionSO<>), true)]
    public class CollectionSOEditor : Editor
    {
        public static SerializableScriptableObject _debugModel;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.LabelField("Development options");
            ICollection collection = (ICollection)target;
            CreateNewInstance(collection);
            ClearCollection(collection);
        }

        private void ClearCollection(ICollection collection)
        {
            if (GUILayout.Button("Clear collection"))
            {
                collection.Clear();
            }

        }

        private void CreateNewInstance(ICollection collection)
        {
            bool hasInterface = collection.GetType().BaseType.GetGenericArguments()[0].GetInterfaces().Contains(typeof(IInstance));

            if (hasInterface)
            {
                _debugModel = (SerializableScriptableObject)EditorGUILayout.ObjectField("Debug Model: ", _debugModel, typeof(SerializableScriptableObject));

                if (GUILayout.Button("Create Instance"))
                {

                    if (_debugModel is IModel)
                    {
                        IModel targetModel = (IModel)_debugModel;
                        collection.AddItem(targetModel.GetInstance());

                    }

                }
            }
        }
    }
}