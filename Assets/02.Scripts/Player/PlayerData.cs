using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public Text gold_Txt;
    public static int Gold = 500;


    void Start()
    {
        gold_Txt = GameObject.Find("Player_Canvas").transform.GetChild(2).
           transform.GetChild(1).GetComponent<Text>();
    }


    void Update()
    {
        
    }
}
