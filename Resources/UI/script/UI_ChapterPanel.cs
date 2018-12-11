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
                if (!AlreadyPass.Contains(item.NeedMap))
                {
                    UIBase.Addtips("请先通关上一章节！");
                    return;
                }
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
        List<int> mapList = new List<int>() { startMap };
        for (int i = 0; i < 100; i++)
        {
            int nextMap = Cfg_Map.GetCfg(startMap).NextMap;
            if (nextMap != 0)
            {
                mapList.Add(nextMap);
                startMap = nextMap;
            }
            else
            {
                break;
            }
        }
        bool lastMapIsPass = true;
        foreach (var map in mapList)
        {
            UI_ListItem = UIBase.InitListItem(MapListObj);
            UI_ListItem.Texts[0].text = Cfg_Map.GetCfg(map).Name;
            UI_ListItem.Texts[1].text = Cfg_Map.GetCfg(map).Des;
            bool IsPass = AlreadyPass.Contains(map);
            UI_ListItem.Objs[0].SetActive(!IsPass && lastMapIsPass);
            UI_ListItem.Objs[1].SetActive(IsPass || !lastMapIsPass);
            if (IsPass && lastMapIsPass)
            {
                UI_ListItem.Texts[2].text = "已通关";
            }
            else
            {
                UI_ListItem.Texts[2].text = "需通关上一关";

            }
            lastMapIsPass = IsPass;
            UI_ListItem.btns[0].onClick.AddListener(delegate ()
            {
                gameObject.SetActive(false);
                GenerateMap.CurrentMapId = map;
            });
            SetMonsterList(map, UI_ListItem.Objs[2]);

        }
        UIBase.ResetListPos(MapListObj, 1);

    }

    private void SetMonsterList(int mapId, GameObject gameObject)
    {
        int firstRuleId = Cfg_Map.GetCfg(mapId).GenMonsterRule;
        List<int> genRuleList = new List<int>() { firstRuleId };
        for (int i = 0; i < 100; i++)
        {
            int nextRule = Cfg_GenMon.GetCfg(firstRuleId).NextRule;
            if (nextRule != 0)
            {
                genRuleList.Add(nextRule);
                firstRuleId = nextRule;
            }
            else
            {
                break;
            }
        }
        //foreach (var genRuleId in genRuleList)
        //{
        //    Cfg_GenMon cfg_GenMon = Cfg_GenMon.GetCfg(genRuleId);
        //    Cfg_NPC cfg_NPC = Cfg_NPC.GetCfg(cfg_GenMon.MonsterId);
        //    UI_ListItem = UIBase.InitListItem(gameObject);
        //    string Asset = COMMON.MonsterIconPath + cfg_NPC.AssetName;
        //    UIBase.SetImageSpite(UI_ListItem.Images[0], Asset);
        //}
        UIBase.ResetListPos(gameObject);
    }
}
