using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObjects2 : MonoBehaviour
{
    public static DontDestroyObjects2 instance;

    void Start()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void OnLevelWasLoaded(int level)
    {
        if (level == 0) // 로드된 씬이 0일경우
        {
            Destroy(gameObject);
        }
    }
}
