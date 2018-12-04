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

    [HideInInspector]
    public bool IsMonster =false ;
    public int MonsterId;

    private brickState currentState;


    void Start()
    {

    }

    private void OnMouseUp()
    {
        switch (currentState)
        {
            case brickState.initial:
                if (IsMonster) SetBrickState(brickState.monster); else SetBrickState(brickState.Empty);
                break;
            case brickState.monster:
                InteractiveWithNpc();       //与NPC交互（对话、攻击或其他）
                break;
            case brickState.equip:
                //PlayerDataChange.GetItem();
                break;
        }
    }

    private void InteractiveWithNpc()
    {
        throw new NotImplementedException();
    }

    //设置砖块显示状态
    public void SetBrickState(brickState brickState)
    {
        currentState = brickState;
        switch (brickState)
        {
            case brickState.initial:
                brick.SetActive(true);
                monster.SetActive(false);
                equip.SetActive(false);
                break;
            case brickState.monster:
                brick.SetActive(false);
                monster.SetActive(true);
                equip.SetActive(false);
                break;
            case brickState.equip:
                brick.SetActive(false);
                monster.SetActive(false);
                equip.SetActive(true);
                break;
            case brickState.Empty:
                brick.SetActive(false);
                monster.SetActive(false);
                equip.SetActive(false);
                break;
        }
    }

    //砖块显示状态
    public enum brickState
    {
        initial,    //初始
        monster,    //有怪
        equip,      //有装备
        Empty       //什么都没有
    }

    private bool Attack()
    {
        int bloodNum = int.Parse(bloodText.text);
        bloodText.text = bloodNum > 0 ? bloodNum.ToString() : "0";
        if (bloodNum > 0) { return false; } else { return true; }
    }

    


}
