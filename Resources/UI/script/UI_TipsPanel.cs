using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_TipsPanel : MonoBehaviour
{
    public GameObject tipsObj;

    private UI_ListItem UI_ListItem;

    public void AddTips(string tips)
    {
        UI_ListItem = UIBase.InitListItem(tipsObj);
        UI_ListItem.Texts[0].text = tips;
        Destroy(UI_ListItem.gameObject, 2);
    }

    private void OnEnable()
    {
        Timer timer = gameObject.GetComponent<Timer>();
        if (timer != null)
        {
            if (timer.GetLeftTime() > 0)
            {
                timer.ReStartTimer();
            }
            else
            {
                timer.StartTiming(2, delegate ()
                {
                    gameObject.SetActive(false);
                }, false, null, false, false);
            }
        }
        else
        {
            timer = gameObject.AddComponent<Timer>();
            timer.StartTiming(2, delegate ()
            {
                gameObject.SetActive(false);
            }, false, null, false, false); 
        }
        
    }

}
