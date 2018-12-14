using System.Collections.Generic;
using System.Linq;

public class Cfg_NPC
{
    public int Id;public int Camp;public int Lv;public string Name;public int Type;public int Color;public string Des;public int AppearOnStart;public int Dialog;public int Attack;public int Defense;public int Blood;public int DropId;public string AssetName;
    public static Dictionary<int,Cfg_NPC> IdList = new Dictionary<int,Cfg_NPC>() {
        {1000,new Cfg_NPC() {Id=1000,Camp=1,Lv=1,Name="周瑜",Type=1,Color=1,Des="吴国大将",AppearOnStart=1,Dialog=1,Attack=1000,Defense=100,Blood=10000,DropId=100,AssetName="ZhouYu",}},
        {1001,new Cfg_NPC() {Id=1001,Camp=1,Lv=2,Name="黄盖",Type=2,Color=2,Des="吴国大将",AppearOnStart=0,Dialog=0,Attack=1001,Defense=100,Blood=10010,DropId=200,AssetName="HuangGai",}},
        {1002,new Cfg_NPC() {Id=1002,Camp=1,Lv=3,Name="甘宁",Type=2,Color=3,Des="吴国大将",AppearOnStart=0,Dialog=0,Attack=1002,Defense=100,Blood=10020,DropId=300,AssetName="GanNing",}},
        {1003,new Cfg_NPC() {Id=1003,Camp=1,Lv=4,Name="陆逊",Type=2,Color=3,Des="吴国大将",AppearOnStart=0,Dialog=0,Attack=1003,Defense=100,Blood=10030,DropId=400,AssetName="LuXun",}},
        {2000,new Cfg_NPC() {Id=2000,Camp=2,Lv=5,Name="赵云",Type=2,Color=3,Des="蜀国大将",AppearOnStart=0,Dialog=0,Attack=2000,Defense=100,Blood=20000,DropId=500,AssetName="ZhaoYun",}},
        {2001,new Cfg_NPC() {Id=2001,Camp=2,Lv=6,Name="诸葛亮",Type=2,Color=3,Des="蜀国大将",AppearOnStart=0,Dialog=0,Attack=2001,Defense=100,Blood=20010,DropId=600,AssetName="ZhuGeLiang",}},
        {2002,new Cfg_NPC() {Id=2002,Camp=2,Lv=7,Name="关羽",Type=2,Color=3,Des="蜀国大将",AppearOnStart=0,Dialog=0,Attack=2002,Defense=100,Blood=20020,DropId=700,AssetName="GuanYu",}},
        {2003,new Cfg_NPC() {Id=2003,Camp=2,Lv=8,Name="张飞",Type=2,Color=3,Des="蜀国大将",AppearOnStart=0,Dialog=0,Attack=2003,Defense=100,Blood=20030,DropId=800,AssetName="ZhangFei",}},
        {3000,new Cfg_NPC() {Id=3000,Camp=3,Lv=9,Name="夏侯渊",Type=2,Color=3,Des="魏国大将",AppearOnStart=0,Dialog=0,Attack=3000,Defense=100,Blood=30000,DropId=900,AssetName="XiaHouYuan",}},
        {3001,new Cfg_NPC() {Id=3001,Camp=3,Lv=10,Name="司马懿",Type=2,Color=3,Des="魏国大将",AppearOnStart=0,Dialog=0,Attack=3001,Defense=100,Blood=30010,DropId=1000,AssetName="SiMaYi",}},
        {3002,new Cfg_NPC() {Id=3002,Camp=3,Lv=11,Name="夏侯淳",Type=2,Color=3,Des="魏国大将",AppearOnStart=0,Dialog=0,Attack=3002,Defense=100,Blood=30020,DropId=1100,AssetName="XiaHouDun",}},
        {3003,new Cfg_NPC() {Id=3003,Camp=3,Lv=12,Name="许诸",Type=2,Color=3,Des="魏国大将",AppearOnStart=0,Dialog=0,Attack=3003,Defense=100,Blood=30030,DropId=1200,AssetName="XuZhu",}},
        {10000,new Cfg_NPC() {Id=10000,Camp=1,Lv=13,Name="吴国刀兵",Type=2,Color=0,Des="吴国小兵",AppearOnStart=0,Dialog=0,Attack=10000,Defense=100,Blood=100000,DropId=1300,AssetName="ShiBing",}},
        {20000,new Cfg_NPC() {Id=20000,Camp=2,Lv=14,Name="蜀国刀兵",Type=2,Color=0,Des="吴国小兵",AppearOnStart=0,Dialog=0,Attack=20000,Defense=100,Blood=200000,DropId=1400,AssetName="ShiBing",}},
        {30000,new Cfg_NPC() {Id=30000,Camp=3,Lv=15,Name="魏国刀兵",Type=2,Color=0,Des="吴国小兵",AppearOnStart=0,Dialog=0,Attack=30000,Defense=100,Blood=300000,DropId=1500,AssetName="ShiBing",}},
    };
    public static Cfg_NPC GetCfg(int index)
    {
        return IdList[index];
    }
    public static List<Cfg_NPC> GetAllCfg()
    {
        return IdList.Values.ToList();
    }
}