using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SBManager : MonoBehaviour
{
    [SerializeField]
    private GameObject createChar;
    [SerializeField]
    private InputField userName;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        createChar = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(2).gameObject;
        userName = GameObject.Find("Canvas").transform.GetChild(0).transform.GetChild(2).transform
            .GetChild(1).GetComponent<InputField>();
    }

    public void UserNameSave()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
        //createChar.SetActive(true);
    }

    public void StartGameViewExit()
    {
        //createChar.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {

    }

}
