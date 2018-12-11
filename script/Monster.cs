using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Monster : MonoBehaviour
{
    public static void MapGenMonster(List<BrickRoot> brickRoots, int mapId)
    {
        int ruleId = Cfg_Map.GetCfg(mapId).GenMonsterRule;
        Cfg_GenMon cfg_GenMon = Cfg_GenMon.GetCfg(ruleId);
        //怪物ID列表
        List<int> monsterList = new List<int>();
        //掉落列表
        List<int> dropList = new List<int>();
        for (int i = 0; i < 100; i++)
        {
            switch (cfg_GenMon.Type)
            {
                case 0:
                    monsterList.Add(cfg_GenMon.Parameter);
                    break;
                case 1:
                    dropList.Add(cfg_GenMon.Parameter);
                    break;
            }
            if (cfg_GenMon.NextRule != 0)
            {
                cfg_GenMon = Cfg_GenMon.GetCfg(cfg_GenMon.NextRule);
            }
            else
            {
                break;
            }
        }
        //生成怪物
        List<BrickRoot> bricks = GenBrickMonster(brickRoots, monsterList);
        //生成装备
        GenBrickEquip(bricks, dropList);



    }

    private static void GenBrickEquip(List<BrickRoot> bricks, List<int> dropList)
    {
        int brickNum = bricks.Count;
        for (int i = 0; i < bricks.Count; i++)
        {
            if (COMMON.RandomIsSuccess(dropList.Count, brickNum))
            {
                bricks[i].GenEquip(dropList[0]);
                dropList.RemoveAt(0);
                bricks.RemoveAt(i);
            }
            brickNum -= 1;
            if(dropList.Count == 0) { break; }
        }
    }

    /// <summary>
    /// 生成怪物
    /// </summary>
    /// <param name="brickRoots">所有砖块列表</param>
    /// <param name="monsters">怪物ID列表</param>
    /// <returns></returns>
    private static List<BrickRoot> GenBrickMonster(List<BrickRoot> brickRoots, List<int> monsters)
    {
        //对砖块进行随机排序
        List<BrickRoot> bricks = COMMON.RandomSortList(brickRoots);
        int brickNum = brickRoots.Count;
        for (int i=0;i< bricks.Count;i++)
        {
            if (COMMON.RandomIsSuccess(monsters.Count, brickNum))
            {
                bricks[i].GenMonster(monsters[0]);
                monsters.RemoveAt(0);
                bricks.RemoveAt(i);
            }
            brickNum -= 1;
            if(monsters.Count == 0) { break; }
        }
        return bricks;
    }
}


public class MonsterAttr
{
    private int attack = 0;
    public int Attack
    {
        get { return attack; }
        set { if (attack != value) { attack = value; } GameEvent._OnMonsterAttrChanged(this); }
    }

    private int blood = 0;
    public int Blood
    {
        get { return blood; }
        set { if (blood != value) { blood = value; } GameEvent._OnMonsterAttrChanged(this); }
    }

    public static MonsterAttr TransToAttr(Cfg_NPC cfg_NPC)
    {
        MonsterAttr monsterAttr = new MonsterAttr
        {
            Attack = cfg_NPC.Attack,
            Blood = cfg_NPC.Blood
        };
        return monsterAttr;
    }
}
