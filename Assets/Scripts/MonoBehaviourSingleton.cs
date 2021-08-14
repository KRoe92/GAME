using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
{
    private static T _Instance;

    public static T Instance
    {
        get { return _Instance; }
        protected set { _Instance = value; }
    }

    protected virtual void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(this.gameObject);
            Debug.LogError("More than one instance of " + typeof(T) + " found", this);
        }
        else
        {
            _Instance = (T)this;
        }
    }
}
