using UnityEngine;

public class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        // Call Singleton Awake function to ensure only one instance is created
        // If this is a duplicate instance, don't initialize
        base.Awake();
        if (this != m_Instance)
            return;

        // Make object persistent between scenes
        Object.DontDestroyOnLoad(this.gameObject);
    }
}
