using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_TipsPanel : MonoBehaviour
{
    public GameObject tipsObj;
    public float DisappearTime = 2f;

    private UI_ListItem UI_ListItem;

    public void AddTips(string tips)
    {
        UI_ListItem = UIBase.InitListItem(tipsObj);
        UI_ListItem.Texts[0].text = tips;
        Destroy(UI_ListItem.gameObject, DisappearTime);
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
                timer.StartTiming(DisappearTime, delegate ()
                {
                    gameObject.SetActive(false);
                }, false, null, false, false);
            }
        }
        else
        {
            timer = gameObject.AddComponent<Timer>();
            timer.StartTiming(DisappearTime, delegate ()
            {
                gameObject.SetActive(false);
            }, false, null, false, false); 
        }
        
    }

}
