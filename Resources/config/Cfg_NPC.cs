using System.Collections.Generic;

public class Cfg_NPC
{
    public int Id;public string Name;public int Type;public string Des;
    public static Dictionary<int,Cfg_NPC> IdList = new Dictionary<int,Cfg_NPC>() {
        {1,new Cfg_NPC() {Id=1,Name="周瑜",Type=1,Des="咸鱼1",}},
        {2,new Cfg_NPC() {Id=2,Name="黄盖",Type=1,Des="咸鱼2",}},
        {3,new Cfg_NPC() {Id=3,Name="甘宁",Type=1,Des="咸鱼3",}},
        {4,new Cfg_NPC() {Id=4,Name="陆逊",Type=1,Des="咸鱼4",}},
    };
}