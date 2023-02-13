using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Items items;
    public int itemCount;
    public Image itemIamge;
    public Text text_Count; //갯수쓰는 텍스트
    [SerializeField]
    private GameObject countImage; //갯수쓰는 텍스트 프레임
    public int itemEffect;

    private void SetColor(float _alpha)
    {
        Color color = itemIamge.color;
        color.a = _alpha;
        itemIamge.color = color;
    }

    public void AddItem(Items _items, int _count = 1)//처음 슬롯에 아이템을 추가했을 때
    {
        items = _items;
        itemCount = _count;
        itemIamge.sprite = items.itemSprite;
        itemEffect = items.itemEffect;
        countImage.SetActive(true);
        text_Count.text = itemCount.ToString();

        SetColor(1);
    }

    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot();
    }

    private void ClearSlot()
    {
        items = null;
        itemCount = 0;
        itemIamge.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        countImage.SetActive(false);
    }
}
