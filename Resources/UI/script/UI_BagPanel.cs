using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_BagPanel : MonoBehaviour
{

    public GameObject ItemObj;

    private readonly List<item> ItemData = GameDataManager.PlayerData.ItemData;
    //private Itemdatas Itemdatas = GameDataManager.PlayerData.ItemDatas;
    private UI_ListItem UI_ListItem;



    private void Start()
    {
        SetItemList();
    }

    private void SetItemList()
    {
        foreach (var item in ItemData)
        {
            UI_ListItem = UIBase.InitListItem(ItemObj);
            UI_ListItem.Objs[0].SetActive(true);
            UI_ListItem.Texts[0].text = item.itemNum.ToString();
            string Asset = COMMON.ItemIconPath + Cfg_Item.GetCfg(item.itemId).AssetName;
            UIBase.SetImageSpite(UI_ListItem.Images[0], Asset);
        }
        for (int i = 0; i < 100 - ItemData.Count; i++)
        {
            UI_ListItem = UIBase.InitListItem(ItemObj);
            UI_ListItem.Objs[0].SetActive(false);
        }
    }
}
