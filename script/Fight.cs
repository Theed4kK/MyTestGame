using System;

public class Fight
{
    private static PlayerAttr PlayerAttr = GameDataManager.PlayerData.Attr;

    public static void FightWithMonster(MonsterAttr monsterAttr)
    {
        PlayerAttr.Blood -=Math.Max(monsterAttr.Attack - PlayerAttr.Defense,1);
        monsterAttr.Blood -= Math.Max(PlayerAttr.Attack - monsterAttr.Defense,1);
    }
}

