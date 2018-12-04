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
    public int Rows=6;
    public int Columns = 8;

    // Use this for initialization


    public static int AlreadyGenNum;    //当前地图已生成的怪物数量
    public static int CurrentMapId;     //当前地图ID

    void Start()
    {
        GenMap(100);
    }

    public void GenMap(int MapId)
    {
        //生成地图时重置当前地图ID和当前地图已生成怪物数量
        CurrentMapId = MapId;
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
                
                if(GenMonster(_mBrickBoot)) Debug.LogFormat("第{0}行第{1}列有怪", row, column);
            }
        }
    }


    //破坏砖块时生成怪物
    public bool GenMonster(GameObject brickRootObj)
    {
        int MonsterId1 = Cfg_Map.GetCfg(CurrentMapId).MonsterId_01;        //怪物1ID
        int Monster1_pro = Cfg_Map.GetCfg(CurrentMapId).MonsterWeight_01;  //怪物1出现权重
        int MonsterId2 = Cfg_Map.GetCfg(CurrentMapId).MonsterId_02;        //怪物2ID
        int Monster2_pro = Cfg_Map.GetCfg(CurrentMapId).MonsterWeight_02;  //怪物2出现权重
        int Monster_Pro = Monster1_pro + Monster2_pro;              //权重总和
        int MaxGenMonNum = Cfg_Map.GetCfg(CurrentMapId).MaxMonsterNum;     //最大生成怪物数量

        BrickRoot brickRoot = brickRootObj.GetComponent<BrickRoot>();
        SpriteRenderer modelIcon = brickRoot.modelIcon;

        //如果已生成怪物数量未达到地图最大怪物数量且本次生成概率判断通过
        if (GenerateMap.AlreadyGenNum < MaxGenMonNum && COMMON.RandomIsSuccess(COMMON.GenMonsterPro, 10000))
        {
            GenerateMap.AlreadyGenNum += 1;
            brickRoot.IsMonster = true;
            if (COMMON.RandomIsSuccess(Monster1_pro, Monster_Pro))
            {
                string monsterAsset = COMMON.MonsterIconPath + Cfg_NPC.GetCfg(MonsterId1).AssetName;
                COMMON.SetSprite(modelIcon, monsterAsset);
            }
            else
            {
                string monsterAsset = COMMON.MonsterIconPath + Cfg_NPC.GetCfg(MonsterId2).AssetName;
                COMMON.SetSprite(modelIcon, monsterAsset);
            }
            return true;
        }
        return false;

    }




}
