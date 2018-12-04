using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickRoot : MonoBehaviour
{

    // Use this for initialization
    public GameObject equip;
    public GameObject monster;
    public GameObject brick;
    public TextMesh bloodText;
    public SpriteRenderer modelIcon;

    private Cfg_NPC NPC_Info;       //本砖块的怪物配置
    private int MonsterCurrentBlood;    //本砖块怪物的当前血量

    private BrickState currentState;    //砖块当前显示状态

    void Init()
    {
        SetBrickState(BrickState.initial);
        GenMonster();
    }

    private void OnMouseUp()
    {
        switch (currentState)
        {
            case BrickState.initial:
                if (NPC_Info!=null) SetBrickState(BrickState.monster); else SetBrickState(BrickState.Empty);
                break;
            case BrickState.monster:
                InteractiveWithNpc();       //与NPC交互（对话、攻击或其他）
                break;
            case BrickState.equip:
                //PlayerDataChange.GetItem();

                break;
        }
    }

    void InteractiveWithNpc()
    {
        int monsterType = NPC_Info.Type;
        switch (monsterType)
        {
            case 1:
                //ShowDialog();
                break;
            case 2:
                AttackMonster();
                RefreshMonsterInfo();
                break;
        }
    }

    

    private void RefreshMonsterInfo()
    {
        bloodText.text = MonsterCurrentBlood.ToString();
    }


    //设置砖块显示状态
    void SetBrickState(BrickState brickState)
    {
        currentState = brickState;
        switch (brickState)
        {
            case BrickState.initial:
                brick.SetActive(true);
                monster.SetActive(false);
                equip.SetActive(false);
                break;
            case BrickState.monster:
                brick.SetActive(false);
                monster.SetActive(true);
                equip.SetActive(false);
                break;
            case BrickState.equip:
                brick.SetActive(false);
                monster.SetActive(false);
                equip.SetActive(true);
                break;
            case BrickState.Empty:
                brick.SetActive(false);
                monster.SetActive(false);
                equip.SetActive(false);
                break;
        }
    }

    //砖块显示状态
    public enum BrickState
    {
        initial,    //初始
        monster,    //有怪
        equip,      //有装备
        Empty       //什么都没有
    }

    bool AttackMonster()
    {
        int bloodNum = NPC_Info.Blood;
        bloodText.text = bloodNum > 0 ? bloodNum.ToString() : "0";
        if (bloodNum > 0) { return false; } else { return true; }
    }

    //破坏砖块时生成怪物
    bool GenMonster()
    {
        int MonsterId1 = Cfg_Map.GetCfg(GenerateMap.CurrentMapId).MonsterId_01;        //怪物1ID
        int Monster1_pro = Cfg_Map.GetCfg(GenerateMap.CurrentMapId).MonsterWeight_01;  //怪物1出现权重
        int MonsterId2 = Cfg_Map.GetCfg(GenerateMap.CurrentMapId).MonsterId_02;        //怪物2ID
        int Monster2_pro = Cfg_Map.GetCfg(GenerateMap.CurrentMapId).MonsterWeight_02;  //怪物2出现权重
        int Monster_Pro = Monster1_pro + Monster2_pro;              //权重总和
        int MaxGenMonNum = Cfg_Map.GetCfg(GenerateMap.CurrentMapId).MaxMonsterNum;     //最大生成怪物数量

        int currentMonsterId;
        //如果已生成怪物数量未达到地图最大怪物数量且本次生成概率判断通过
        if (GenerateMap.AlreadyGenNum < MaxGenMonNum && COMMON.RandomIsSuccess(COMMON.GenMonsterPro, 10000))
        {
            //地图生成怪物数量+1
            GenerateMap.AlreadyGenNum += 1;
            //该砖块有怪物
            if (COMMON.RandomIsSuccess(Monster1_pro, Monster_Pro))
            {
                currentMonsterId = MonsterId1;
            }
            else
            {
                currentMonsterId = MonsterId2;
            }
            NPC_Info = Cfg_NPC.GetCfg(currentMonsterId);
            //设置怪物图片
            string monsterAsset = COMMON.MonsterIconPath + NPC_Info.AssetName;
            COMMON.SetSprite(modelIcon, monsterAsset);
            modelIcon.material = COMMON.spriteMaterials[NPC_Info.Color];
            //设置怪物血量
            bloodText.text = NPC_Info.Blood.ToString();
            MonsterCurrentBlood = NPC_Info.Blood;
            return true;
        }
        return false;
    }


}
