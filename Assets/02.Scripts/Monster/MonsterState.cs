using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterState : MonoBehaviour
{
    public int initHp = 100;
    public float currHp;


    void Start()
    {
        currHp = initHp;
    }

}
