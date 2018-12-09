using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_ListItem : MonoBehaviour {

    public Text[] Texts;
    public Image[] Images;
    public GameObject[] Objs;
    public Button[] btns;

    private void OnDisable()
    {
        if (gameObject.name.Contains("Clone"))
        {
            Destroy(gameObject);
        }
    }

}
