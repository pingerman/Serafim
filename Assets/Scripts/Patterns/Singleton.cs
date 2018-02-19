using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    static private T instance;

    static public T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log(string.Format("Your should initialise {0} component first, null returned \n" +
                    "Initialise it in Initialise component", typeof(T)));
                return null;
            }

            return instance;
        }
    }

    static public void Initialise()
    {
        if (instance != null) return;
        GameObject obj = new GameObject(string.Format("[Singleton] {0}", typeof(T)));
        obj.AddComponent<T>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
