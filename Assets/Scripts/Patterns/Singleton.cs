using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Singleton<T> where T : Component
{
    static private T instance;

    static public T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log(string.Format
                (
                    "Your should initialise {0} component first, null returned \n" +
                    "Initialise it in Initialise component", 
                    typeof(T))
                );

                return null;
            }
            
            return instance;
        }
    }

    static public void Initialise()
    {
        if (instance != null) return;

        instance = GameObject.FindObjectOfType<T>();

        if (instance != null) return;

        GameObject obj = new GameObject(string.Format("[Singleton] {0}", typeof(T)));
        instance = obj.AddComponent<T>();

        MonoBehaviour.DontDestroyOnLoad(instance.gameObject);
    }
}
