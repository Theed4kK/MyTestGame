public delegate void LevelChange(int level);
public delegate void expChanged(float exp,float addExp);
public delegate void AttrChanged(PlayerAttr attr);
public delegate void MapChanged(int mapId);
public delegate void ExitMap();
public delegate void MonsterAttrChanged(MonsterAttr monsterAttr);
public delegate void PlayerDie();
public delegate void MonsterDie();

public class GameEvent
{
    //等级改变事件
    public static event LevelChange OnLevelChanged;
    //事件触发函数
    public static void _OnLevelChanged(int level)
    {
        if (OnLevelChanged != null)
        {
            OnLevelChanged(level);
        }
    }

    //经验改变事件
    public static event expChanged OnExpChanged;
    //事件触发函数
    public static void _OnExpChanged(float exp,float addExp)
    {
        if (OnExpChanged != null)
        {
            OnExpChanged(exp, addExp);
        }
    }

    //属性改变事件
    public static event AttrChanged OnAttrChanged;
    //事件触发函数
    public static void _OnAttrChanged(PlayerAttr playerAttr)
    {
        if (OnAttrChanged != null)
        {
            OnAttrChanged(playerAttr);
        }
    }

    //当前所在地图改变事件
    public static event MapChanged OnMapChanged;
    //事件触发函数
    public static void _OnMapChanged(int mapId)
    {
        if (OnMapChanged != null)
        {
            OnMapChanged(mapId);
        }
    }

    //当前所在地图变成0
    public static event ExitMap OnExitMap;
    //事件触发函数
    public static void _OnExitMap()
    {
        if (OnExitMap != null)
        {
            OnExitMap();
        }
    }

    //怪物属性变化
    public event MonsterAttrChanged OnMonsterAttrChanged;
    //事件触发函数
    public void _OnMonsterAttrChanged(MonsterAttr monsterAttr)
    {
        if (OnMonsterAttrChanged != null)
        {
            OnMonsterAttrChanged(monsterAttr);
        }
    }

    //玩家死亡事件
    public static event PlayerDie OnPlayerDie;
    //事件触发函数
    public static void _OnPlayerDie()
    {
        if (OnPlayerDie != null)
        {
            OnPlayerDie();
        }
    }

    //怪物死亡事件
    public event MonsterDie OnMonsterDie;
    //事件触发函数
    public void _OnMonsterDie()
    {
        if (OnMonsterDie != null)
        {
            OnMonsterDie();
        }
    }
}

