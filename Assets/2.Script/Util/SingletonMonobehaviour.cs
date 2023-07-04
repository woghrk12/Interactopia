using UnityEngine;

public class SingletonMonobehaviour<T> : MonoBehaviour where T : Component
{
    #region Variables

    private static T instance = null;

    #endregion Variables

    #region Properties

    protected static T Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null) { instance = new GameObject(typeof(T).Name, typeof(T)).GetComponent<T>(); }
            }

            return instance;
        }
    }

    #endregion Properties

    #region Unity Events

    protected virtual void Awake()
    {
        T[] t_objs = FindObjectsOfType<T>();

        if (t_objs.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        if (transform.parent != null && transform.root != null) { DontDestroyOnLoad(transform.root.gameObject); }
        else { DontDestroyOnLoad(gameObject); }
    }

    #endregion Unity Events
}
