using System.Collections.Generic;

public class Cfg_Map
{
    public int Id;public string Name;public int Type;public string Des;public string Size;
    public static Dictionary<int,Cfg_Map> IdList = new Dictionary<int,Cfg_Map>() {
        {1,new Cfg_Map() {Id=1,Name="徐州",Type=1,Des="第一块",Size="8*8",}},
        {2,new Cfg_Map() {Id=2,Name="许昌",Type=0,Des="",Size="10*10",}},
        {3,new Cfg_Map() {Id=3,Name="益州",Type=1,Des="第三块",Size="8*8",}},
        {4,new Cfg_Map() {Id=4,Name="荆州",Type=1,Des="第四块",Size="10*10",}},
    };
}