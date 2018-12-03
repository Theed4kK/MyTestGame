using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{

    // Use this for initialization
    public GameObject equip;
    public GameObject monster;
    public GameObject brick;

    public Dictionary<PlayerData.AttrType, int> PlayerAttr;

    void Start()
    {
        PlayerAttr = GameDataManager.PlayerData.PlayerAttr;

    }

    private void OnMouseUp()
    {
        if (brick.activeSelf)
        {
            brick.SetActive(false);
            equip.SetActive(false);
            monster.SetActive(true);
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
        TextMesh bloodText = monster.transform.Find("blood").GetComponent<TextMesh>();
        int bloodNum = int.Parse(bloodText.text);
        bloodNum = bloodNum - PlayerAttr[PlayerData.AttrType.attack];
        bloodText.text = bloodNum > 0 ? bloodNum.ToString() : "0";
        if (bloodNum > 0) { return false; } else { return true; }
    }
}
