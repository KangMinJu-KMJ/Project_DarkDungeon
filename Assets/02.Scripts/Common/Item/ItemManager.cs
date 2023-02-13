using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ItemManager : MonoBehaviour
{
    public enum ItemType
    {
        HP = 1
    }
    //포션의 이미지, 포션의 기능
    public Sprite itemSprite;
    public int itemCount;
    public ItemType itemType;
}
