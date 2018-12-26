using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public static class PlayerDataChange
{

    /// <summary>
    /// 获得道具
    /// </summary>
    /// <param name="itemId">道具ID</param>
    /// <param name="itemNum">道具数量，可省略，默认为1</param>
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

    /// <summary>
    /// 增加经验
    /// </summary>
    /// <param name="expNum">增加的经验数值</param>
    public static void AddExp(int expNum)
    {
        PlayerData playerData = GameDataManager.PlayerData;
        playerData.Exp += expNum * (GameDataManager.PlayerData.Qualifications / 10000);//获得经验受资质影响
    }
}
