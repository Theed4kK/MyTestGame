using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public static class PlayerDataChange
{
    public static void GetItem(int itemId, int itemNum)
    {
        List<item> itemData = GameDataManager.PlayerData.ItemData;
        try
        {
            item item= itemData.Find(c => c.itemId == itemId);
            item.itemNum += itemNum;
        }
        catch
        {
            itemData.Add(new item() { itemId = itemId, itemNum = itemNum });
        }
    }
}
