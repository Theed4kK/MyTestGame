using System.Collections.Generic;
using System.Linq;

public class Cfg_Map
{
    public int Id;public string Name;public int Type;public int NextMap;public string Des;public int GenMonsterRule;
    public static Dictionary<int,Cfg_Map> IdList = new Dictionary<int,Cfg_Map>() {
        {100,new Cfg_Map() {Id=100,Name="徐州1-1",Type=1,NextMap=101,Des="第1关",GenMonsterRule=100,}},
        {101,new Cfg_Map() {Id=101,Name="徐州1-2",Type=1,NextMap=102,Des="第2关",GenMonsterRule=101,}},
        {102,new Cfg_Map() {Id=102,Name="徐州1-3",Type=1,NextMap=103,Des="第3关",GenMonsterRule=102,}},
        {103,new Cfg_Map() {Id=103,Name="徐州1-4",Type=1,NextMap=104,Des="第4关",GenMonsterRule=103,}},
        {104,new Cfg_Map() {Id=104,Name="徐州1-5",Type=1,NextMap=105,Des="第5关",GenMonsterRule=104,}},
        {105,new Cfg_Map() {Id=105,Name="徐州1-6",Type=1,NextMap=106,Des="第6关",GenMonsterRule=105,}},
        {106,new Cfg_Map() {Id=106,Name="徐州1-7",Type=1,NextMap=107,Des="第7关",GenMonsterRule=106,}},
        {107,new Cfg_Map() {Id=107,Name="徐州1-8",Type=1,NextMap=108,Des="第8关",GenMonsterRule=107,}},
        {108,new Cfg_Map() {Id=108,Name="徐州1-9",Type=1,NextMap=109,Des="第9关",GenMonsterRule=108,}},
        {109,new Cfg_Map() {Id=109,Name="徐州1-10",Type=1,NextMap=110,Des="第10关",GenMonsterRule=109,}},
        {110,new Cfg_Map() {Id=110,Name="徐州1-11",Type=1,NextMap=0,Des="第11关",GenMonsterRule=110,}},
        {200,new Cfg_Map() {Id=200,Name="许昌",Type=1,NextMap=300,Des="第12关",GenMonsterRule=200,}},
        {300,new Cfg_Map() {Id=300,Name="益州",Type=1,NextMap=400,Des="第13关",GenMonsterRule=300,}},
        {400,new Cfg_Map() {Id=400,Name="荆州",Type=1,NextMap=0,Des="第14关",GenMonsterRule=400,}},
    };
    public static Cfg_Map GetCfg(int index)
    {
        return IdList[index];
    }
    public static List<Cfg_Map> GetAllCfg()
    {
        return IdList.Values.ToList();
    }
}