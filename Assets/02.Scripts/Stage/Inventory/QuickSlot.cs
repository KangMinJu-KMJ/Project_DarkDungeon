using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot : MonoBehaviour
{
    [SerializeField]
    private GameObject quickSlot;
    public Items items;
    private int itemCount;
    private int itemEffect;
    [SerializeField]
    private Image itemIamge;
    [SerializeField]
    private Text text_Count; //갯수쓰는 텍스트
    [SerializeField]
    private GameObject countImage; //갯수쓰는 텍스트 프레임
    [SerializeField]
    private Slots[] slots;
    [SerializeField]
    private Transform slotParent;
    private PlayerStatus playerStatus;
    [SerializeField]
    private Image HpBar;

    private void Start()
    {
        slots = slotParent.GetComponentsInChildren<Slots>();
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        UseItem();
    }

    private void UseItem()
    {
        if(!Inventory.inventoryOpen && itemCount >= 1 && Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerStatus.currHp += itemEffect;
            itemCount--;
            text_Count.text = itemCount.ToString();
            HpBar.fillAmount = (playerStatus.currHp / playerStatus.initHp);
        }
        else if(itemCount <=0)
        {

            ClearSlot();
        }
    }

    public void ClickFirstItem()
    {
        if (slots[0].itemIamge != null && itemCount <= 0)
        {
            quickSlot.SetActive(true);
            items = slots[0].items;
            itemCount = slots[0].itemCount;
            itemIamge.sprite = slots[0].itemIamge.sprite;
            itemEffect = slots[0].itemEffect;
            countImage.SetActive(true);
            text_Count.text = itemCount.ToString();

            SetColor(1);
        }
    }

    private void SetColor(float _alpha)
    {
        Color color = itemIamge.color;
        color.a = _alpha;
        itemIamge.color = color;
    }

    public void ClearSlot()
    {
        items = null;
        itemCount = 0;
        itemIamge.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        countImage.SetActive(false);
    }
}
