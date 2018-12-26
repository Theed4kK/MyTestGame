using System;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static int currentPlayerId = 1;
    private string Path;
    private string fileName = "GameData";
    private string FileName
    {
        get { return fileName + string.Format("{0:D3}", currentPlayerId); }
    }
    private readonly bool isEncryption = false;
    public static PlayerData PlayerData = new PlayerData(); //当前使用的游戏数据
    public PlayerDataSave PlayerDataSave = new PlayerDataSave();

    private void Awake()
    {

        Path = Application.persistentDataPath + "/save/";
    }

    private void Start()
    {
        Load();
        TimedPreservation();//定时保存数据
        PracticeAddExp();//修炼增加经验
    }

    private void PracticeAddExp()
    {
        Timer timer = Timer.CreateTimer("Practice");
        int interval = COMMON.PracticeInterval;
        timer.StartTiming(interval, delegate ()
        {
            if (PlayerData.IsStartPractice)
            {
                Cfg_Level cfg_Level = Cfg_Level.GetCfg(PlayerData.Level);
                PlayerDataChange.AddExp(cfg_Level.AddExp);
            }
        }, true);  //每隔一段时间获得一次经验，需要先开启修炼，受资质影响
    }

    private void TimedPreservation()
    {
        Timer timer = Timer.CreateTimer();
        timer.StartTiming(60, Save, true);  //每60s保存一次数据
    }

    public void SwitchPlayer(int TargetId)
    {
        Save();
        currentPlayerId = TargetId;
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("currentPlayerId", currentPlayerId);
        string s = PlayerDataSave.SerializeObject(PlayerData, typeof(PlayerData));
        //创建XML文件且写入数据  
        PlayerDataSave.CreateTextFile(Path, FileName, s, isEncryption);
        Debug.Log("保存游戏数据到" + Path + FileName);
    }

    public void Load()
    {
        try
        {
            currentPlayerId = PlayerPrefs.GetInt("currentPlayerId", 1);
            string strTemp = PlayerDataSave.LoadTextFile(Path + FileName, isEncryption);
            //反序列化对象  
            PlayerData = PlayerDataSave.DeserializeObject(strTemp, typeof(PlayerData)) as PlayerData;
        }
        catch
        {
            Debug.Log("读取存档错误，请检查！");
        }
    }
}
