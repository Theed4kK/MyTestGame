using System.Collections.Generic;

public class Cfg_NPC
{
    public int Id;public int Camp;public string Name;public int Type;public int Color;public string Des;public int Dialog;public int Attack;public int Blood;public int DropItem;public int DropItemNum;public int DropItemPro;public string AssetName;
    public static Dictionary<int,Cfg_NPC> IdList = new Dictionary<int,Cfg_NPC>() {
        {1000,new Cfg_NPC() {Id=1000,Camp=1,Name="周瑜",Type=1,Color=2,Des="吴国大将",Dialog=1,Attack=1000,Blood=10000,DropItem=200,DropItemNum=1,DropItemPro=5000,AssetName="ZhouYu",}},
        {1001,new Cfg_NPC() {Id=1001,Camp=1,Name="黄盖",Type=2,Color=3,Des="吴国大将",Dialog=0,Attack=1001,Blood=10001,DropItem=201,DropItemNum=1,DropItemPro=5000,AssetName="HuangGai",}},
        {1002,new Cfg_NPC() {Id=1002,Camp=1,Name="甘宁",Type=2,Color=4,Des="吴国大将",Dialog=0,Attack=1002,Blood=10002,DropItem=200,DropItemNum=1,DropItemPro=5000,AssetName="GanNing",}},
        {1003,new Cfg_NPC() {Id=1003,Camp=1,Name="陆逊",Type=2,Color=4,Des="吴国大将",Dialog=0,Attack=1003,Blood=10003,DropItem=201,DropItemNum=1,DropItemPro=5000,AssetName="LuXun",}},
        {2000,new Cfg_NPC() {Id=2000,Camp=2,Name="赵云",Type=2,Color=4,Des="蜀国大将",Dialog=0,Attack=1000,Blood=10000,DropItem=200,DropItemNum=1,DropItemPro=5000,AssetName="ZhaoYun",}},
        {2001,new Cfg_NPC() {Id=2001,Camp=2,Name="诸葛亮",Type=2,Color=4,Des="蜀国大将",Dialog=0,Attack=1001,Blood=10001,DropItem=201,DropItemNum=1,DropItemPro=5000,AssetName="ZhuGeLiang",}},
        {2002,new Cfg_NPC() {Id=2002,Camp=2,Name="关羽",Type=2,Color=4,Des="蜀国大将",Dialog=0,Attack=1002,Blood=10002,DropItem=200,DropItemNum=1,DropItemPro=5000,AssetName="GuanYu",}},
        {2003,new Cfg_NPC() {Id=2003,Camp=2,Name="张飞",Type=2,Color=4,Des="蜀国大将",Dialog=0,Attack=1003,Blood=10003,DropItem=201,DropItemNum=1,DropItemPro=5000,AssetName="ZhangFei",}},
        {3000,new Cfg_NPC() {Id=3000,Camp=3,Name="夏侯渊",Type=2,Color=4,Des="魏国大将",Dialog=0,Attack=1000,Blood=10000,DropItem=200,DropItemNum=1,DropItemPro=5000,AssetName="XiaHouYuan",}},
        {3001,new Cfg_NPC() {Id=3001,Camp=3,Name="司马懿",Type=2,Color=4,Des="魏国大将",Dialog=0,Attack=1001,Blood=10001,DropItem=201,DropItemNum=1,DropItemPro=5000,AssetName="SiMaYi",}},
        {3002,new Cfg_NPC() {Id=3002,Camp=3,Name="夏侯淳",Type=2,Color=4,Des="魏国大将",Dialog=0,Attack=1002,Blood=10002,DropItem=200,DropItemNum=1,DropItemPro=5000,AssetName="XiaHouDun",}},
        {3003,new Cfg_NPC() {Id=3003,Camp=3,Name="许诸",Type=2,Color=4,Des="魏国大将",Dialog=0,Attack=1003,Blood=10003,DropItem=201,DropItemNum=1,DropItemPro=5000,AssetName="XuZhu",}},
        {10000,new Cfg_NPC() {Id=10000,Camp=1,Name="吴国刀兵",Type=2,Color=1,Des="吴国小兵",Dialog=0,Attack=100,Blood=1000,DropItem=100,DropItemNum=1,DropItemPro=5000,AssetName="ShiBing",}},
        {20000,new Cfg_NPC() {Id=20000,Camp=2,Name="蜀国刀兵",Type=2,Color=1,Des="吴国小兵",Dialog=0,Attack=100,Blood=1000,DropItem=101,DropItemNum=1,DropItemPro=5000,AssetName="ShiBing",}},
        {30000,new Cfg_NPC() {Id=30000,Camp=3,Name="魏国刀兵",Type=2,Color=1,Des="吴国小兵",Dialog=0,Attack=100,Blood=1000,DropItem=100,DropItemNum=1,DropItemPro=5000,AssetName="ShiBing",}},
    };
    public static Cfg_NPC GetCfg(int index)
    {
        return IdList[index];
    }
}