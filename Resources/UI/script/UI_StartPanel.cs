using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartPanel : MonoBehaviour
{

    public Button StartBtn;

    private void Start()
    {
        StartBtn.onClick.AddListener(delegate (){
            UIBase.OpenUI(UIBase.UI_GamePanel);
            UIBase.CloseUI(gameObject);
            GenerateMap.CurrentMapId = 100;
        });
    }

}
