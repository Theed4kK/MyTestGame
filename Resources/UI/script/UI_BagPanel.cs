using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_BagPanel : MonoBehaviour
{

    public GameObject ItemObj;
    public int DefaultNum;

    private readonly List<Item> ItemData = GameDataManager.PlayerData.ItemData;
    private UI_ListItem UI_ListItem;

    private void OnEnable()
    {
        SetItemList();

    }



    private void SetItemList()
    {
        foreach (Item item in ItemData)
        {
            UI_ListItem = UIBase.InitListItem(ItemObj);
            UI_ListItem.Objs[0].SetActive(true);
            UI_ListItem.Texts[0].text = item.itemNum.ToString();
            string Asset = COMMON.ItemIconPath + Cfg_Item.GetCfg(item.itemId).AssetName;
            UIBase.SetImageSpite(UI_ListItem.Images[0], Asset);
        }
        for (int i = 0; i < Mathf.Max(ItemData.Count, DefaultNum - ItemData.Count); i++)
        {
            UI_ListItem = UIBase.InitListItem(ItemObj);
            UI_ListItem.Objs[0].SetActive(false);
        }
    }
}
