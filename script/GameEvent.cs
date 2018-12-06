public delegate void LevelChange(int level);
public delegate void expChanged(int exp);
public delegate void AttrChanged(PlayerAttr attr);
public delegate void MapChanged(int mapId);
public delegate void ExitMap();

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
    public static void _OnExpChanged(int exp)
    {
        if (OnExpChanged != null)
        {
            OnExpChanged(exp);
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
        if (OnMapChanged != null)
        {
            OnExitMap();
        }
    }

}

