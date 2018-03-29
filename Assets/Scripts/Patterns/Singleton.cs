using UnityEngine;

/// <summary>
/// Класс, реализующий шаблон проектирования синглтон, нужен для создания единственных объектов, переходящих между сценами
/// </summary>
/// <typeparam name="T">Тип объекта</typeparam>
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

    void Awake()
    {
        if (instance == null) instance = this as T;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    static public void Initialise()
    {
        var ins = Instance;
    }
}
