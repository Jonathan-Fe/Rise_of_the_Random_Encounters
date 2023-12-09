using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : Character
{
    public Slime(string name)
    {
        type = "Slime";
        characterName = name;

        hp = 20;
        maxHP = 20;
        mp = 20;
        maxMP = 20;
        attack = 11;
        defense = 7;
        magic = 8;
        resistance = 5;

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
        skillList.Add("Rally MAG (4)");
        skillList.Add("Rally DEF (4)");
        //skillList.Add("Nuke (1)");
        //skillList.Add("Lucky Star");
        //skillList.Add("Lucky Star");
        //skillList.Add("Lucky Star");

        growthList = new List<int> { hpGrowth, mpGrowth, atkGrowth, defGrowth, magGrowth, resGrowth };

        //skillList.Add("Attack");
        //DontDestroyOnLoad(this);
        //GameManager.Instance.AddComponent<Slime>();
    }

    public Slime createSlime(string name)
    {
        Slime s = new Slime(name);
        return s;
    }

    /*
    public void Awake()
    {
        DontDestroyOnLoad();
    }
    */
}
