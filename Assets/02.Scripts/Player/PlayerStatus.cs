using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    //1.골드 2.HP
    public int initHp = 100;
    public float currHp;
    public float Dmg = 20f;
    

    void Start()
    {
        currHp = initHp;
        
    }


}
