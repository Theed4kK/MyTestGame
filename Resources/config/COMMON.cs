using System.Collections.Generic;
using UnityEngine;

public static class COMMON
{
    public static string ItemIconPath = "texture/UITexture/ItemIcons/";
    public static string MonsterIconPath = "texture/NpcTexture/";
    public static string ChapterIconPath = "texture/ChapterIcon/";

    public static int GenMonsterPro = 3000;//每个砖块生成怪物的概率，万分比

    public static bool RandomIsSuccess(int molecule, int Denominator)
    {
        int value = Random.Range(0, Denominator + 1);
        if (value <= molecule )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SetSprite(SpriteRenderer sprite, string fileName)
    {
        sprite.sprite = Resources.Load(fileName, typeof(Sprite)) as Sprite;
    }
}