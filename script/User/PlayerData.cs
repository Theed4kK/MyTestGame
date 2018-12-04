using System.Collections.Generic;
using System.Linq;

public class PlayerData
{
    public int Level = 1, Exp = 0;//等级、当前经验

    public int attack = 1;//攻击
    public int defense = 2;//防御
    public int blood = 3;//血量

    //道具信息,ID、数量
    public Dictionary<int, int> ItemData = new Dictionary<int, int>() {
        {1,10 },
        {2,4 },
        {3,5 },
        {4,6 },
        {5,13 },
    };  
}

