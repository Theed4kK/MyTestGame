using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StartPanel : MonoBehaviour
{

    public Button StartBtn;

    public Animator ani;


    private void Start()
    {
        ani.Play("Start");
        StartBtn.onClick.AddListener(delegate (){
            UIBase.OpenUI(UIBase.UI_ChapterPanel);
            UIBase.CloseUI(uiobj:gameObject);
        });
    }

}
