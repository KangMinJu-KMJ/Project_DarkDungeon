using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantClick : MonoBehaviour
{
    [SerializeField]
    private GameObject potion_Info;
    [SerializeField]
    private GameObject shop_Base;
    [SerializeField]
    private Inventory inventory;
    private ItemPickUp itemPickUp;
    [SerializeField]
    private PlayerData playerData;
    private int hpPotionPrice = 30;
    //[SerializeField]
    //private AudioSource source;
    //[SerializeField]
    //private AudioClip buyItem;
    //private SoundManager soundManager;

    private void Start()
    {
        //source = GetComponent<AudioSource>();
        //buyItem = soundManager.buyItem;
        //soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    public void ClickPotion()
    {
        if (itemPickUp == null)
        {
            itemPickUp = GameObject.FindObjectOfType<ItemPickUp>();
            inventory.AcquireItem(itemPickUp.items);
            PlayerData.Gold -= hpPotionPrice;
            playerData.gold_Txt.text = string.Format("{0}", PlayerData.Gold);
            //if(!source.isPlaying)
            //{
            //    source.clip = buyItem;
            //    source.Play();
            //}
        }
        else
        {
            itemPickUp = null;
            itemPickUp = GameObject.Find("Shop_ItemFrame").
                transform.GetChild(0).GetComponent<ItemPickUp>();
            inventory.AcquireItem(itemPickUp.items);
            PlayerData.Gold -= hpPotionPrice;
            playerData.gold_Txt.text = string.Format("{0}", PlayerData.Gold);
            //if (!source.isPlaying)
            //{
            //    source.clip = buyItem;
            //    source.Play();
            //}
        }
        
    }

    public void CloseShop()
    {
        shop_Base.SetActive(false);
        Time.timeScale = 1f;
    }
}
