using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrickRoot : MonoBehaviour
{
    public GameObject equip;    //装备节点
    public GameObject equipItem;    //装备子节点
    public GameObject monster;  //怪物节点
    public GameObject brick;    //砖块表层节点
    public TextMeshPro bloodText;  //怪物血量显示文本
    public TextMeshPro attackText; //怪物攻击显示文本
    public TextMeshPro defenseText; //怪物防御显示文本
    public SpriteRenderer modelIcon;    //怪物模型sprite

    private Cfg_NPC NPC_Info;       //本砖块的怪物配置
    private List<int> equipList;
    private List<GameObject> equipObjList;

    private MonsterAttr monsterAttr;    //本砖块的怪物当前属性，用来战斗计算

    private BrickState currentState;    //砖块当前显示状态

    //readonly PlayerData playerData = GameDataManager.PlayerData;

    /// <summary>
    /// 点击砖块
    /// </summary>
    public void BeClicked()
    {
        switch (currentState)
        {
            case BrickState.initial:
                if (NPC_Info != null)
                {
                    SetBrickState(BrickState.monster);
                }
                else
                {
                    if (equipList != null)
                    {
                        SetBrickState(BrickState.equip);
                    }
                    else
                    {
                        SetBrickState(BrickState.Empty);
                    }
                }
                break;
            case BrickState.monster:
                InteractiveWithNpc();       //与NPC交互（对话、攻击或其他）
                break;
            case BrickState.equip:
                if (PickUpItem())
                {
                    SetBrickState(BrickState.Empty);
                }
                break;
        }
    }

    /// <summary>
    /// 拾取道具，全部拾取完之后返回true
    /// </summary>
    /// <returns></returns>
    private bool PickUpItem()
    {
        PlayerDataChange.GetItem(equipList[0]);
        string tips = Cfg_Item.GetCfg(equipList[0]).ItemName;
        tips = COMMON.SetStrColor(tips, Cfg_Item.GetCfg(equipList[0]).Color);
        UIBase.Addtips("恭喜您获得" + tips + "!");
        equipObjList[0].SetActive(false);

        equipList.RemoveAt(0);
        equipObjList.RemoveAt(0);
        if (equipObjList.Count == 0)
        {
            return true;
        }
        equipObjList[0].SetActive(true);
        return false;
    }

    private void OnEnable()
    {
        SetBrickState(BrickState.initial);
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

    //砖块显示状态枚举
    public enum BrickState
    {
        initial,    ///初始
        monster,    ///有怪
        equip,      ///有装备
        Empty       ///什么都没有
    }

    void AttackMonster()
    {
        Fight.FightWithMonster(monsterAttr);
    }

    /// <summary>
    /// 生成装备
    /// </summary>
    /// <param name="dropId">掉落ID</param>
    public void GenEquip(int dropId)
    {
        Cfg_Drop cfg_Drop = Cfg_Drop.GetCfg(dropId);
        int maxDropNum = cfg_Drop.MaxDrop;
        int alreadyDrop = 0;
        double dropNum = 0;
        double dropPro;
        equipList = new List<int>();
        for (int i = 0; i < 100; i++)
        {
            if (alreadyDrop >= maxDropNum) { break; }
            dropPro = cfg_Drop.DropPro / 10000;
            dropNum = Math.Floor(dropPro);
            for (int j = 0; j < dropNum; j++)
            {
                equipList.Add(cfg_Drop.DropItem);
                alreadyDrop += 1;
            }
            if (COMMON.RandomIsSuccess(cfg_Drop.DropPro % 10000, 10000))
            {
                equipList.Add(cfg_Drop.DropItem);
                alreadyDrop += 1;
            }
            if (cfg_Drop.NextDrop != 0)
            {
                cfg_Drop = Cfg_Drop.GetCfg(cfg_Drop.NextDrop);
            }
            else
            {
                break;
            }
        }
        //生成道具物体
        GenEquipItem(equipList);
    }

    private void GenEquipItem(List<int> equipList)
    {
        equipItem.SetActive(true);
        equipObjList = new List<GameObject>();
        int index = 0;
        foreach (var i in equipList)
        {
            Cfg_Item cfg_Item = Cfg_Item.GetCfg(i);
            string AssetName = COMMON.ItemIconPath + cfg_Item.AssetName;
            GameObject equip = Instantiate(equipItem, equipItem.transform.parent);
            equipObjList.Add(equip);
            SpriteRenderer itemSprite = equip.GetComponent<SpriteRenderer>();
            COMMON.SetSprite(itemSprite, AssetName);
            itemSprite.material = COMMON.spriteMaterials[cfg_Item.Color];
            equip.SetActive(index == 0);
            index++;
        }
        equipItem.SetActive(false);
    }

    //砖块生成怪物
    public void GenMonster(int monsterId)
    {
        NPC_Info = Cfg_NPC.GetCfg(monsterId);
        if (NPC_Info.AppearOnStart == 1)
        {
            SetBrickState(BrickState.monster);
        }
        monsterAttr = new MonsterAttr();
        monsterAttr.GameEvent.OnMonsterAttrChanged += SetMonsterAttrShow;
        monsterAttr.GameEvent.OnMonsterDie += MonsterDie;
        MonsterAttr.TransToAttr(NPC_Info, ref monsterAttr);
        //设置怪物图片和颜色
        string monsterAsset = COMMON.MonsterIconPath + NPC_Info.AssetName;
        COMMON.SetSprite(modelIcon, monsterAsset);
        modelIcon.material = COMMON.spriteMaterials[NPC_Info.Color];
    }

    //设置怪物血量和攻击显示
    void SetMonsterAttrShow(MonsterAttr monsterAttr)
    {
        bloodText.transform.parent.gameObject.SetActive(monsterAttr.Blood != 0);
        attackText.transform.parent.gameObject.SetActive(monsterAttr.Attack != 0);
        bloodText.text = monsterAttr.Blood == -1 ? "???" : monsterAttr.Blood.ToString();
        attackText.text = monsterAttr.Attack == -1 ? "???" : monsterAttr.Attack.ToString();
    }


    void MonsterDie()
    {
        if (NPC_Info.DropId != 0)
        {
            GenEquip(NPC_Info.DropId);
            SetBrickState(BrickState.equip);
        }
        else
        {
            SetBrickState(BrickState.Empty);
        }
    }

}

