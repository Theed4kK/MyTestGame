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
    public static Material spriteMaterial_g = Resources.Load("Material/SpriteOutterGlow_green") as Material;
    public static Material spriteMaterial_b = Resources.Load("Material/SpriteOutterGlow_blue") as Material;
    public static Material spriteMaterial_p = Resources.Load("Material/SpriteOutterGlow_purple") as Material;
    public static Material spriteMaterial_o = Resources.Load("Material/SpriteOutterGlow_orange") as Material;

    public static Material[] spriteMaterials = { spriteMaterial_g, spriteMaterial_b, spriteMaterial_p, spriteMaterial_o };

    public static int GenMonsterPro = 3000;//每个砖块生成怪物的概率，万分比

    public static bool RandomIsSuccess(int molecule, int Denominator)
    {
        int value = Random.Range(0, Denominator + 1);
        if (value <= molecule)
        {
            return true;
        }
        else
        {
            return false;
        }
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
}

public enum Color
{
}