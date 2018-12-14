using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public static class PlayerDataChange
{
    public static void GetItem(int itemId, int itemNum = 1)
    {
        List<Item> itemData = GameDataManager.PlayerData.ItemData;
        try
        {
            Item item= itemData.Find(c => c.itemId == itemId);
            item.itemNum += itemNum;
        }
        catch
        {
            itemData.Add(new Item() { itemId = itemId, itemNum = itemNum });
        }
    }
}
