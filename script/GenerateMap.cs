using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject BrickRoot;
    public Transform BasePos;
    public float distanceX = 1.01f;
    public float distanceY;

    // Use this for initialization
    void Start()
    {
        GenMap();
    }

    public void GenMap()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var obj = transform.GetChild(i);
            if (obj != BasePos) Destroy(obj.gameObject);
        }

        GameObject _mBrickBoot;
        for (int column = 0; column < 7; column++)
        {
            for (int row = 0; row < 5; row++)
            {
                _mBrickBoot = Instantiate(BrickRoot, transform);
                _mBrickBoot.transform.SetPositionAndRotation(BasePos.localPosition + new Vector3(row * distanceX, column * distanceY,0),Quaternion.identity);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
