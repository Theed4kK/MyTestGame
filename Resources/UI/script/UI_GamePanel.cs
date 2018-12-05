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

    private PlayerData PlayerData;

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
        GenerateMap.CurrentMapId = Cfg_Map.GetCfg(GenerateMap.CurrentMapId).NextMap;
    }

    void SetMapNameText(int mapId)
    {
        if (mapId == 0) return;
        MapNameText.text = Cfg_Map.GetCfg(mapId).Name;
    }
    void SetLevelText(int level)
    {
        LevelText.text = "Lv."+ GameDataManager.PlayerData.Level.ToString();
    }
    void SetPlayerAttrText(int attack,int blood)
    {
        AttText.text = attack.ToString();
        bloodText.text = blood.ToString();
    }

    public void Init()
    {
        PlayerData = GameDataManager.PlayerData;
        GenerateMap.OnMapChanged += SetMapNameText;
        PlayerData.OnLevelChanged += SetLevelText;

    }

}
