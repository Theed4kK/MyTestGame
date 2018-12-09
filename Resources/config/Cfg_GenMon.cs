using System.Collections.Generic;
using System.Linq;

public class Cfg_GenMon
{
    public int Id;public int MonsterId;public int GenPro;public int NextRule;
    public static Dictionary<int,Cfg_GenMon> IdList = new Dictionary<int,Cfg_GenMon>() {
        {100,new Cfg_GenMon() {Id=100,MonsterId=1002,GenPro=15000,NextRule=101,}},
        {101,new Cfg_GenMon() {Id=101,MonsterId=1002,GenPro=5000,NextRule=102,}},
        {102,new Cfg_GenMon() {Id=102,MonsterId=1002,GenPro=5000,NextRule=103,}},
        {103,new Cfg_GenMon() {Id=103,MonsterId=1002,GenPro=5000,NextRule=104,}},
        {104,new Cfg_GenMon() {Id=104,MonsterId=1002,GenPro=5000,NextRule=105,}},
        {105,new Cfg_GenMon() {Id=105,MonsterId=1002,GenPro=5000,NextRule=106,}},
        {106,new Cfg_GenMon() {Id=106,MonsterId=1002,GenPro=5000,NextRule=107,}},
        {107,new Cfg_GenMon() {Id=107,MonsterId=1002,GenPro=5000,NextRule=108,}},
        {108,new Cfg_GenMon() {Id=108,MonsterId=1002,GenPro=5000,NextRule=109,}},
        {109,new Cfg_GenMon() {Id=109,MonsterId=1002,GenPro=5000,NextRule=110,}},
        {110,new Cfg_GenMon() {Id=110,MonsterId=1002,GenPro=5000,NextRule=200,}},
        {200,new Cfg_GenMon() {Id=200,MonsterId=1002,GenPro=5000,NextRule=300,}},
        {300,new Cfg_GenMon() {Id=300,MonsterId=1002,GenPro=5000,NextRule=400,}},
        {400,new Cfg_GenMon() {Id=400,MonsterId=1002,GenPro=5000,NextRule=0,}},
    };
    public static Cfg_GenMon GetCfg(int index)
    {
        return IdList[index];
    }
    public static List<Cfg_GenMon> GetAllCfg()
    {
        return IdList.Values.ToList();
    }
}