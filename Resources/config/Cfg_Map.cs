using System.Collections.Generic;

public class Cfg_Map
{
    public int Id;public string Name;public int Type;public string Des;public int MaxMonsterNum;public int MonsterId_01;public int MonsterWeight_01;public int MonsterId_02;public int MonsterWeight_02;
    public static Dictionary<int,Cfg_Map> IdList = new Dictionary<int,Cfg_Map>() {
        {100,new Cfg_Map() {Id=100,Name="徐州",Type=1,Des="第一关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=9800,MonsterId_02=1000,MonsterWeight_02=200,}},
        {200,new Cfg_Map() {Id=200,Name="许昌",Type=1,Des="第二关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=9800,MonsterId_02=1000,MonsterWeight_02=200,}},
        {300,new Cfg_Map() {Id=300,Name="益州",Type=1,Des="第三关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=9800,MonsterId_02=1000,MonsterWeight_02=200,}},
        {400,new Cfg_Map() {Id=400,Name="荆州",Type=1,Des="第四关",MaxMonsterNum=5,MonsterId_01=10000,MonsterWeight_01=9800,MonsterId_02=1000,MonsterWeight_02=200,}},
    };
    public static Cfg_Map GetCfg(int index)
    {
        return IdList[index];
    }
}