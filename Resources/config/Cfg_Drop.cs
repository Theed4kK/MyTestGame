using System.Collections.Generic;
using System.Linq;

public class Cfg_Drop
{
    public int Id;public int DropItem;public int DropPro;public int MaxDrop;public int NextDrop;
    public static Dictionary<int,Cfg_Drop> IdList = new Dictionary<int,Cfg_Drop>() {
        {100,new Cfg_Drop() {Id=100,DropItem=100,DropPro=1000,MaxDrop=5,NextDrop=101,}},
        {101,new Cfg_Drop() {Id=101,DropItem=101,DropPro=1000,MaxDrop=5,NextDrop=102,}},
        {102,new Cfg_Drop() {Id=102,DropItem=200,DropPro=1000,MaxDrop=5,NextDrop=103,}},
        {103,new Cfg_Drop() {Id=103,DropItem=201,DropPro=1000,MaxDrop=5,NextDrop=104,}},
        {104,new Cfg_Drop() {Id=104,DropItem=100,DropPro=1000,MaxDrop=5,NextDrop=105,}},
        {105,new Cfg_Drop() {Id=105,DropItem=101,DropPro=1000,MaxDrop=5,NextDrop=106,}},
        {106,new Cfg_Drop() {Id=106,DropItem=200,DropPro=1000,MaxDrop=5,NextDrop=107,}},
        {107,new Cfg_Drop() {Id=107,DropItem=201,DropPro=1000,MaxDrop=5,NextDrop=108,}},
        {108,new Cfg_Drop() {Id=108,DropItem=100,DropPro=1000,MaxDrop=5,NextDrop=109,}},
        {109,new Cfg_Drop() {Id=109,DropItem=101,DropPro=1000,MaxDrop=5,NextDrop=110,}},
        {110,new Cfg_Drop() {Id=110,DropItem=200,DropPro=1000,MaxDrop=5,NextDrop=111,}},
        {111,new Cfg_Drop() {Id=111,DropItem=201,DropPro=1000,MaxDrop=5,NextDrop=112,}},
        {112,new Cfg_Drop() {Id=112,DropItem=100,DropPro=1000,MaxDrop=5,NextDrop=113,}},
        {113,new Cfg_Drop() {Id=113,DropItem=101,DropPro=1000,MaxDrop=5,NextDrop=114,}},
        {114,new Cfg_Drop() {Id=114,DropItem=200,DropPro=1000,MaxDrop=5,NextDrop=115,}},
        {115,new Cfg_Drop() {Id=115,DropItem=201,DropPro=1000,MaxDrop=5,NextDrop=116,}},
        {116,new Cfg_Drop() {Id=116,DropItem=100,DropPro=1000,MaxDrop=5,NextDrop=117,}},
        {117,new Cfg_Drop() {Id=117,DropItem=101,DropPro=1000,MaxDrop=5,NextDrop=118,}},
        {118,new Cfg_Drop() {Id=118,DropItem=200,DropPro=1000,MaxDrop=5,NextDrop=119,}},
        {119,new Cfg_Drop() {Id=119,DropItem=201,DropPro=1000,MaxDrop=5,NextDrop=120,}},
        {120,new Cfg_Drop() {Id=120,DropItem=201,DropPro=1000,MaxDrop=5,NextDrop=0,}},
    };
    public static Cfg_Drop GetCfg(int index)
    {
        return IdList[index];
    }
    public static List<Cfg_Drop> GetAllCfg()
    {
        return IdList.Values.ToList();
    }
}