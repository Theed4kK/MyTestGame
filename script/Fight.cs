public class Fight
{
    private static PlayerAttr PlayerAttr = GameDataManager.PlayerData.Attr;

    public static MonsterAttr FightWithMonster(MonsterAttr monsterAttr)
    {
        MonsterAttr newMonsterAttr = monsterAttr;
        PlayerAttr.Blood = monsterAttr.Attack;
        newMonsterAttr.Blood = PlayerAttr.Attack;
        return newMonsterAttr;
    }
}

