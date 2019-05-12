using System.Collections.Generic;

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
    /// <param name="AffectedByQualifications">是否受资质影响，可省略，默认受资质影响</param>
    public static void AddExp(int expNum,bool AffectedByQualifications = true)
    {
        float coefficient = AffectedByQualifications ? (GameDataManager.PlayerData.Qualifications / 10000) : 1;
        PlayerData playerData = GameDataManager.PlayerData;
        playerData.Exp += expNum * coefficient;//获得经验受资质影响
    }
}
