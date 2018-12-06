﻿using System;
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

    // Use this for initialization


    public static int AlreadyGenNum;    //当前地图已生成的怪物数量

   private static int currentMapId = 0; //当前地图ID
    public static int CurrentMapId
    {
        get { return currentMapId; }
        set
        {
            if (currentMapId != value) currentMapId = value;  GameEvent._OnMapChanged(value); 
        }
    }

    void Awake()
    {
        if(CurrentMapId == 0) { transform.parent.gameObject.SetActive(false); }
        GameEvent.OnMapChanged += GenMap;
    }

    public void GenMap(int MapId)
    {
        transform.parent.gameObject.SetActive(true);
        //生成地图时重置当前地图已生成怪物数量
        AlreadyGenNum = 0;
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
                brickRoot.Init();
            }
        }
    }


}
