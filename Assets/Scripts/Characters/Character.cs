using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static SkillDictionary;
using static UnityEngine.GraphicsBuffer;

public enum ELEMENTS {NONE, PHYS, FIRE, WATER, DARK, LIGHT}
public enum Passive { NONE, REGENERATOR, INTIMIDATE, MERCHANT, SPORE}

public class Character : MonoBehaviour
{
    public string type;
    public string characterName;
    public GameObject sprite;
    // Character Stats 
    public int hp;
    public int maxHP;
    public int mp;
    public int maxMP;
    public float attack;
    public float defense;
    public float magic;
    public float resistance;

    // Character Growths (For Level Up)
    public int hpGrowth = 50;
    public int mpGrowth = 20;
    public int atkGrowth = 50;
    public int defGrowth = 50;
    public int magGrowth = 50;
    public int resGrowth = 50;

    public List<int> growthList;
    public List<string> growthText;

    // ELEMENTAL AFFINITIES
    public ELEMENTS weak = ELEMENTS.NONE;
    public ELEMENTS strong = ELEMENTS.NONE;
    public ELEMENTS immune = ELEMENTS.NONE;

    // Character Statuses
    public bool KO = false;

    // This boolean is here to prevent the "KO Message" from printing multiple times for players
    public bool currKO = false;
    public bool PSN = false;

    public bool ATKUP = false;
    public float atkModifier = 1.0f;
    public int atkCounter = 0;
    public bool ATKDWN = false;

    public bool DEFUP = false;
    public float defModifier = 1.0f;
    public int defCounter = 0;
    public bool DEFDWN = false;

    public bool MAGUP = false;
    public float magModifier = 1.0f;
    public int magCounter = 0;
    public bool MAGDWN = false;

    public bool RESUP = false;
    public float resModifier = 1.0f;
    public int resCounter = 0;
    public bool RESDWN = false;

    public bool isDefending = false;

    public List<string> skillList = new List<string>();
    //public int[] passiveList;
    public Passive pass = Passive.NONE;

    public GameManager GM;
    public BattleSystem bs;
    public SkillDictionary sk;

    public Character()
    {
        type = "DUMMY";
        characterName = "DUMMY";
        sprite = Resources.Load<GameObject>("p_DUMMY");

        hp = 25;
        maxHP = 25;
        mp = 25;
        maxMP = 25;
        attack = 10;
        defense = 5;
        magic = 10;
        resistance = 5;

        KO = false;
        PSN = false;
        ATKUP = false;
        DEFUP = false;
        ATKDWN = false;
        DEFDWN = false;

        growthList = new List<int> { hpGrowth, mpGrowth, atkGrowth, defGrowth, magGrowth, resGrowth};
        growthText = new List<string>();

        sk = new SkillDictionary();

        //DontDestroyOnLoad;
    }

    public void setName(string newName)
    {
        characterName = newName;
    }

    public void knockout()
    {
        // KO should be an exclusive status condition
        // When a character is KO'd, remove all their buffs and statuses
        resetAttack();
        resetDefense();
        resetMagic();
        resetRes();
        curePoison();
        KO = true;
    }

    // Remove the KO status and give the character atleast 1 hp.
    public void cureKO()
    {
        KO = false;
        currKO = false;
        hp += hp + 1;
    }
    public void poison()
    {
        // Bosses should be immune to poison
        if (type == "BOSS")
        {
            return;
        }
        PSN = true;
    }

    // Poison deals 10% of the character's HP
    // Poison has no counter and lasts until it is cured 
    public void poisonDamage()
    {
        // Poison Damage should not affect KO'd Opponents
        if(KO == false && PSN == true)
        {
            hp -= (int)(hp * .1f);
            Debug.Log(characterName + " took poison damage.");
            checkHP();
        }
        //checkHP();
    }

    public void curePoison()
    {
        PSN = false;
    }
    
    // Attack Up and Attack Down should be mutaually exclusive
    public void attackUp()
    {
        ATKDWN = false;
        atkCounter = 3;
        ATKUP = true;
        atkModifier = 2f;
    }

    public void attackDown()
    {
        ATKUP = false;
        atkCounter = 3;
        ATKDWN = true;
        atkModifier = 0.5f;
    }

    public void resetAttack()
    {
        ATKUP = false;
        ATKDWN = false;
        atkModifier = 1.0f;
        Debug.Log("Resetting " + characterName + "'s Attack Stat");
        atkCounter = 0;
    }

    public void defenseUp()
    {
        DEFDWN = false;
        DEFUP = true;
        defCounter = 3;
        defModifier = 2f;
    }

    public void defenseDown()
    {
        DEFUP = false;
        DEFDWN = true;
        defCounter = 3;
        defModifier = 0.5f;
    }

    public void resetDefense()
    {
        DEFUP = false;
        DEFDWN = false;
        defModifier = 1.0f;
        Debug.Log("Resetting " + characterName + "'s Defense Stat");
        defCounter = 0;
    }

    public void magicUp()
    {
        MAGDWN = false;
        MAGUP = true;
        magCounter = 3;
        magModifier = 2f;
    }

    public void magicDown()
    {
        MAGUP = false;
        MAGDWN = true;
        magCounter = 3;
        magModifier = 0.5f;
    }

    public void resetMagic()
    {
        MAGUP = false;
        MAGDWN = false;
        magModifier = 1.0f;
        Debug.Log("Resetting " + characterName + "'s Magic Stat");
        magCounter = 0;
    }

    public void resUp()
    {
        RESDWN = false;
        RESUP = true;
        resCounter = 3;
        resModifier = 2f;
    }

    public void resDown()
    {
        RESUP = false;
        RESDWN = true;
        resCounter = 3;
        resModifier = 0.5f;
    }

    public void resetRes()
    {
        RESUP = false;
        RESDWN = false;
        resModifier = 1.0f;
        Debug.Log("Resetting " + characterName + "'s Resistance Stat");
        resCounter = 0;
    }


    public void checkHP()
    {
        if (hp <= 0)
        {
            hp = 0;
            knockout();
            Debug.Log(characterName + " has been KO'd!");
        }

        // If HP is healed to a value above max, reduce it to the max hp value
        if(hp > maxHP)
        {
            hp = maxHP;
        }
    }

    public void checkMP()
    {
        // If MP is restored to a value above max, reduce it to the max mp value
        if (mp > maxMP)
        {
            mp = maxMP;
        }
    }

    // This levels up a Player Character's stats after a battle
    public void levelUP()
    {
        Debug.Log(characterName + " is leveling up!");
        growthText.Clear();
        // For each stat in the growth list
        int t = 0;
        foreach (int i in growthList)
        {
            // Generate a random number
            int r = Random.Range(0, 100);
            Debug.Log("Level Up Range Value: " + r + " vs. State Threshold" + i);

            // If the generated number is less than the growth value, level up that stat
            if(r < i)
            {
                // Stats will be leveled up in order of the Growth List
                switch (t)
                {
                    case 0:
                        maxHP += 3;
                        hp += 3;
                        growthText.Add("+3");
                        Debug.Log(characterName + " gained HP!");
                        break;
                    case 1:
                        maxMP += 3;
                        mp += 3;
                        growthText.Add("+3");
                        Debug.Log(characterName + " gained MP!");
                        break;
                    case 2:
                        attack += 2;
                        growthText.Add("+2");
                        Debug.Log(characterName + " gained Attack!");
                        break;
                    case 3:
                        defense += 2;
                        growthText.Add("+2");
                        Debug.Log(characterName + " gained Defense!");
                        break;
                    case 4:
                        magic += 2;
                        growthText.Add("+2");
                        Debug.Log(characterName + " gained Magic!");
                        break;
                    case 5:
                        resistance += 2;
                        growthText.Add("+2");
                        Debug.Log(characterName + " gained Resistance!");
                        break;
                }
            } else
            {
                // If no stat has been increaed in this iteration, add +0 to the respective growthText index for that stat
                growthText.Add("+0");
                Debug.Log(characterName + " failed a stat roll");
            }

            t++;
        }
    }

    public virtual void enemyAI(Character self)
    {
        if (self.KO != true)
        {
            GameManager GM = FindObjectOfType<GameManager>();
            int i = 0;
            foreach (Character c in GM.playerParty)
            {
                if (c.type == "DUMMY")
                {
                    i++;
                }
            }
            int range = GM.playerParty.Count - i;
            int randomTarget = Random.Range(0, range);
            Debug.Log(randomTarget);
            Debug.Log("0 to " + range);
            //GM = GameObject.Find("GameManager").GetComponent<GameManager>();
            Character playerTarget = GM.playerParty[randomTarget];
            // If the targeted player is KO'd, reroll the enemy AI function until a better target is chosen
            if (playerTarget.KO == true)
            {
                enemyAI(self);
                return;
            }
            Debug.Log("Target: " + playerTarget.characterName);
            Debug.Log("Attacker: " + self.characterName);
            sk.attack_E(self, playerTarget);
        }
    }

    // If the character has regen passive, restore 10% of their maxHP hp at the end of their turn;
    public void regen()
    {
        hp += (int)(maxHP * 0.10);

        if (hp > maxHP)
        {
            hp = maxHP;
        }
    }

    public void decreaseStatus()
    {
        // Decrease the unity's buff counters each turn
        if(atkCounter > 0)
        {
            atkCounter--;
        }

        // If a couter somehow reaches below zero (it shouldn't), just correct it just in case
        if (atkCounter < 0)
        {
            atkCounter = 0;
        }

        if (atkCounter == 0)
        {
            resetAttack();
        }

        if (defCounter > 0)
        {
            defCounter--;
        }

        if (defCounter < 0)
        {
            defCounter = 0;
        }

        if (defCounter == 0)
        {
            resetDefense();
        }

        if (magCounter > 0)
        {
            magCounter--;
        }

        if (magCounter < 0)
        {
            magCounter = 0;
        }

        if (magCounter == 0)
        {
            resetMagic();
        }

        if (resCounter > 0)
        {
            resCounter--;
        }

        if (resCounter < 0)
        {
            resCounter = 0;
        }

        if (resCounter == 0)
        {
            resetRes();
        }

        Debug.Log(characterName + "'s attack buff counter: " + atkCounter + " turns remaining");
        Debug.Log(characterName + "'s defense buff counter: " + defCounter + " turns remaining");
        Debug.Log(characterName + "'s magic buff counter: " + magCounter + " turns remaining");
        Debug.Log(characterName + "'s resistance buff counter: " + resCounter + " turns remaining");
    }

    public void statusRestore()
    {
        if (ATKDWN == true)
        {
            resetAttack();
        }

        if (DEFDWN == true)
        {
            resetDefense();
        }

        if (MAGDWN == true)
        {
            resetMagic();
        }

        if (RESDWN == true)
        {
            resetRes();
        }

        if (PSN == true)
        {
            curePoison();
        }
    }

    public void fullRestore()
    {
        hp = maxHP;
        mp = maxMP;
    }

    /*
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    */
    /*
    // From this point here is just skills
    public void Attack(Character user, Character target)
    {
        float damage = ((user.attack * atkModifier) - target.defense);
        Debug.Log(user.characterName + " attacked " + target.characterName + " for " + damage + "!");

        target.hp -= (int) damage;
        checkHP(target);
    }
    */
}
