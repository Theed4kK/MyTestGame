using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public int PlayerId = 1;
    private string Path;
    private readonly string FileName = "GameData";
    private readonly bool isEncryption = false;
    private Dictionary<int, PlayerData> AllPlayerData = new Dictionary<int, PlayerData>();
    public static PlayerData PlayerData = new PlayerData(); //当前使用的游戏数据
    public PlayerDataSave PlayerDataSave = new PlayerDataSave();

    private void Awake()
    {
        Path = Application.persistentDataPath + "/save/";
        //Save(Path);
        Load();
        if(AllPlayerData.Count != 0) { PlayerData = AllPlayerData[1]; }
        
    }

    public void SwitchPlayer(int TargetId)
    {
        PlayerData = AllPlayerData[TargetId];
    }

    public void Save()
    {
        string s = PlayerDataSave.SerializeObject(AllPlayerData, typeof(Dictionary<int, PlayerData>));
        //创建XML文件且写入数据  
        PlayerDataSave.CreateTextFile(Path, FileName, s, isEncryption);
        Debug.Log("保存游戏数据到" + Path + FileName);
    }

    public void Load()
    {
        try
        {
            string strTemp = PlayerDataSave.LoadTextFile(Path + FileName, isEncryption);
            //反序列化对象  
            AllPlayerData = PlayerDataSave.DeserializeObject(strTemp, typeof(Dictionary<int, PlayerData>)) as Dictionary<int, PlayerData>;
        }
        catch
        {
            Debug.Log("系统读取XML出现错误，请检查");
        }
    }




}
