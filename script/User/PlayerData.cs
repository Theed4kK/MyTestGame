using System;
using System.Collections;
using System.Collections.Generic;


public class PlayerData
{

    public bool IsStartPractice = false;    //是否已经开始修炼
    public int Qualifications = 0;  //资质


    private int level = 0;//等级
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            if (level != value)
            {
                level = value;
                GameEvent._OnLevelChanged(value);
            }
        }
    }

    private void ChangePlayerAttrOfLevel(int level)
    {
        Cfg_Level levelCfg = Cfg_Level.GetCfg(level);
        Attr.Attack += levelCfg.AddAttack;
        Attr.Blood += levelCfg.AddBlood;
        Attr.Defense += levelCfg.AddDefense;
    }

    private List<int> alreadyPass = new List<int>() { 0 };
    public List<int> AlreadyPass
    {
        get { return alreadyPass; }
        set { alreadyPass = value; }
    }


    private float exp = 0;//当前经验
    /// <summary>
    /// 玩家当前经验
    /// </summary>
    public float Exp
    {
        get { return exp; }
        set
        {
            if (exp != value)
            {
                float addexp = value - exp;
                exp = IfCanLevelUp(value);
                GameEvent._OnExpChanged(value, addexp);
            }
        }
    }

    private float IfCanLevelUp(float value)
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


    private PlayerAttr attr = new PlayerAttr();
    public PlayerAttr Attr
    {
        get { return attr; }
        set
        {
            if (!attr.Equals(value))
            {
                attr = value;
                GameEvent._OnAttrChanged(value);
            }
        }
    }

    //道具信息,ID、数量
    private List<Item> itemData = new List<Item>();
    public List<Item> ItemData
    {
        get
        {
            return itemData;
        }
        set
        {
            itemData = value;
        }
    }
}

public class Item
{
    public int itemId, itemNum;
}

public class PlayerAttr
{
    private int attack = 0;
    public int Attack
    {
        get { return attack; }
        set
        {
            if (attack != value)
            {
                attack = value;
                GameEvent._OnAttrChanged(this);
            }
        }
    }
    private int defense = 0;
    public int Defense
    {
        get { return defense; }
        set
        {
            if (defense != value)
            {
                defense = value;
                GameEvent._OnAttrChanged(this);
            }
        }
    }
    private int blood;
    public int Blood
    {
        get { return blood; }
        set
        {
            if (blood != value)
            {
                blood = value;
                GameEvent._OnAttrChanged(this);
                if(value <= 0)
                {
                    GameEvent._OnPlayerDie();
                }
            }
        }
    }
}
