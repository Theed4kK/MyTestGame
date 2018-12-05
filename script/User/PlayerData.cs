using System;
using System.Collections;
using System.Collections.Generic;


public class PlayerData
{
    //构造函数
    public PlayerData()
    {
        OnLevelChanged += ChangePlayerAttrOfLevel;
    }

    public delegate void LevelChange(int level);
    public event LevelChange OnLevelChanged;
    private int level = 0;//等级
    public int Level
    {
        get
        {
            if (level == 0)
            {
                OnLevelChanged(1);
                level = 1;
            }
            return level;
        }
        set
        {
            if (level != value) OnLevelChanged(value);
            level = value;
        }
    }

    private void ChangePlayerAttrOfLevel(int level)
    {
        Cfg_Level levelCfg = Cfg_Level.GetCfg(level);
        Attack += levelCfg.AddAttack;
        Blood += levelCfg.AddBlood;
    }


    public delegate void expChanged(int exp);
    public event expChanged OnExpChanged;
    private int exp = 0;//当前经验
    public int Exp
    {
        get { return exp; }
        set
        {
            if (exp != value) OnExpChanged(value);
            exp = IfCanLevelUp(value);
        }
    }

    private int IfCanLevelUp(int value)
    {
        Cfg_Level cfg_Level = Cfg_Level.GetCfg(Level);
        if (value >= cfg_Level.NeedExp)
        {
            Level = Level + 1;
            return value - cfg_Level.NeedExp;
        }
        else
        {
            return value;
        }
    }

    private int attack = 1;//攻击
    public int Attack
    {
        get { return attack; }
        set
        {
            if (attack != value)
                attack = value;
        }
    }
    private int blood = 100;//血量
    public int Blood
    {
        get { return blood; }
        set
        {
            blood = value;
        }
    }

    //道具信息,ID、数量
    public List<item> ItemData = new List<item>();
}

public struct item
{
    public int itemId, itemNum;
}
