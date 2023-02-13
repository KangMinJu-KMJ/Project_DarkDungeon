using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest
{
    //퀘스트 고유 번호
    public int index;
    //담당 NPC 번호
    public int npcIndex;
    //대사 목록
    public List<string> _strList;
    //보상
    public int gold;
    //클리어 여부
    public bool isClear = false;
    //반복 가능 여부
    public bool isRepeat = false;


    private int _step = 0;
    public int step
    {
        get
        {
            return _step;
        }
        set
        {
            step = value;

            if (step >= 100)
                isClear = true;

        }
    }

    //선행 퀘 정보
    //public int beforeQuestIndex = int.MaxValue;


}
