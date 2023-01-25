using UnityEngine;

namespace ModelInstanceCollection
{
    public class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
    {
        static T instance;
        public static T get
        {
            get
            {
                if (instance == null)
                {
                    T[] assets = Resources.LoadAll<T>("");
                    if (assets == null || assets.Length < 1)
                    {
                        throw new System.Exception("Could not find any instance");
                    }
                    else if (assets.Length > 1)
                    {
                        Debug.LogError("Found more than 1 instance of the singleton");
                    }
                    instance = assets[0];
                }
                return instance;
            }
        }
    }
}