using System.Collections.Generic;
using System.Linq;

public class Cfg_Chapter
{
    public int Id;public string Name;public int StartMap;public int NeedMap;public string Des;public string Asset;
    public static Dictionary<int,Cfg_Chapter> IdList = new Dictionary<int,Cfg_Chapter>() {
        {1,new Cfg_Chapter() {Id=1,Name="徐州",StartMap=100,NeedMap=0,Des="第1章",Asset="0001",}},
        {11,new Cfg_Chapter() {Id=11,Name="荆州",StartMap=100,NeedMap=102,Des="第2章",Asset="0011",}},
        {21,new Cfg_Chapter() {Id=21,Name="扬州",StartMap=100,NeedMap=103,Des="第3章",Asset="0021",}},
        {31,new Cfg_Chapter() {Id=31,Name="广州",StartMap=100,NeedMap=104,Des="第4章",Asset="0031",}},
        {41,new Cfg_Chapter() {Id=41,Name="苏州",StartMap=100,NeedMap=105,Des="第5章",Asset="0041",}},
        {51,new Cfg_Chapter() {Id=51,Name="幽州",StartMap=100,NeedMap=106,Des="第6章",Asset="0051",}},
        {61,new Cfg_Chapter() {Id=61,Name="凉州",StartMap=100,NeedMap=107,Des="第7章",Asset="0061",}},
        {71,new Cfg_Chapter() {Id=71,Name="冀州",StartMap=100,NeedMap=108,Des="第8章",Asset="0071",}},
        {81,new Cfg_Chapter() {Id=81,Name="雍州",StartMap=100,NeedMap=109,Des="第9章",Asset="0081",}},
        {91,new Cfg_Chapter() {Id=91,Name="豫州",StartMap=100,NeedMap=110,Des="第10章",Asset="0091",}},
        {101,new Cfg_Chapter() {Id=101,Name="益州",StartMap=100,NeedMap=0,Des="第11章",Asset="0101",}},
        {111,new Cfg_Chapter() {Id=111,Name="青州",StartMap=100,NeedMap=300,Des="第12章",Asset="0111",}},
    };
    public static Cfg_Chapter GetCfg(int index)
    {
        return IdList[index];
    }
    public static List<Cfg_Chapter> GetAllCfg()
    {
        return IdList.Values.ToList();
    }
}