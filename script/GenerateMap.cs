using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject BrickRootObj;
    public Transform BasePos;
    public float distanceX = 1.01f;
    public float distanceY;
    public int Rows = 6;
    public int Columns = 8;

    private static int currentMapId = 0;
    /// <summary>
    /// 当前地图ID,为0时自动退出地图
    /// </summary>
    public static int CurrentMapId
    {
        get { return currentMapId; }
        set
        {
            if (currentMapId != value)
            {
                currentMapId = value;
                if(value == 0) { GameEvent._OnExitMap();return; }
                GameEvent._OnMapChanged(value);
            }
        }
    }

    void Awake()
    {
        GameEvent.OnMapChanged += GenMap;
        GameEvent.OnExitMap += ExitMap;
    }

    void ExitMap()
    {
        transform.parent.gameObject.SetActive(false);
        UIBase.CloseUI(UIBase.UI_GamePanel);
        UIBase.OpenUI(UIBase.UI_ChapterPanel);
    }

    public void GenMap(int MapId)
    {
        transform.parent.gameObject.SetActive(true);
        UIBase.OpenUI(UIBase.UI_GamePanel);
        List<BrickRoot> brickList = new List<BrickRoot>();
        //清除已存在的砖块
        for (int i = 0; i < transform.childCount; i++)
        {
            var obj = transform.GetChild(i);
            if (obj != BasePos) Destroy(obj.gameObject);
        }
        //开始生成
        GameObject _mBrickBoot;
        for (int column = 0; column < Columns; column++)
        {
            for (int row = 0; row < Rows; row++)
            {
                _mBrickBoot = Instantiate(BrickRootObj, transform);
                _mBrickBoot.transform.localPosition = BasePos.localPosition + new Vector3(row * distanceX, column * distanceY, 0);
                BrickRoot brickRoot = _mBrickBoot.GetComponent<BrickRoot>();
                brickList.Add(brickRoot);
            }
        }
        //生成怪物和装备
        Monster.MapGenMonster(brickList, MapId);
    }


}
