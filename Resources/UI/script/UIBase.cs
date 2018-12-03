using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    //public GameObject UIGamePanel;
    //public GameObject UIBagPanel;
    public static GameObject UI_GamePanel;
    public static GameObject UI_BagPanel;


    private static Dictionary<string, string> UIObjAndClone = new Dictionary<string, string>();
    public GameObject UIRoot;
    public static GameObject UI_Root;

    private void Awake()
    {
        UI_GamePanel = Resources.Load("UI\\prefab\\UI_GamePanel") as GameObject;
        UI_BagPanel = Resources.Load("UI\\prefab\\UI_BagPanel") as GameObject;
        UI_Root = UIRoot;
        //UI_GamePanel = UIGamePanel;
        //UI_BagPanel = Resources.Load("UI\\prefab\\UI_BagPanel") as GameObject;

    }


    public static void OpenUI(GameObject obj)
    {
        if (UIObjAndClone.ContainsKey(obj.name))
        {
            UI_Root.transform.Find(UIObjAndClone[obj.name]).gameObject.SetActive(true);
        }
        else
        {
            var _obj = Instantiate(obj, UI_Root.transform);
            UIObjAndClone.Add(obj.name, _obj.name);
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

    public static void SetSpite(Image Image, string fileName)
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






