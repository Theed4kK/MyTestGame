using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public static class PlayerDataChange
{
    public static void GetItem(int itemId,int itemNum)
    {
        Dictionary<int, int> itemData = GameDataManager.PlayerData.ItemData;
        if (itemData.ContainsKey(itemId))
        {
            itemData[itemId] = itemData[itemId] + itemNum;
        }
        else
        {
            itemData.Add(itemId, itemNum);
        }
    }
}
