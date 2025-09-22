
using Mirror;
using UnityEngine;
public class MonoSingleton<T>:NetworkBehaviour where T : MonoSingleton<T> 
{
    private static T instance;
    public static T Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = GameObject.FindAnyObjectByType<T>();
                if (instance == null)
                {
                    var go = new GameObject(typeof(T).Name);
                    instance = go.AddComponent<T>();
                }
            }
            return instance; 
        }
    }
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(instance);
        }
    }
}
