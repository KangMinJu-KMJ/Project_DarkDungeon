using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public static GameManager Instance;


    void Start()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    void Update()
    {
        if(isGameOver)
        {
            Invoke("SceneLoad", 3.0f);
            
        }
    }

    void SceneLoad()
    {
        SceneManager.LoadScene("StartScene");
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 0) // 로드된 씬이 0일경우
        {
            Destroy(gameObject);
        }
    }
}
