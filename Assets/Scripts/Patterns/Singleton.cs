using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static private T instance;

    static public T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject(string.Format("{0} Singleton", typeof(T)));
                    instance = obj.AddComponent<T>();
                }
            }
            
            return instance;
        }
    }
}
