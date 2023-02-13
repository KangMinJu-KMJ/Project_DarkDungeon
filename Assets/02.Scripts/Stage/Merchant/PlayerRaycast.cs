using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour
{
    private Ray ray;
    private RaycastHit rayHit;
    [SerializeField]
    private GameObject merchantUI;
    [SerializeField]
    private GameObject QuestUI;
    private PlayerQuest playerQuest;

    void Start()
    {
        playerQuest = GameObject.Find("GameManager").GetComponent<PlayerQuest>();
    }


    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 20.0f, Color.green);
        OpenShop();
        OpenQuest();
    }

    void OpenShop()
    {
        if (Physics.Raycast(ray, out rayHit, 20f, 1<<12))
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                merchantUI.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }


    void OpenQuest()
    {
        if (Physics.Raycast(ray, out rayHit, 20f, 1 << 13))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (PlayerQuest.questCount >= 5)
                {
                    PlayerQuest.isClear = true;
                    if(PlayerQuest.isClear)
                    playerQuest.ClearButtonDown();
                }
                else if(!PlayerQuest.isClear && PlayerQuest.haveQuest)
                {
                    playerQuest.DontClearClickMayorButton();
                }
                else
                playerQuest.ClickMayor();
            }
        }
    }
}
