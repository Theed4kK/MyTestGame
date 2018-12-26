using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MonsterAttrChange : MonoBehaviour
{

    public GameObject ListObj;
    public GameObject ItemObj;

    public static Dictionary<Vector3, GameObject> AllListShow = new Dictionary<Vector3, GameObject>();

    private UI_ListItem UI_ListItem;

    private void Start()
    {

    }

    public void ShowAttrChange(int value, Vector3 pos, int type = 2)
    {
        if (AllListShow.ContainsKey(pos))
        {
            UI_ListItem = UIBase.InitListItem(GetItemObj(AllListShow[pos]));
        }
        else
        {
            ListObj.SetActive(true);
            GameObject obj = Instantiate(ListObj, ListObj.transform.parent);
            AllListShow.Add(pos, obj);
            UI_ListItem = UIBase.InitListItem(GetItemObj(AllListShow[pos]));
            ListObj.SetActive(false);
        }
        Vector3 objPos = Camera.main.WorldToScreenPoint(pos);
        AllListShow[pos].transform.position = objPos;
        UI_ListItem.Texts[0].text = value.ToString();
        UI_ListItem.Objs[type].SetActive(true);
        Destroy(UI_ListItem.gameObject, 5);
    }

    static GameObject GetItemObj(GameObject listObj)
    {
        GameObject obj = listObj.transform.Find("Viewport/Content/Item").gameObject;
        return obj;
    }

}
