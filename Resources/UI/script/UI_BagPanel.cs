using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BagPanel : MonoBehaviour {

    public GameObject ItemObj;

    private readonly Dictionary<int,int> ItemIdList = GameDataManager.PlayerData.ItemData;
    private UI_ListItem UI_ListItem;



    private void Start()
    {
        SetItemList();
    }

    private void SetItemList()
    {
        foreach (var item in ItemIdList)
        {
            UI_ListItem = UIBase.InitListItem(ItemObj);
            UI_ListItem.Objs[0].SetActive(true);
            UI_ListItem.Texts[0].text = item.Value.ToString();
            UIBase.SetSpite(UI_ListItem.Images[0], ItemCfg.GetItemInfo(item.Key).ItemIcon);
        }
        for(int i = 0; i < 100 - ItemIdList.Count; i++)
        {
            UI_ListItem = UIBase.InitListItem(ItemObj);
            UI_ListItem.Objs[0].SetActive(false);
        }
    }
}
