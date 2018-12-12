using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamePanel : MonoBehaviour
{
    [Header("图片")]
    public Image RoleIcon;
    public Image RoleBg;

    [Header("文本信息")]
    public Text bloodText;
    public Text AttText;
    public Text LevelText;
    public Text MapNameText;
    public Text SystemLvText;
    public Text PlunderProValueText;
    public Text SystemLvUpText;

    [Header("按钮")]
    public Button BagBtn;
    public Button NextDgnBtn;

    private PlayerData PlayerData;

    // Use this for initialization
    void OnEnable()
    {
        Init();

        //背包按钮事件（打开背包界面）
        BagBtn.onClick.AddListener(delegate ()
        {
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
        LevelText.text = "Lv."+ level.ToString();
    }
    void SetPlayerAttrText(PlayerAttr playerAttr)
    {
        AttText.text = playerAttr.Attack.ToString();
        bloodText.text = playerAttr.Blood.ToString();
    }

    void ReturnChapterPanel()
    {
        UIBase.CloseUI(gameObject);
        UIBase.OpenUI(UIBase.UI_ChapterPanel);
    }

    /// <summary>
    /// 初始化界面，并且绑定事件
    /// </summary>
    void Init()
    {
        PlayerData = GameDataManager.PlayerData;
        GameEvent.OnMapChanged += SetMapNameText;
        GameEvent.OnAttrChanged += SetPlayerAttrText;
        GameEvent.OnLevelChanged += SetLevelText;
        GameEvent.OnExitMap += ReturnChapterPanel;

        SetMapNameText(GenerateMap.CurrentMapId);
        SetPlayerAttrText(playerAttr:PlayerData.Attr);
        SetLevelText(PlayerData.Level);
    }

    private void OnDestroy()
    {
        PlayerData = GameDataManager.PlayerData;
        GameEvent.OnMapChanged -= SetMapNameText;
        GameEvent.OnAttrChanged -= SetPlayerAttrText;
        GameEvent.OnLevelChanged -= SetLevelText;
        GameEvent.OnExitMap -= ReturnChapterPanel;
    }

}
