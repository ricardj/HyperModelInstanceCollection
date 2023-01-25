using UnityEngine;

namespace ModelInstanceCollection
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {

        static T _get;

        public static T get
        {
            get
            {
                return _get;
            }
        }

        public void Awake()
        {

            if (_get == null)
            {
                _get = (T)this;
            }
            else if (_get != this)
            {
                Destroy(gameObject);
            }
        }

    }
}