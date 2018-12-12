public class Fight
{
    private static PlayerAttr PlayerAttr = GameDataManager.PlayerData.Attr;

    public static void FightWithMonster(MonsterAttr monsterAttr)
    {
        PlayerAttr.Blood -= monsterAttr.Attack - PlayerAttr.Defense;
        monsterAttr.Blood -= PlayerAttr.Attack - monsterAttr.Defense;
    }
}

