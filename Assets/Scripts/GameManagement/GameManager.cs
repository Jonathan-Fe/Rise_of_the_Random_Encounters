using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Character;
using static EnemyFormations;

public enum TIME { DAY, NIGHT}

public class GameManager : MonoBehaviour
{
    // Note: This script has higher execution order to prevent some crashes from simultaneous start methods
    public GameManager GM;

    //public Character[] testParty = [new Slime("Terry"), new Orc(), null, null];
    public List<Character> playerParty; //new List<Character>();
    public Character p1;
    public string p1Name = "";
    public List<Character> enemyParty;
    public string enemyDialogue;
    public int goldReward;

    public int Gold;
    public int Days;
    public int difficulty;
    public TIME clock;
    public string timer;

    public bool boss1;
    public bool boss2;

    // Prefabs for buttons
    public GameObject luckyStar;

    public static GameManager Instance;

    private void Awake()
    {
        /*
        if (Instance == null)
        {
            Instance = this;
            //playerParty = new List<Character>();
            //playerParty = new List<Character> { new Slime("Terry"), new Orc("Gonzales"), new Character(), new Character() };
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        */
        //p1 = playerParty[0];
       // Debug.Log(p1.characterName);
    }

    // This is for testing since setting up lists of static variables as fields

    private void Start()
    {
        //Debug.Log(p1.characterName);
        playerParty = new List<Character> {new Slime("Terry"), new Orc("Gonzales"), new Character(), new Character()};

        switch (partyInformation.Instance.p1Type)
        {
            case "Slime":
                Debug.Log("Player 1 is a Slime");
                playerParty[0] = new Slime(partyInformation.Instance.p1Name);
                break;
            case "Orc":
                Debug.Log("Player 1 is an Orc");
                playerParty[0] = new Orc(partyInformation.Instance.p1Name);
                break;
            case "Phantom":
                Debug.Log("Player 1 is an Phantom");
                playerParty[0] = new Phantom(partyInformation.Instance.p1Name);
                break;
            case "Mushfella":
                Debug.Log("Player 1 is an Mushfella");
                playerParty[0] = new Mushfella(partyInformation.Instance.p1Name);
                break;
            case "GoldSlime":
                Debug.Log("Player 1 is an Gold Slime");
                playerParty[0] = new GoldSlime(partyInformation.Instance.p1Name);
                break;
            default:
                Debug.Log("Player 1 is a DUMMY");
                playerParty[0] = new Character();
                break;
        }

        switch (partyInformation.Instance.p2Type)
        {
            case "Slime":
                Debug.Log("Player 2 is a Slime");
                playerParty[1] = new Slime(partyInformation.Instance.p2Name);
                break;
            case "Orc":
                Debug.Log("Player 2 is a Orc");
                playerParty[1] = new Orc(partyInformation.Instance.p2Name);
                break;
            case "Phantom":
                Debug.Log("Player 2 is an Phantom");
                playerParty[1] = new Phantom(partyInformation.Instance.p2Name);
                break;
            case "Mushfella":
                Debug.Log("Player 2 is an Mushfella");
                playerParty[1] = new Mushfella(partyInformation.Instance.p2Name);
                break;
            default:
                Debug.Log("Player 2 is a DUMMY");
                playerParty[1] = new Character();
                break;
        }

        switch (partyInformation.Instance.p3Type)
        {
            case "Slime":
                Debug.Log("Player 3 is a Slime");
                playerParty[2] = new Slime(partyInformation.Instance.p3Name);
                break;
            case "Orc":
                Debug.Log("Player 3 is a Orc");
                playerParty[2] = new Orc(partyInformation.Instance.p3Name);
                break;
            case "Phantom":
                Debug.Log("Player 3 is an Phantom");
                playerParty[2] = new Phantom(partyInformation.Instance.p3Name);
                break;
            case "Mushfella":
                Debug.Log("Player 3 is an Mushfella");
                playerParty[2] = new Mushfella(partyInformation.Instance.p3Name);
                break;
            default:
                Debug.Log("Player 3 is a DUMMY");
                playerParty[2] = new Character();
                break;
        }

        switch (partyInformation.Instance.p4Type)
        {
            case "Slime":
                Debug.Log("Player 4 is a Slime");
                playerParty[3] = new Slime(partyInformation.Instance.p4Name);
                break;
            case "Orc":
                Debug.Log("Player 4 is a Slime");
                playerParty[3] = new Orc(partyInformation.Instance.p4Name);
                break;
            case "Phantom":
                Debug.Log("Player 4 is an Phantom");
                playerParty[3] = new Phantom(partyInformation.Instance.p4Name);
                break;
            case "Mushfella":
                Debug.Log("Player 4 is an Mushfella");
                playerParty[3] = new Mushfella(partyInformation.Instance.p4Name);
                break;
            default:
                Debug.Log("Player 4 is a DUMMY");
                playerParty[3] = new Character();
                break;
        }


        playerParty[0].hp = partyInformation.Instance.p1hp;
        playerParty[0].maxHP = partyInformation.Instance.p1maxHP;
        playerParty[0].mp = partyInformation.Instance.p1mp;
        playerParty[0].maxMP = partyInformation.Instance.p1maxMP;
        playerParty[0].attack = partyInformation.Instance.p1attack;
        playerParty[0].defense = partyInformation.Instance.p1defense;
        playerParty[0].magic = partyInformation.Instance.p1magic;
        playerParty[0].resistance = partyInformation.Instance.p1resistance;
        playerParty[0].hpGrowth = partyInformation.Instance.p1hpGrowth;
        playerParty[0].atkGrowth = partyInformation.Instance.p1atkGrowth;
        playerParty[0].defGrowth = partyInformation.Instance.p1defGrowth;
        playerParty[0].magGrowth = partyInformation.Instance.p1magGrowth;
        playerParty[0].resGrowth = partyInformation.Instance.p1resGrowth;
        playerParty[0].growthList = partyInformation.Instance.p1growthList;
        playerParty[0].skillList = partyInformation.Instance.p1skillList;
        playerParty[0].growthText = partyInformation.Instance.p1growthText;
        playerParty[0].weak = partyInformation.Instance.p1weak;
        playerParty[0].strong = partyInformation.Instance.p1strong;
        playerParty[0].immune = partyInformation.Instance.p1immune;

        playerParty[1].hp = partyInformation.Instance.p2hp;
        playerParty[1].maxHP = partyInformation.Instance.p2maxHP;
        playerParty[1].mp = partyInformation.Instance.p2mp;
        playerParty[1].maxMP = partyInformation.Instance.p2maxMP;
        playerParty[1].attack = partyInformation.Instance.p2attack;
        playerParty[1].defense = partyInformation.Instance.p2defense;
        playerParty[1].magic = partyInformation.Instance.p2magic;
        playerParty[1].resistance = partyInformation.Instance.p2resistance;
        playerParty[1].hpGrowth = partyInformation.Instance.p2hpGrowth;
        playerParty[1].atkGrowth = partyInformation.Instance.p2atkGrowth;
        playerParty[1].defGrowth = partyInformation.Instance.p2defGrowth;
        playerParty[1].magGrowth = partyInformation.Instance.p2magGrowth;
        playerParty[1].resGrowth = partyInformation.Instance.p2resGrowth;
        playerParty[1].growthList = partyInformation.Instance.p2growthList;
        playerParty[1].skillList = partyInformation.Instance.p2skillList;
        playerParty[1].growthText = partyInformation.Instance.p2growthText;
        playerParty[1].weak = partyInformation.Instance.p2weak;
        playerParty[1].strong = partyInformation.Instance.p2strong;
        playerParty[1].immune = partyInformation.Instance.p2immune;

        playerParty[2].hp = partyInformation.Instance.p3hp;
        playerParty[2].maxHP = partyInformation.Instance.p3maxHP;
        playerParty[2].mp = partyInformation.Instance.p3mp;
        playerParty[2].maxMP = partyInformation.Instance.p3maxMP;
        playerParty[2].attack = partyInformation.Instance.p3attack;
        playerParty[2].defense = partyInformation.Instance.p3defense;
        playerParty[2].magic = partyInformation.Instance.p3magic;
        playerParty[2].resistance = partyInformation.Instance.p3resistance;
        playerParty[2].hpGrowth = partyInformation.Instance.p3hpGrowth;
        playerParty[2].atkGrowth = partyInformation.Instance.p3atkGrowth;
        playerParty[2].defGrowth = partyInformation.Instance.p3defGrowth;
        playerParty[2].magGrowth = partyInformation.Instance.p3magGrowth;
        playerParty[2].resGrowth = partyInformation.Instance.p3resGrowth;
        playerParty[2].growthList = partyInformation.Instance.p3growthList;
        playerParty[2].skillList = partyInformation.Instance.p3skillList;
        playerParty[2].growthText = partyInformation.Instance.p3growthText;
        playerParty[2].weak = partyInformation.Instance.p3weak;
        playerParty[2].strong = partyInformation.Instance.p3strong;
        playerParty[2].immune = partyInformation.Instance.p3immune;

        playerParty[3].hp = partyInformation.Instance.p4hp;
        playerParty[3].maxHP = partyInformation.Instance.p4maxHP;
        playerParty[3].mp = partyInformation.Instance.p4mp;
        playerParty[3].maxMP = partyInformation.Instance.p4maxMP;
        playerParty[3].attack = partyInformation.Instance.p4attack;
        playerParty[3].defense = partyInformation.Instance.p4defense;
        playerParty[3].magic = partyInformation.Instance.p4magic;
        playerParty[3].resistance = partyInformation.Instance.p4resistance;
        playerParty[3].hpGrowth = partyInformation.Instance.p4hpGrowth;
        playerParty[3].atkGrowth = partyInformation.Instance.p4atkGrowth;
        playerParty[3].defGrowth = partyInformation.Instance.p4defGrowth;
        playerParty[3].magGrowth = partyInformation.Instance.p4magGrowth;
        playerParty[3].resGrowth = partyInformation.Instance.p4resGrowth;
        playerParty[3].growthList = partyInformation.Instance.p4growthList;
        playerParty[3].skillList = partyInformation.Instance.p4skillList;
        playerParty[3].growthText = partyInformation.Instance.p4growthText;
        playerParty[3].weak = partyInformation.Instance.p4weak;
        playerParty[3].strong = partyInformation.Instance.p4strong;
        playerParty[3].immune = partyInformation.Instance.p4immune;

        Gold = partyInformation.Instance.Gold;
        Days = partyInformation.Instance.Days;
        clock = partyInformation.Instance.clock;
        timer = partyInformation.Instance.timer;
        //Days += 1;

        boss1 = partyInformation.Instance.boss1;
        boss2 = partyInformation.Instance.boss2;

        enemyParty = partyInformation.Instance.enemyParty;
        enemyDialogue = partyInformation.Instance.enemyDialogue;
        goldReward = partyInformation.Instance.goldReward;

        //Debug.Log(partyInformation.Instance.clock);
        changeDay();

        Debug.Log(playerParty[0].characterName);
        Debug.Log(playerParty[0].type);
        Debug.Log(playerParty[0].maxHP);
        Debug.Log(playerParty[0].attack);
        Debug.Log(playerParty[1].characterName);
        Debug.Log(playerParty[1].type);
        Debug.Log(playerParty[2].characterName);
        Debug.Log(playerParty[2].type);
        Debug.Log(playerParty[3].characterName);
        Debug.Log(playerParty[3].type);
        //luckyStar = Resources.Load<GameObject>("Buttons / Lucky Star.prefab");
    }

    void Update()
    {
        // Hold Crtl + input to activate Cheats
        if (Input.GetKey(KeyCode.LeftControl))
        {
            // Cheat Code to end the Game at any time
            if (Input.GetKey("e"))
            {
                loadGameOver();
            }

            // Cheat to get 1000 Gold
            if (Input.GetKey("p"))
            {
                Gold += 1000;
            }

            if (Input.GetKey("r"))
            {
                SceneManager.LoadScene("Title_Screen");
            }
        }
    }
    public void playerSlime()
    {
        playerParty.Add(new Slime("Slime"));
        Debug.Log(playerParty[0].type);
        Debug.Log(playerParty[0].maxHP);
    }

    public void playerOrc()
    {
        playerParty.Add(new Orc("Slime"));
        Debug.Log(playerParty[0].type);
        Debug.Log(playerParty[0].maxHP);
    }


    // Changes the time progression in days
    // I originally wanted a day and night cycle for the purpose of some flair and passive effects, but I couldn't get it to work right, so I scrapped it
    public void changeDay()
    {
        /*
        Debug.Log("Time of Day (Before Change - GM): " + clock);
        Debug.Log("Time of Day (Before Change - PI): " + partyInformation.Instance.clock);
        // If the current time is DAY, set time to NIGHT
        if (clock == TIME.DAY)
        {
            clock = TIME.NIGHT;
        }

       // If the current time is night, increment day counter and set Time to DAY
       else if(clock == TIME.NIGHT)
        {
            Days++;
            clock = TIME.DAY;
        }

        partyInformation.Instance.clock = clock;
        Debug.Log("Day Counter: " + Days);
        Debug.Log("Time of Day: " + clock.ToString());
        */
        Debug.Log("Day Counter: " + Days);
        //Days++;
        partyInformation.Instance.Days +=1;
        //partyInformation.Instance.clock = clock;
        //partyInformation.Instance.timer = timer;
        Debug.Log("Day Counter: " + partyInformation.Instance.Days);
        if (Days <= 4)
        {
            // During the first 4 days  4 days, difficulty is easy
            difficulty = 1;
        }
        if (Days > 4 && Days <= 8)
        {
            // After 4 days pass, increase difficulty of rounds a bit
            difficulty = 2;
        }
        if (Days >= 9 && boss1 == false)
        {
            // This locks the player into the 1st boss fight until it is cleared
            difficulty = 3;
        }

        if (Days >= 9 && Days <= 15 && boss1 == true)
        {
            // After Boss 1 is defeated, set difficulty to the highest
            difficulty = 4;
        }

        if (Days >= 15 && boss2 == false && boss1 == true)
        {
            // If Boss 1 is defeated and 16 days have passed, lock the player into fighting Boss 2
            difficulty = 5;
        }

        if (Days >= 15 && boss2 == true && boss1 == true)
        {
            // After both bosses are defeated and 16 days have passed, loop the hardest enemies infinitely
            difficulty = 4;
        }
        partyInformation.Instance.difficulty = difficulty;
        Debug.Log("Difficulty: " + difficulty);
    }
    public void loadCombatScene()
    {

    }

    public void loadBase()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("Base");
    }

    public void loadGameOver()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("GameOver");
    }

}
