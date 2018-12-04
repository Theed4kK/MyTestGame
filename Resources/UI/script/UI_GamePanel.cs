using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamePanel : MonoBehaviour
{
    [Header("图片")]
    public Image RoleIcon;

    [Header("文本信息")]
    public Text bloodText;
    public Text AttText;
    public Text LevelText;
    public Text MapNameText;


    [Header("按钮")]
    public Button BagBtn;
    public Button NextDgnBtn;

    // Use this for initialization
    void Start()
    {

        Init();

        //背包按钮事件（打开背包界面）
        BagBtn.onClick.AddListener(delegate ()
        {
            //UIBase.OpenUI(UIBase.UI_BagPanel);
            UIBase.OpenUI(UIBase.UI_BagPanel);
        });

        NextDgnBtn.onClick.AddListener(GoNextMap);
    }

    void GoNextMap()
    {
        SetMapNameText();
        int NextMapId = Cfg_Map.GetCfg(GenerateMap.CurrentMapId).NextMap;
        
    }

    void SetMapNameText()
    {
        if (GenerateMap.CurrentMapId == 0) return;
        MapNameText.text = Cfg_Map.GetCfg(GenerateMap.CurrentMapId).Name;
    }
    void SetLevelText()
    {
        LevelText.text = "Lv."+ GameDataManager.PlayerData.Level.ToString();
    }
    void SetPlayerAttrText()
    {
        AttText.text = GameDataManager.PlayerData.attack.ToString();
        bloodText.text = GameDataManager.PlayerData.blood.ToString();
    }

    public void Init()
    {
        SetMapNameText();
        SetLevelText();
        SetPlayerAttrText();

    }

}
