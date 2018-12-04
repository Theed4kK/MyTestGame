using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamePanel : MonoBehaviour
{

    public Image RoleIcon;
    public Text bloodText;
    public Text AttText;
    public Button BagBtn;

    // Use this for initialization
    void Start()
    {

        Init();

        //背包按钮事件（打开背包界面）
        BagBtn.onClick.AddListener(delegate ()
        {
            UIBase.OpenUI(UIBase.UI_BagPanel);
        });


    }

    public void Init()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
