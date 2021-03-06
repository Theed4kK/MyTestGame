﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public static class COMMON
{
    //资源路径
    public static string ItemIconPath = "texture/UITexture/ItemIcons/"; //道具图标
    public static string MonsterIconPath = "texture/NpcTexture/";       //怪物图片
    public static string ChapterIconPath = "texture/ChapterIcon/";      //章节图片

    //图片发光材质
    private static Material spriteMaterial_g = Resources.Load("Material/SpriteOutterGlow_green") as Material;
    private static Material spriteMaterial_b = Resources.Load("Material/SpriteOutterGlow_blue") as Material;
    private static Material spriteMaterial_p = Resources.Load("Material/SpriteOutterGlow_purple") as Material;
    private static Material spriteMaterial_o = Resources.Load("Material/SpriteOutterGlow_orange") as Material;

    public static Material[] spriteMaterials = { spriteMaterial_g, spriteMaterial_b, spriteMaterial_p, spriteMaterial_o };

    public static int PracticeInterval = 10;//修炼间隔时间，影响获得经验的速度

    public static bool RandomIsSuccess(int molecule, int Denominator)
    {
        int value = Random.Range(0, Denominator + 1);
        return value <= molecule;
    }

    /// <summary>
    /// 通过图片路径设置图片
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="fileName"></param>
    public static void SetSprite(SpriteRenderer sprite, string fileName)
    {
        sprite.sprite = Resources.Load(fileName, typeof(Sprite)) as Sprite;
    }

    /// <summary>
    /// 设置sprite灰显
    /// </summary>
    /// <param name="sprite"></param>
    public static void SetSpriteGray(SpriteRenderer sprite, bool IsSetGray = true)
    {
        if (IsSetGray)
        {
            sprite.material = Resources.Load("Material/SpriteGray", typeof(Material)) as Material;
        }
        else
        {
            sprite.material = null;
        }
    }

    /// <summary>
    /// 设置image灰显
    /// </summary>
    /// <param name="sprite"></param>
    public static void SetImageGray(Image image, bool IsSetGray = true)
    {
        if (IsSetGray)
        {
            image.material = Resources.Load("Material/ImageGray", typeof(Material)) as Material;
        }
        else
        {
            image.material = null;
        }
    }


    public static List<T> RandomSortList<T>(List<T> ListT)
    {
        List<T> newList = new List<T>();
        foreach (T item in ListT)
        {
            newList.Insert(Random.Range(0, newList.Count), item);
        }
        return newList;
    }

    public static string SetStrColor(string str, int color)
    {
        string newStr;
        string colorStr = "white";
        switch (color)
        {
            case 0:
                colorStr = "green";
                break;
            case 1:
                colorStr = "blue";
                break;
            case 2:
                colorStr = "purple";
                break;
            case 3:
                colorStr = "gold";
                break;
        }
        newStr = "<color=" + colorStr + ">" + str + "</color>";
        return newStr;
    }

}