using System;
using System.Collections.Generic;

public class Config
{
    public static Dictionary<int, ItemInfo> ItemCfg;
    public static Dictionary<int, Monster> MonsterCfg;

}

public static class ItemCfg
{
    private static readonly Dictionary<int, ItemInfo> itemCfg = new Dictionary<int, ItemInfo>() {
        {1, new ItemInfo(){ItemId =1,ItemName="测试道具",ItemType = 1,ItemDes="测试道具描述",ItemIcon = "texture/UITexture/icons/armor" } },
        {2, new ItemInfo(){ItemId =2,ItemName="测试道具",ItemType = 1,ItemDes="测试道具描述",ItemIcon = "texture/UITexture/icons/armor" } },
        {3, new ItemInfo(){ItemId =3,ItemName="测试道具",ItemType = 1,ItemDes="测试道具描述",ItemIcon = "texture/UITexture/icons/armor" } },
        {4, new ItemInfo(){ItemId =4,ItemName="测试道具",ItemType = 1,ItemDes="测试道具描述",ItemIcon = "texture/UITexture/icons/armor" } },
        {5, new ItemInfo(){ItemId =5,ItemName="测试道具",ItemType = 1,ItemDes="测试道具描述",ItemIcon = "texture/UITexture/icons/armor" } },
        {6, new ItemInfo(){ItemId =6,ItemName="测试道具",ItemType = 1,ItemDes="测试道具描述",ItemIcon = "texture/UITexture/icons/armor" } },
        {7, new ItemInfo(){ItemId =7,ItemName="测试道具",ItemType = 1,ItemDes="测试道具描述",ItemIcon = "texture/UITexture/icons/armor" } },
        {8, new ItemInfo(){ItemId =8,ItemName="测试道具",ItemType = 1,ItemDes="测试道具描述",ItemIcon = "texture/UITexture/icons/armor" } },
    };

    public static ItemInfo GetItemInfo(int itemId)
    {
        return itemCfg[itemId];
    }

}