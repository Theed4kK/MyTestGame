using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClick : MonoBehaviour
{
    public GameObject Main;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsTouchedUI()) return;
            Click();
        }
    }

    void Click()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isHit = Physics.Raycast(ray, out hit, 100f, ~(1 << LayerMask.NameToLayer("UI")));

        if (isHit )
        {
            BrickRoot brickRoot = hit.collider.GetComponent<BrickRoot>();
            if (brickRoot != null)
            {
                brickRoot.BeClicked();
            }

        }
    }

    bool IsTouchedUI()
    {
        bool touchedUI = false;
        if (Application.isMobilePlatform)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                touchedUI = true;
            }
        }
        else if (EventSystem.current.IsPointerOverGameObject())
        {
            touchedUI = true;
        }
        return touchedUI;
    }
}
