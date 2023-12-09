using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantom : Character
{
    // High Magic and Res, low HP, Attack, Defense
    // Immune to physical attacks, but weak to Light Attacks
    public Phantom(string name)
    {
        type = "Phantom";
        characterName = name;

        hp = 15;
        maxHP = 15;
        mp = 30;
        maxMP = 30;
        attack = 12;
        defense = 6;
        magic = 10;
        resistance = 10;

        //pass = Passive.INTIMIDATE;
        immune = ELEMENTS.PHYS;
        weak = ELEMENTS.LIGHT;

        hpGrowth = 65;
        mpGrowth = 100;
        atkGrowth = 45;
        defGrowth = 45;
        magGrowth = 100;
        resGrowth = 70;

        skillList.Add("Ghastly Wail (6)");
        skillList.Add("Heal (3)");
        skillList.Add("Lucky Star (5)");
        skillList.Add("Rally RES (4)");
        //skillList.Add("Lucky Star");

        growthList = new List<int> { hpGrowth, mpGrowth, atkGrowth, defGrowth, magGrowth, resGrowth };
    }
}
