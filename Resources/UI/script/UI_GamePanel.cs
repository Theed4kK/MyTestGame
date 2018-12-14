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
    public Text BloodText;
    public Text AttText;
    public Text DefenseText;
    public Text LevelText;
    public Text ExpText;
    public Text MapNameText;
    public Text ChapterNameText;
    public Text SystemLvText;
    public Text PlunderProValueText;
    public Text SystemLvUpText;

    [Header("按钮")]
    public Button BagBtn;
    public Button NextDgnBtn;

    [Header("进度条")]
    public Slider SystemExpSlider;
    public Slider ExpSlider;

    private PlayerData PlayerData = GameDataManager.PlayerData;


    private void Start()
    {
        //背包按钮事件（打开背包界面）
        BagBtn.onClick.AddListener(delegate ()
        {
            UIBase.OpenUI(UIBase.UI_BagPanel);
        });

        NextDgnBtn.onClick.AddListener(GoNextMap);
    }
    void OnEnable()
    {
        Init();
    }

    void GoNextMap()
    {
        GenerateMap.CurrentMapId = Cfg_Map.GetCfg(GenerateMap.CurrentMapId).NextMap;
    }

    void SetMapNameText(int mapId)
    {
        if (mapId == 0) return;
        MapNameText.text = Cfg_Map.GetCfg(mapId).Name;
        int chapterId = Cfg_Map.GetCfg(mapId).ChapterId;
        ChapterNameText.text = Cfg_Chapter.GetCfg(chapterId).Name;
    }
    void SetLevelText(int level)
    {
        LevelText.text = Cfg_Level.GetCfg(level).Name;
    }
    void SetPlayerAttrText(PlayerAttr playerAttr)
    {
        AttText.text = playerAttr.Attack.ToString();
        BloodText.text = playerAttr.Blood.ToString();
        DefenseText.text = playerAttr.Defense.ToString();
    }
    void SetExpSlider(int exp)
    {
        ExpText.text = exp.ToString() + "/" + Cfg_Level.GetCfg(PlayerData.Level).NeedExp;
        ExpSlider.value = exp / Cfg_Level.GetCfg(PlayerData.Level).NeedExp;
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
        GameEvent.OnMapChanged += SetMapNameText;
        GameEvent.OnAttrChanged += SetPlayerAttrText;
        GameEvent.OnLevelChanged += SetLevelText;
        GameEvent.OnExitMap += ReturnChapterPanel;
        GameEvent.OnExpChanged += SetExpSlider;

        SetMapNameText(GenerateMap.CurrentMapId);
        SetPlayerAttrText(playerAttr: PlayerData.Attr);
        SetLevelText(PlayerData.Level);
    }

    private void OnDestroy()
    {
        GameEvent.OnMapChanged -= SetMapNameText;
        GameEvent.OnAttrChanged -= SetPlayerAttrText;
        GameEvent.OnLevelChanged -= SetLevelText;
        GameEvent.OnExitMap -= ReturnChapterPanel;
    }

}
