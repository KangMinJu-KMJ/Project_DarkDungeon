using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    private List<GameObject> questUI = new List<GameObject>();
    [SerializeField]
    private GameObject[] questList;
    [SerializeField]
    private PlayerData playerData;

    public static bool isClear = false;
    public static bool haveQuest = false;

    public static int questCount;
    public int clearGold;

    private void Start()
    {
        for (int i = 0; i < questList.Length; i++)
            questUI.Add(questList[i]);

        playerData = GetComponent<PlayerData>();
    }

    private void Update()
    {
    }

    public void ClickMayor()//최초로 촌장에게 말을 걸었을 시
    {
        if(!haveQuest)
        questList[0].SetActive(true);
    }

    public void ListenQuestButton()//촌장의 퀘스트를 들어보려고 할 때
    {
        if (!haveQuest)
        {
            Time.timeScale = 0;
            questList[1].SetActive(true);
            questList[0].SetActive(false);
        }
    }

    public void AcceptQuestButton()//촌장의 퀘스트를 수락했을 시
    {
        haveQuest = true;
        Time.timeScale = 0;
        questList[1].SetActive(false);
        questList[3].SetActive(true);
    }

    public void RefuseQuestButton()//촌장의 퀘스트를 거절했을 시
    {
        if (!haveQuest)
        {
            Time.timeScale = 0;
            questList[1].SetActive(false);
            questList[2].SetActive(true);
        }
    }

    public void DontClearClickMayorButton()//촌장의 퀘스트를 깨지 않고 다시 말을 걸었을 시
    {
            Time.timeScale = 0;
            questList[3].SetActive(true);
    }

    public void ClearButtonDown()//퀘스트를 깨고나서 말을 걸었을 시
    {
        if(questCount < 5 && !isClear)
        {
            DontClearClickMayorButton();
        }
        questList[4].SetActive(true);
        clearGold = 500;
        PlayerData.Gold += clearGold;
        Debug.Log(PlayerData.Gold);
        playerData.gold_Txt.text = string.Format("{0}", PlayerData.Gold);
        haveQuest = false;
        clearGold = 0;

    }

    public void Exit()//퀘스트창의 X버튼을 눌렀다면
    {
        Time.timeScale = 1;
        for (int i=0; i<questList.Length; i++)
        {
            questList[i].SetActive(false);
        }
    }

}
