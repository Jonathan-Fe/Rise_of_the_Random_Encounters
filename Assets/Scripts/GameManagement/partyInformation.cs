using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class partyInformation : MonoBehaviour
{
    public string p1Type;
    public string p1Name;
    public int p1hp;
    public int p1maxHP;
    public int p1mp;
    public int p1maxMP;
    public float p1attack;
    public float p1defense;
    public float p1magic;
    public float p1resistance;
    public int p1hpGrowth;
    public int p1mpGrowth;
    public int p1atkGrowth;
    public int p1defGrowth;
    public int p1magGrowth;
    public int p1resGrowth;
    public List<int> p1growthList;
    public List<string> p1growthText;
    public List<string> p1skillList;
    public ELEMENTS p1weak;
    public ELEMENTS p1strong;
    public ELEMENTS p1immune;

    public string p2Type;
    public string p2Name;
    public int p2hp;
    public int p2maxHP;
    public int p2mp;
    public int p2maxMP;
    public float p2attack;
    public float p2defense;
    public float p2magic;
    public float p2resistance;
    public int p2hpGrowth;
    public int p2mpGrowth;
    public int p2atkGrowth;
    public int p2defGrowth;
    public int p2magGrowth;
    public int p2resGrowth;
    public List<int> p2growthList;
    public List<string> p2growthText;
    public List<string> p2skillList;
    public ELEMENTS p2weak;
    public ELEMENTS p2strong;
    public ELEMENTS p2immune;

    public string p3Type;
    public string p3Name;
    public int p3hp;
    public int p3maxHP;
    public int p3mp;
    public int p3maxMP;
    public float p3attack;
    public float p3defense;
    public float p3magic;
    public float p3resistance;
    public int p3hpGrowth;
    public int p3mpGrowth;
    public int p3atkGrowth;
    public int p3defGrowth;
    public int p3magGrowth;
    public int p3resGrowth;
    public List<int> p3growthList;
    public List<string> p3growthText;
    public List<string> p3skillList;
    public ELEMENTS p3weak;
    public ELEMENTS p3strong;
    public ELEMENTS p3immune;

    public string p4Type;
    public string p4Name;
    public int p4hp;
    public int p4maxHP;
    public int p4mp;
    public int p4maxMP;
    public float p4attack;
    public float p4defense;
    public float p4magic;
    public float p4resistance;
    public int p4hpGrowth;
    public int p4mpGrowth;
    public int p4atkGrowth;
    public int p4defGrowth;
    public int p4magGrowth;
    public int p4resGrowth;
    public List<int> p4growthList;
    public List<string> p4growthText;
    public List<string> p4skillList;
    public ELEMENTS p4weak;
    public ELEMENTS p4strong;
    public ELEMENTS p4immune;


    public int Gold = 2500;
    public int Days = 0;
    public int difficulty = 1;
    public TIME clock = TIME.NIGHT;
    public string timer = "NIGHT";

    public bool boss1;
    public bool boss2;

    public List<Character> enemyParty;
    public string enemyDialogue;
    public int goldReward;


    public int potion = 5;
    public int hiPotion = 1;
    public int ether = 5;
    public int hiEther = 1;
    public int fullPotion = 1;
    public int refresh = 1;
    public int revivalHerb = 1;
    public int pavise = 1;
    public int wardingCharm = 1;
    public int mandragora = 9;
    public int bomb = 1;
    public int gasBomb = 1;
    public int smokeBomb = 1;

    public int potionPrice = 5;
    public int hiPotionPrice = 1;
    public int etherPrice = 5;
    public int hiEtherPrice = 1;
    public int fullPotionPrice = 1;
    public int refreshPrice = 1;
    public int revivalHerbPrice = 1;
    public int pavisePrice = 1;
    public int wardingCharmPrice = 1;
    public int mandragoraPrice = 9;
    public int bombPrice = 1;
    public int gasBombPrice = 1;
    public int smokeBombPrice = 1;

    public static partyInformation Instance;

    public string e1Name;
    public string e2Name;
    public string e3Name;

    public int enemyPartyIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //clock = TIME.NIGHT;
        DontDestroyOnLoad(gameObject);

        Gold = 5000;

        potion = 5;
        hiPotion = 1;
        ether = 5;
        hiEther = 1;
        fullPotion = 1;
        refresh = 1;
        revivalHerb = 1;
        pavise = 1;
        wardingCharm = 1;
        mandragora = 9;
        bomb = 1;
        gasBomb = 1;
        smokeBomb = 1;

        potionPrice = 50;
        hiPotionPrice = 150;
        etherPrice = 75;
        hiEtherPrice = 200;
        fullPotionPrice = 300;
        refreshPrice = 60;
        revivalHerbPrice = 200;
        pavisePrice = 150;
        wardingCharmPrice = 150;
        mandragoraPrice = 350;
        bombPrice = 150;
        gasBombPrice = 75;
        smokeBombPrice = 125;

    }

}
