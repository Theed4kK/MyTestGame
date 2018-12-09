using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrickRoot : MonoBehaviour
{

    // Use this for initialization
    public GameObject equip;
    public GameObject monster;
    public GameObject brick;
    public TextMesh bloodText;
    public TextMesh attackText;
    public SpriteRenderer modelIcon;

    private Cfg_NPC NPC_Info;       //本砖块的怪物配置
    int currentMonsterId;
    int monsterCurrentBlood;    //本砖块怪物的当前血量
    int MonsterCurrentBlood
    {
        get { return monsterCurrentBlood; }
        set
        {
            if (value <= 0) monster.SetActive(false);
            if (monsterCurrentBlood != value)
            {
                bloodText.text = value.ToString();
            }
            monsterCurrentBlood = value;
        }
    }
    int monsterCurrentAttack;
    int MonsterCurrentAttack    //本砖块怪物的当前血量
    {
        get { return monsterCurrentAttack; }
        set
        {
            if (monsterCurrentAttack != value)
            {
                attackText.text = value.ToString();
            }
            monsterCurrentAttack = value;
        }
    }

    private BrickState currentState;    //砖块当前显示状态

    public void BeClicked()
    {
        switch (currentState)
        {
            case BrickState.initial:
                if (NPC_Info != null) SetBrickState(BrickState.monster); else SetBrickState(BrickState.Empty);
                break;
            case BrickState.monster:
                InteractiveWithNpc();       //与NPC交互（对话、攻击或其他）
                break;
            case BrickState.equip:
                //PlayerDataChange.GetItem();

                break;
        }
    }
    

public void Init()
    {
        SetBrickState(BrickState.initial);
        GenMonster();
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
                break;
        }
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
        initial,    ///初始
        monster,    ///有怪
        equip,      ///有装备
        Empty       ///什么都没有
    }

    void AttackMonster()
    {
        PlayerData playerData = GameDataManager.PlayerData;
        MonsterCurrentBlood -= playerData.Attr.Attack;
        playerData.Attr.Blood -= MonsterCurrentAttack;
        if (playerData.Attr.Blood <= 0)
        {
            playerData.Attr.Blood = 0;
            GenerateMap.CurrentMapId = 0;
        }

    }

    //砖块生成怪物
    bool GenMonster()
    {
        //Cfg_Map MapCfg = Cfg_Map.GetCfg(GenerateMap.CurrentMapId);

        ////如果已生成怪物数量未达到地图最大怪物数量且本次生成概率判断通过
        //if (GenerateMap.AlreadyGenNum < MaxGenMonNum && COMMON.RandomIsSuccess(COMMON.GenMonsterPro, 10000))
        //{
        //    //地图生成怪物数量+1
        //    GenerateMap.AlreadyGenNum += 1;
        //    //该砖块有怪物
        //    if (COMMON.RandomIsSuccess(Monster1_pro, Monster_Pro))
        //    {
        //        currentMonsterId = MonsterId1;
        //    }
        //    else
        //    {
        //        currentMonsterId = MonsterId2;
        //    }
        //    NPC_Info = Cfg_NPC.GetCfg(currentMonsterId);
        //    //设置怪物图片
        //    string monsterAsset = COMMON.MonsterIconPath + NPC_Info.AssetName;
        //    COMMON.SetSprite(modelIcon, monsterAsset);
        //    modelIcon.material = COMMON.spriteMaterials[NPC_Info.Color];
        //    //设置怪物血量和攻击
        //    bloodText.text = NPC_Info.Blood.ToString();
        //    MonsterCurrentBlood = NPC_Info.Blood;
        //    MonsterCurrentAttack = NPC_Info.Attack;
        //    //生成装备
        //    GenEquip();
        //    return true;
        //}
        return false;
    }

    private void GenEquip()
    {

    }
}
