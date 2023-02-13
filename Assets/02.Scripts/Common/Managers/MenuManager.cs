using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public RectTransform menuBackground;
    public RectTransform pauseMenu;
    public RectTransform soundMenu;
    public RectTransform screenMenu;
    private GameObject player;
    public static MenuManager instance;
    [SerializeField]
    private GameObject playerUI;

    void Start()
    {
        player = GameObject.FindWithTag("Player").gameObject;
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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            playerUI.SetActive(false);
        }
   
    }

    public void Pause()
    {
        if(menuBackground.gameObject.activeInHierarchy == false)
        {
            if(pauseMenu.gameObject.activeInHierarchy == false)
            {
                pauseMenu.gameObject.SetActive(true);
            }
            menuBackground.gameObject.SetActive(true);
            Time.timeScale = 0f;
            player.SetActive(false);
        }
        else
        {
            menuBackground.gameObject.SetActive(false);
            Time.timeScale = 1f;
            player.SetActive(true);
            playerUI.SetActive(true);
        }
    }

    public void Sounds(bool open)
    {
        if(open)
        {
            soundMenu.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
        }
        if(!open)
        {
            soundMenu.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
        }
    }

    public void Screen(bool open)
    {
        if(open)
        {
            soundMenu.gameObject.SetActive(false);
            screenMenu.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
        }
        if(!open)
        {
            soundMenu.gameObject.SetActive(false);
            screenMenu.gameObject.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
        }
    }

    public void Save()
    {
        SaveData.Instance.SaveGameData();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
