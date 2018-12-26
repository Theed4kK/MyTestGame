using System;

public class Fight
{
    private static PlayerAttr PlayerAttr = GameDataManager.PlayerData.Attr;

    public static void FightWithMonster(MonsterAttr monsterAttr,BrickRoot brickRoot)
    {
        int lossBlood_player = Math.Max(monsterAttr.Attack - PlayerAttr.Defense, 1);
        int lossBlood_monster = Math.Max(PlayerAttr.Attack - monsterAttr.Defense, 1);
        PlayerAttr.Blood -= lossBlood_player;
        monsterAttr.Blood -= lossBlood_monster;
        UIBase.ShowAttrChange(-lossBlood_monster, brickRoot.transform.localPosition);
        brickRoot.MonsterAni.SetTrigger("BeAttacked");
    }
}

