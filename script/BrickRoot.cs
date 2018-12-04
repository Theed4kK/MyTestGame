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


    void Start()
    {

    }

    private void OnMouseUp()
    {
        if (brick.activeSelf)
        {
            brick.SetActive(false);
            equip.SetActive(false);
            if (IsMonster) monster.SetActive(true);
            return;
        }

        if (monster.activeSelf)
        {
            brick.SetActive(false);
            bool IsKilled = Attack();
            equip.SetActive(IsKilled);
            monster.SetActive(!IsKilled);
            return;
        }

        if (equip.activeSelf)
        {
            brick.SetActive(false);
            equip.SetActive(false);
            monster.SetActive(false);
            PlayerDataChange.GetItem(1,1);
            return;
        }
    }



    private bool Attack()
    {
        int bloodNum = int.Parse(bloodText.text);
        bloodText.text = bloodNum > 0 ? bloodNum.ToString() : "0";
        if (bloodNum > 0) { return false; } else { return true; }
    }

    


}
