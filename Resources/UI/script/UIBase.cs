using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBehaviour
{
    public static GameObject UI_StartPanel;
    public static GameObject UI_GamePanel;
    public static GameObject UI_BagPanel;
    public static GameObject UI_ChapterPanel;
    public static GameObject UI_TipsPanel;


    private static Dictionary<string, string> UIObjAndClone = new Dictionary<string, string>() {
        { "UI_StartPanel","UI_StartPanel" }
    };
    public GameObject UIRoot;

    private static GameObject _UIRoot;

    private void Awake()
    {
        UI_StartPanel = Resources.Load("UI\\prefab\\UI_StartPanel") as GameObject;
        UI_GamePanel = Resources.Load("UI\\prefab\\UI_GamePanel") as GameObject;
        UI_BagPanel = Resources.Load("UI\\prefab\\UI_BagPanel") as GameObject;
        UI_ChapterPanel = Resources.Load("UI\\prefab\\UI_ChapterPanel") as GameObject;
        UI_TipsPanel = Resources.Load("UI\\prefab\\UI_TipsPanel") as GameObject;
        _UIRoot = UIRoot;
    }

    public static GameObject OpenUI(GameObject uiobj)
    {
        if(uiobj == null)
        {
            Debug.Log("试图打开一个空UI");
            return null;
        }
        if (UIObjAndClone.ContainsKey(uiobj.name))
        {
            GameObject obj = _UIRoot.transform.Find(UIObjAndClone[uiobj.name]).gameObject;
            obj.transform.SetAsLastSibling();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            var _obj = Instantiate(uiobj, _UIRoot.transform);
            UIObjAndClone.Add(uiobj.name, _obj.name);
            return _obj;
        }
    }


    /// <summary>
    /// 关闭界面
    /// </summary>
    /// <param name="uiobj">要关闭的界面</param>
    public static void CloseUI(GameObject uiobj)
    {
            
        if(uiobj == null) { Debug.Log("试图关闭一个不存在的UI"); return; }
        if (UIObjAndClone.ContainsKey(uiobj.name))
        {
            _UIRoot.transform.Find(UIObjAndClone[uiobj.name]).gameObject.SetActive(false);
        }
        if (UIObjAndClone.ContainsValue(uiobj.name))
        {
            _UIRoot.transform.Find(uiobj.name).gameObject.SetActive(false);
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

    /// <summary>
    /// 设置UI图片
    /// </summary>
    /// <param name="Image">要设置的图片</param>
    /// <param name="fileName">要设置的图片名</param>
    public static void SetImageSpite(Image Image, string fileName)
    {
        Image.sprite = Resources.Load(fileName, typeof(Sprite)) as Sprite;
    }

    public static UI_ListItem InitListItem(GameObject itemObj)
    {
        itemObj.SetActive(false);
        GameObject gameObject = Instantiate(itemObj, itemObj.transform.parent);
        gameObject.SetActive(true);
        UI_ListItem uI_ListItem = gameObject.GetComponent<UI_ListItem>();
        return uI_ListItem;
    }

    public static void SetList()
    {

    }
    /// <summary>
    /// 重置列表的X或Y
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="XorY">为0是重置X，为1是重置Y</param>
    public static void ResetListPos(GameObject gameObject,int XorY = 0)
    {
        Transform transform = gameObject.transform.parent;
        switch (XorY)
        {
            case 0:
                transform.localPosition -= new Vector3(transform.localPosition.x, 0,0);
                break;
            case 1:
                transform.localPosition -= new Vector3(0, transform.localPosition.y, 0);
                break;
        }
    }

    public static void Addtips(string tips)
    {
        GameObject obj =  OpenUI(UI_TipsPanel);
        UI_TipsPanel tipsPanel = obj.GetComponent<UI_TipsPanel>();
        tipsPanel.AddTips(tips);
    }
}

public enum UI
{
    UI_StartPanel,
    UI_GamePanel,
    UI_BagPanel,
    UI_ChapterPanel,
    UI_TipsPanel
}






