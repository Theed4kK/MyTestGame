using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChapterPanel : MonoBehaviour
{

    public Button returnBtn;
    public GameObject ChapterListObj;
    public GameObject MapObj;
    public GameObject MapListObj;
    public Text MapList_ChapterName;

    private readonly List<int> AlreadyPass = GameDataManager.PlayerData.AlreadyPass;
    private UI_ListItem UI_ListItem;

    private void Start()
    {
        returnBtn.onClick.AddListener(delegate ()
        {
            UIBase.OpenUI(UIBase.UI_StartPanel);
            UIBase.CloseUI(gameObject);
        });
    }

    void OnEnable()
    {
        MapObj.SetActive(false);
        SetChapterList();
    }

    private void SetChapterList()
    {

        foreach (var item in Cfg_Chapter.GetAllCfg())
        {
            UI_ListItem = UIBase.InitListItem(ChapterListObj);
            UI_ListItem.Texts[0].text = item.Name;
            string Asset = COMMON.ChapterIconPath + item.Asset;
            UIBase.SetImageSpite(UI_ListItem.Images[0], Asset);
            if (!AlreadyPass.Contains(item.NeedMap))
            {
                COMMON.SetImageGray(UI_ListItem.Images[0]);
            }
            UI_ListItem.btns[0].onClick.AddListener(delegate ()
            {
                OpenMapList(item.StartMap);
                MapList_ChapterName.text = item.Name;
            });
        }
    }


    void OpenMapList(int StartMap)
    {
        SetMapList(StartMap);
        MapObj.SetActive(true);
    }

    private void SetMapList(int startMap)
    {
        bool lastMapIsPass = true;
        UIBase.ResetListPos(MapListObj,1);
        for (int i = 0; i < 100; i++)
        {
            UI_ListItem = UIBase.InitListItem(MapListObj);
            UI_ListItem.Texts[0].text = Cfg_Map.GetCfg(startMap).Name;
            UI_ListItem.Texts[1].text = Cfg_Map.GetCfg(startMap).Des;
            bool IsPass = AlreadyPass.Contains(startMap);
            UI_ListItem.Objs[0].SetActive(!IsPass && lastMapIsPass);
            UI_ListItem.Objs[1].SetActive(IsPass|| !lastMapIsPass);
            if (IsPass && lastMapIsPass)
            {
                UI_ListItem.Texts[2].text ="已通关";
            }
            else
            {
                UI_ListItem.Texts[2].text = "需通关上一关";

            }
            lastMapIsPass = IsPass;
            UI_ListItem.btns[0].onClick.AddListener(delegate() {
                GenerateMap.CurrentMapId = startMap;
            });
            SetMonsterList(startMap, UI_ListItem.Objs[2]);
            int nextMap = Cfg_Map.GetCfg(startMap).NextMap;
            if (nextMap != 0)
            {
                startMap = nextMap;
            }
            else
            {
                break;
            }

        }

    }

    private void SetMonsterList(int mapId,GameObject gameObject)
    {
        UIBase.ResetListPos(gameObject);
        int genRuleId = Cfg_Map.GetCfg(mapId).GenMonsterRule;
        for (int i = 0; i < 100; i++)
        {
            Cfg_GenMon cfg_GenMon = Cfg_GenMon.GetCfg(genRuleId);
            Cfg_NPC cfg_NPC = Cfg_NPC.GetCfg(cfg_GenMon.MonsterId);
            UI_ListItem = UIBase.InitListItem(gameObject);
            string Asset = COMMON.MonsterIconPath + cfg_NPC.AssetName;
            UIBase.SetImageSpite(UI_ListItem.Images[0], Asset);
            int nextRule = Cfg_GenMon.GetCfg(genRuleId).NextRule;
            if (nextRule != 0)
            {
                genRuleId = nextRule;
            }
            else
            {
                break;
            }

        }
    }
}
