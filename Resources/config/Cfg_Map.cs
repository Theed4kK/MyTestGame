using System.Collections.Generic;

public class Cfg_Map
{
    public int Id;public string Name;public int Type;public int NextMap;public string Des;public int MaxMonsterNum;public int MonsterId_01;public int MonsterWeight_01;public int MonsterId_02;public int MonsterWeight_02;
    public static Dictionary<int,Cfg_Map> IdList = new Dictionary<int,Cfg_Map>() {
        {100,new Cfg_Map() {Id=100,Name="徐州1-1",Type=1,NextMap=101,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1000,MonsterWeight_02=2000,}},
        {101,new Cfg_Map() {Id=101,Name="徐州1-2",Type=1,NextMap=102,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1001,MonsterWeight_02=2000,}},
        {102,new Cfg_Map() {Id=102,Name="徐州1-3",Type=1,NextMap=103,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1002,MonsterWeight_02=2000,}},
        {103,new Cfg_Map() {Id=103,Name="徐州1-4",Type=1,NextMap=104,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1003,MonsterWeight_02=2000,}},
        {104,new Cfg_Map() {Id=104,Name="徐州1-5",Type=1,NextMap=105,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1000,MonsterWeight_02=2000,}},
        {105,new Cfg_Map() {Id=105,Name="徐州1-6",Type=1,NextMap=106,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1001,MonsterWeight_02=2000,}},
        {106,new Cfg_Map() {Id=106,Name="徐州1-7",Type=1,NextMap=107,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1002,MonsterWeight_02=2000,}},
        {107,new Cfg_Map() {Id=107,Name="徐州1-8",Type=1,NextMap=108,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1003,MonsterWeight_02=2000,}},
        {108,new Cfg_Map() {Id=108,Name="徐州1-9",Type=1,NextMap=109,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1000,MonsterWeight_02=2000,}},
        {109,new Cfg_Map() {Id=109,Name="徐州1-10",Type=1,NextMap=110,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1001,MonsterWeight_02=2000,}},
        {110,new Cfg_Map() {Id=110,Name="徐州1-11",Type=1,NextMap=0,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1002,MonsterWeight_02=2000,}},
        {200,new Cfg_Map() {Id=200,Name="许昌",Type=1,NextMap=300,Des="第二关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=1003,MonsterWeight_02=2000,}},
        {300,new Cfg_Map() {Id=300,Name="益州",Type=1,NextMap=400,Des="第三关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=2001,MonsterWeight_02=2000,}},
        {400,new Cfg_Map() {Id=400,Name="荆州",Type=1,NextMap=0,Des="第四关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=8000,MonsterId_02=2002,MonsterWeight_02=2000,}},
    };
    public static Cfg_Map GetCfg(int index)
    {
        return IdList[index];
    }
}