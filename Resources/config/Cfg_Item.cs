using System.Collections.Generic;
using System.Linq;

public class Cfg_Item
{
    public int Id;public string ItemName;public int ItemType;public int Parameter;public int Color;public string ItemDes;public string AssetName;
    public static Dictionary<int,Cfg_Item> IdList = new Dictionary<int,Cfg_Item>() {
        {100,new Cfg_Item() {Id=100,ItemName="血瓶恢复",ItemType=1,Parameter=50,Color=1,ItemDes="拾取后自动恢复血量",AssetName="hp",}},
        {101,new Cfg_Item() {Id=101,ItemName="攻击提升",ItemType=2,Parameter=10,Color=1,ItemDes="拾取后自动增加攻击",AssetName="sword",}},
        {200,new Cfg_Item() {Id=200,ItemName="斧头",ItemType=3,Parameter=100,Color=2,ItemDes="可装备增加攻击",AssetName="axe",}},
        {201,new Cfg_Item() {Id=201,ItemName="皮甲",ItemType=4,Parameter=1000,Color=2,ItemDes="可装备增加血量上限",AssetName="armor",}},
    };
    public static Cfg_Item GetCfg(int index)
    {
        return IdList[index];
    }
    public static List<Cfg_Item> GetAllCfg()
    {
        return IdList.Values.ToList();
    }
}