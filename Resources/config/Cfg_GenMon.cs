using System.Collections.Generic;
using System.Linq;

public class Cfg_GenMon
{
    public int Id;public int Type;public int Parameter;public int NextRule;
    public static Dictionary<int,Cfg_GenMon> IdList = new Dictionary<int,Cfg_GenMon>() {
        {100,new Cfg_GenMon() {Id=100,Type=0,Parameter=1000,NextRule=101,}},
        {101,new Cfg_GenMon() {Id=101,Type=0,Parameter=1001,NextRule=102,}},
        {102,new Cfg_GenMon() {Id=102,Type=0,Parameter=1002,NextRule=103,}},
        {103,new Cfg_GenMon() {Id=103,Type=0,Parameter=1003,NextRule=104,}},
        {104,new Cfg_GenMon() {Id=104,Type=0,Parameter=2000,NextRule=105,}},
        {105,new Cfg_GenMon() {Id=105,Type=0,Parameter=2001,NextRule=106,}},
        {106,new Cfg_GenMon() {Id=106,Type=0,Parameter=2002,NextRule=107,}},
        {107,new Cfg_GenMon() {Id=107,Type=0,Parameter=2003,NextRule=108,}},
        {108,new Cfg_GenMon() {Id=108,Type=0,Parameter=3000,NextRule=109,}},
        {109,new Cfg_GenMon() {Id=109,Type=0,Parameter=3001,NextRule=110,}},
        {110,new Cfg_GenMon() {Id=110,Type=1,Parameter=100,NextRule=200,}},
        {200,new Cfg_GenMon() {Id=200,Type=1,Parameter=101,NextRule=300,}},
        {300,new Cfg_GenMon() {Id=300,Type=1,Parameter=102,NextRule=400,}},
        {400,new Cfg_GenMon() {Id=400,Type=1,Parameter=103,NextRule=0,}},
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