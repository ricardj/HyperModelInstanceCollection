using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{

    static T _get;

    public T get
    {
        get
        {
            if (_get == null)
            {
                _get = (T)this;
            }
            else if (_get != this)
            {
                Destroy(gameObject);
            }
            return _get;

        }
    }

}
