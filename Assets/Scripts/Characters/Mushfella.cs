using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushfella : Character
{
    // High HP and Defenses, Poor Offenses
    // Used for supporting the party 
    // Weak to fire
    public Mushfella(string name)
    {
        type = "Mushfella";
        characterName = name;

        hp = 30;
        maxHP = 30;
        mp = 25;
        maxMP = 25;
        attack = 9;
        defense = 10;
        magic = 7;
        resistance = 13;

        weak = ELEMENTS.FIRE;

        hpGrowth = 100;
        mpGrowth = 75;
        atkGrowth = 45;
        defGrowth = 80;
        magGrowth = 45;
        resGrowth = 80;

        skillList.Add("Poison Spore (3)");
        skillList.Add("Heal Spore (7)");
        skillList.Add("Rally DEF (4)");
        skillList.Add("Rally RES (4)");
        //skillList.Add("Lucky Star");

        growthList = new List<int> { hpGrowth, mpGrowth, atkGrowth, defGrowth, magGrowth, resGrowth };
    }
}
