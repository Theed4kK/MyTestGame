using System.Collections.Generic;
using System.Linq;

public class Cfg_Level
{
    public int Lv;public string Name;public int NeedExp;public int AddAttack;public int AddBlood;public int AddDefense;public int AddExp;
    public static Dictionary<int,Cfg_Level> IdList = new Dictionary<int,Cfg_Level>() {
        {1,new Cfg_Level() {Lv=1,Name="凡境一段",NeedExp=100,AddAttack=100,AddBlood=1000,AddDefense=50,AddExp=1,}},
        {2,new Cfg_Level() {Lv=2,Name="凡境二段",NeedExp=1000,AddAttack=200,AddBlood=2000,AddDefense=100,AddExp=5,}},
        {3,new Cfg_Level() {Lv=3,Name="凡境三段",NeedExp=5000,AddAttack=300,AddBlood=3000,AddDefense=150,AddExp=10,}},
        {4,new Cfg_Level() {Lv=4,Name="凡境四段",NeedExp=10000,AddAttack=400,AddBlood=4000,AddDefense=200,AddExp=20,}},
        {5,new Cfg_Level() {Lv=5,Name="凡境五段",NeedExp=20000,AddAttack=500,AddBlood=5000,AddDefense=250,AddExp=30,}},
        {6,new Cfg_Level() {Lv=6,Name="凡境六段",NeedExp=40000,AddAttack=600,AddBlood=6000,AddDefense=300,AddExp=40,}},
        {7,new Cfg_Level() {Lv=7,Name="凡境七段",NeedExp=80000,AddAttack=700,AddBlood=7000,AddDefense=350,AddExp=50,}},
        {8,new Cfg_Level() {Lv=8,Name="凡境八段",NeedExp=130000,AddAttack=800,AddBlood=8000,AddDefense=400,AddExp=60,}},
        {9,new Cfg_Level() {Lv=9,Name="凡境九段",NeedExp=180000,AddAttack=900,AddBlood=9000,AddDefense=450,AddExp=70,}},
        {10,new Cfg_Level() {Lv=10,Name="凡境十段",NeedExp=260000,AddAttack=1000,AddBlood=10000,AddDefense=500,AddExp=80,}},
        {11,new Cfg_Level() {Lv=11,Name="凡境十一段",NeedExp=320000,AddAttack=1100,AddBlood=11000,AddDefense=550,AddExp=90,}},
        {12,new Cfg_Level() {Lv=12,Name="凡境十二段",NeedExp=385000,AddAttack=1200,AddBlood=12000,AddDefense=600,AddExp=100,}},
        {13,new Cfg_Level() {Lv=13,Name="通境1",NeedExp=450000,AddAttack=1300,AddBlood=13000,AddDefense=650,AddExp=110,}},
        {14,new Cfg_Level() {Lv=14,Name="通境1",NeedExp=515000,AddAttack=1400,AddBlood=14000,AddDefense=700,AddExp=120,}},
        {15,new Cfg_Level() {Lv=15,Name="通境1",NeedExp=580000,AddAttack=1500,AddBlood=15000,AddDefense=750,AddExp=130,}},
        {16,new Cfg_Level() {Lv=16,Name="通境1",NeedExp=645000,AddAttack=1600,AddBlood=16000,AddDefense=800,AddExp=140,}},
        {17,new Cfg_Level() {Lv=17,Name="通境1",NeedExp=710000,AddAttack=1700,AddBlood=17000,AddDefense=850,AddExp=150,}},
        {18,new Cfg_Level() {Lv=18,Name="通境1",NeedExp=775000,AddAttack=1800,AddBlood=18000,AddDefense=900,AddExp=160,}},
        {19,new Cfg_Level() {Lv=19,Name="通境1",NeedExp=840000,AddAttack=1900,AddBlood=19000,AddDefense=950,AddExp=170,}},
        {20,new Cfg_Level() {Lv=20,Name="通境1",NeedExp=905000,AddAttack=2000,AddBlood=20000,AddDefense=1000,AddExp=180,}},
    };
    public static Cfg_Level GetCfg(int index)
    {
        return IdList[index];
    }
    public static List<Cfg_Level> GetAllCfg()
    {
        return IdList.Values.ToList();
    }
}