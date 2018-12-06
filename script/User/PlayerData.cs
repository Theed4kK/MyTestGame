using System;
using System.Collections;
using System.Collections.Generic;


public class PlayerData
{
    //构造函数
    public PlayerData()
    {
        GameEvent.OnLevelChanged += ChangePlayerAttrOfLevel;
        if (Level == 0) Level = 1;
    }

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
    }



    private int exp = 0;//当前经验
    public int Exp
    {
        get { return exp; }
        set
        {
            if (exp != value)
            {
                exp = value;
                GameEvent._OnExpChanged(value);
            }
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
        set { if (attack != value) { attack = value; } GameEvent._OnAttrChanged(this); }
    }
    private int defense = 0;
    public int Defense
    {
        get { return defense; }
        set { if (defense != value) { defense = value; } GameEvent._OnAttrChanged(this); }
    }
    private int blood;
    public int Blood
    {
        get { return blood; }
        set { if (blood != value) { blood = value; } GameEvent._OnAttrChanged(this); }
    }



}
