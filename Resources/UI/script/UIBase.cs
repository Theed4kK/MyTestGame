using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    //public GameObject UIGamePanel;
    //public GameObject UIBagPanel;
    public static GameObject UI_GamePanel;
    public static GameObject UI_BagPanel ;


    private static Dictionary<string, string> UIObjAndClone = new Dictionary<string, string>();
    public GameObject UIRoot;

    private static GameObject _UIRoot;

    private void Awake()
    {
        UI_GamePanel = Resources.Load("UI\\prefab\\UI_GamePanel") as GameObject;
        UI_BagPanel = Resources.Load("UI\\prefab\\UI_BagPanel") as GameObject;
        //UI_GamePanel = UIGamePanel;
        //UI_BagPanel = Resources.Load("UI\\prefab\\UI_BagPanel") as GameObject;
        _UIRoot = UIRoot;
    }

  
    public static void OpenUI(GameObject uiobj)
    {
        if (UIObjAndClone.ContainsKey(uiobj.name))
        {
            GameObject obj = _UIRoot.transform.Find(UIObjAndClone[uiobj.name]).gameObject;
            obj.transform.SetAsLastSibling();
            obj.SetActive(true);
        }
        else
        {
            var _obj = Instantiate(uiobj, _UIRoot.transform);
            UIObjAndClone.Add(uiobj.name, _obj.name);
        }
    }

    public static void CloseUI(GameObject uiobj)
    {
        if (UIObjAndClone.ContainsKey(uiobj.name))
        {
            _UIRoot.transform.Find(UIObjAndClone[uiobj.name]).gameObject.SetActive(false);
        }
    }

    public static string GetChildPath(GameObject item, GameObject child)
    {
        string path = child.name;
        GameObject obj = child;
        for (int i = 0; i < 100; i++)
        {
            if (obj.transform.parent.gameObject == item)
            {
                break;
            }
            obj = obj.transform.parent.gameObject;
            path = obj.name + "/" + path;
        }
        return path;
    }

    public static void SetImageSpite(Image Image, string fileName)
    {
        Image.sprite = Resources.Load(fileName,typeof(Sprite)) as Sprite;
    }

    public static UI_ListItem InitListItem(GameObject itemObj)
    {
        itemObj.SetActive(false);
        GameObject gameObject = Instantiate(itemObj, itemObj.transform.parent);
        gameObject.SetActive(true);
        UI_ListItem uI_ListItem = gameObject.GetComponent<UI_ListItem>();
        return uI_ListItem;
    }
}






