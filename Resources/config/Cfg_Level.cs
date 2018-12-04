using System.Collections.Generic;

public class Cfg_Level
{
    public int Lv;public int NeedExp;public int AddAttack;public int AddBlood;
    public static Dictionary<int,Cfg_Level> IdList = new Dictionary<int,Cfg_Level>() {
        {1,new Cfg_Level() {Lv=1,NeedExp=100,AddAttack=100,AddBlood=1000,}},
        {2,new Cfg_Level() {Lv=2,NeedExp=1000,AddAttack=200,AddBlood=2000,}},
        {3,new Cfg_Level() {Lv=3,NeedExp=5000,AddAttack=300,AddBlood=3000,}},
        {4,new Cfg_Level() {Lv=4,NeedExp=10000,AddAttack=400,AddBlood=4000,}},
        {5,new Cfg_Level() {Lv=5,NeedExp=20000,AddAttack=500,AddBlood=5000,}},
        {6,new Cfg_Level() {Lv=6,NeedExp=40000,AddAttack=600,AddBlood=6000,}},
        {7,new Cfg_Level() {Lv=7,NeedExp=80000,AddAttack=700,AddBlood=7000,}},
        {8,new Cfg_Level() {Lv=8,NeedExp=130000,AddAttack=800,AddBlood=8000,}},
        {9,new Cfg_Level() {Lv=9,NeedExp=180000,AddAttack=900,AddBlood=9000,}},
        {10,new Cfg_Level() {Lv=10,NeedExp=260000,AddAttack=1000,AddBlood=10000,}},
        {11,new Cfg_Level() {Lv=11,NeedExp=320000,AddAttack=1100,AddBlood=11000,}},
        {12,new Cfg_Level() {Lv=12,NeedExp=385000,AddAttack=1200,AddBlood=12000,}},
        {13,new Cfg_Level() {Lv=13,NeedExp=450000,AddAttack=1300,AddBlood=13000,}},
        {14,new Cfg_Level() {Lv=14,NeedExp=515000,AddAttack=1400,AddBlood=14000,}},
        {15,new Cfg_Level() {Lv=15,NeedExp=580000,AddAttack=1500,AddBlood=15000,}},
        {16,new Cfg_Level() {Lv=16,NeedExp=645000,AddAttack=1600,AddBlood=16000,}},
        {17,new Cfg_Level() {Lv=17,NeedExp=710000,AddAttack=1700,AddBlood=17000,}},
        {18,new Cfg_Level() {Lv=18,NeedExp=775000,AddAttack=1800,AddBlood=18000,}},
        {19,new Cfg_Level() {Lv=19,NeedExp=840000,AddAttack=1900,AddBlood=19000,}},
        {20,new Cfg_Level() {Lv=20,NeedExp=905000,AddAttack=2000,AddBlood=20000,}},
    };
    public static Cfg_Level GetCfg(int index)
    {
        return IdList[index];
    }
}