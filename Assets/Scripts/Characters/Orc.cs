using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Character
{
    // Constructor
    public Orc(string name)
    {
        type = "Orc";
        characterName = name;

        hp = 35;
        maxHP = 35;
        mp = 15;
        maxMP = 15;
        attack = 12;
        defense = 9;
        magic = 3;
        resistance = 2;

        pass = Passive.INTIMIDATE;

        hpGrowth = 100;
        mpGrowth = 60;
        atkGrowth = 80;
        defGrowth = 80;
        magGrowth = 30;
        resGrowth = 20;

        skillList.Add("Wild Swing (4)");
        skillList.Add("Armor Smash (5)");
        skillList.Add("Rally DEF (4)");
        skillList.Add("Rally ATK (4)");
        //skillList.Add("Lucky Star");

        growthList = new List<int> { hpGrowth, mpGrowth, atkGrowth, defGrowth, magGrowth, resGrowth };

        //skillList.Add("Attack");
    }
}
