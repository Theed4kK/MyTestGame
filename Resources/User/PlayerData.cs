using System.Collections.Generic;
using System.Linq;

public class PlayerData
{

    //属性类型
    public enum AttrType
    {
        attack = 1,//攻击
        defense = 2,//防御
        blood = 3,//血量
    }

    //属性数据
    public Dictionary<AttrType, int> PlayerAttr = new Dictionary<AttrType, int>
    {
        { AttrType.attack,11000},
        { AttrType.defense,20000},
        { AttrType.blood,30000}
    };

    public int Level = 1, Exp = 0;//等级、当前经验

    //道具信息,ID、数量
    public Dictionary<int, int> ItemData = new Dictionary<int, int>() {
        {1,10 },
        {2,4 },
        {3,5 },
        {4,6 },
        {5,13 },
    };  
    
}

public struct ItemInfo
{
    public int ItemId, ItemType;
    public string ItemName, ItemDes,ItemIcon;
}

public struct Monster
{
    public int MonsterId;
    public string MonsterName;
    public int Attack, Defense, Blood;
    public string MonsterSprit;
}