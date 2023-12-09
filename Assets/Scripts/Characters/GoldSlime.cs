using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSlime : Character
{
    // Gold Slime is a cheat Character

    public GoldSlime(string name)
    {
        type = "GoldSlime";
        characterName = name;

        hp = 99;
        maxHP = 99;
        mp = 99;
        maxMP = 99;
        attack = 99;//8;
        defense = 99;
        magic = 99;
        resistance = 99;

        hpGrowth = 80;
        mpGrowth = 80;
        atkGrowth = 50;
        defGrowth = 50;
        magGrowth = 50;
        resGrowth = 60;

        //ATKDWN = true;
        //atkCounter = 3;
        //attackDown();
        //defenseUp();
        //magicUp();
        //resDown();
        //poison();

        strong = ELEMENTS.FIRE;
        pass = Passive.REGENERATOR;

        skillList.Add("Lucky Star (5)");
        skillList.Add("Heal (3)");
        skillList.Add("Rally ATK (4)");
        skillList.Add("Nuke (1)"); // Nuke is a cheat spell that will instantly kill all enemies
        //skillList.Add("Lucky Star");
        //skillList.Add("Lucky Star");
        //skillList.Add("Lucky Star");

        growthList = new List<int> { hpGrowth, mpGrowth, atkGrowth, defGrowth, magGrowth, resGrowth };

        //skillList.Add("Attack");
        //DontDestroyOnLoad(this);
        //GameManager.Instance.AddComponent<Slime>();
    }
}
