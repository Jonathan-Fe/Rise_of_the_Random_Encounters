using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BaseManagement : MonoBehaviour
{
    //public GameObject GM;
    public GameManager GM;

    public Character p1;
    public GameObject p1Window;
    public TextMeshProUGUI p1Name;
    public TextMeshProUGUI p1HP;
    public TextMeshProUGUI p1MP;
    public bool p1_exists = false;

    public Character p2;
    public GameObject p2Window;
    public TextMeshProUGUI p2Name;
    public TextMeshProUGUI p2HP;
    public TextMeshProUGUI p2MP;
    public bool p2_exists = false;

    public Character p3;
    public GameObject p3Window;
    public TextMeshProUGUI p3Name;
    public TextMeshProUGUI p3HP;
    public TextMeshProUGUI p3MP;
    public bool p3_exists = false;

    public Character p4;
    public GameObject p4Window;
    public TextMeshProUGUI p4Name;
    public TextMeshProUGUI p4HP;
    public TextMeshProUGUI p4MP;
    public bool p4_exists = false;

    public TextMeshProUGUI battleText;
    public TextMeshProUGUI dayCounter;
    public TextMeshProUGUI goldCounter;

    // Start is called before the first frame update
    void Start()
    {
       GM = FindObjectOfType<GameManager>(); //GameObject.Find("GameManager");
       Debug.Log(GM);
       
        if(GM == null)
        {
            return;
        }
       
        Debug.Log("GM found and set...");
        Debug.Log("Game Manager Gold: " + GM.Gold);
       // Debug.Log("Player 1's name (alt): " + GM.p1Name);
        //Debug.Log("Player 1's name (real): " + GM.playerParty[0].characterName);
        Debug.Log("Player 1's name (partyInfo): " + partyInformation.Instance.p1Name);
        Debug.Log("Player 1's name (GM): " + GM.playerParty.Count);

        if (GM.playerParty[0].type != "DUMMY")
        {
            p1_exists = true;
            Debug.Log("Player 1 Exists");
        }

        if (GM.playerParty[1].type != "DUMMY")
        {
            p2_exists = true;
            Debug.Log("Player 2 Exists");
        }

        if (GM.playerParty[2].type != "DUMMY")
        {
            p3_exists = true;
            Debug.Log("Player 3 Exists");
        }

        if (GM.playerParty[3].type != "DUMMY")
        {
            p4_exists = true;
            Debug.Log("Player 4 Exists");
        }

        if (p1_exists)
        {
            p1Window.SetActive(true);
            p1 = GM.playerParty[0];
            p1Name.text = p1.characterName; //GM.GetComponent<GameManager>().playerParty[0].characterName;
            p1HP.text = "HP: " + p1.hp + "/" + p1.maxHP;
            p1MP.text = "MP: " + p1.mp + "/" + p1.maxMP;
        }
        else
        {
            p1Window.SetActive(false);
        }

        if (p2_exists)
        {
            p2Window.SetActive(true);
            p2 = GM.playerParty[1];
            p2Name.text = p2.characterName;
            p2HP.text = "HP: " + p2.hp + "/" + p2.maxHP;
            p2MP.text = "MP: " + p2.mp + "/" + p2.maxMP;
        }
        else
        {
            p2Window.SetActive(false);
        }

        if (p3_exists)
        {
            p3Window.SetActive(true);
            p3 = GM.playerParty[2];
            p3Name.text = p3.characterName;
            p3HP.text = "HP: " + p3.hp + "/" + p3.maxHP;
            p3MP.text = "MP: " + p3.mp + "/" + p3.maxMP;
        }
        else
        {
            p3Window.SetActive(false);
        }

        if (p4_exists)
        {
            p4Window.SetActive(true);
            p4 = GM.playerParty[3];
            p4Name.text = p4.characterName;
            p4HP.text = "HP: " + p4.hp + "/" + p4.maxHP;
            p4MP.text = "MP: " + p4.mp + "/" + p4.maxMP;
        }
        else
        {
            p4Window.SetActive(false);
        }

        dayCounter.text = ("Day -" + GM.Days);
        goldCounter.text = ("Gold -" + GM.Gold);

        int randomDialogue = Random.Range(0, 6);

        switch (randomDialogue)
        {
            case 0:
                battleDialogue("What will " + p1.characterName + " do...");
                break;
            case 1:
                battleDialogue("Decisions, Decisions...");
                break;
            case 2:
                battleDialogue("The party takes a well deserved rest..");
                break;
            case 3:
                battleDialogue("Gear Up for the next battle...");
                break;
            case 4:
                battleDialogue("Monsters are preparing... Please wait warmly...");
                break;
            case 5:
                battleDialogue("Take a load off...");
                break;
            default:
                battleDialogue("This probably shouldn't show up, but if it does, hello there");
                break;

        }

    }

    void Update()
    {
        updatePartyHUD();
    }

    public void battleDialogue(string sentence)
    {
        DisplayNextSentence(sentence);
    }

    public void DisplayNextSentence(string sentence)
    {
        //textDisplayed = false;

        Debug.Log(sentence);
        //dialogueText.text = sentence;
        // This is commented out here to prevent problems with pauses in the Battle UI
        //StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        //textDisplayed = true;
    }

    IEnumerator TypeSentence(string sentence)
    {
        battleText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            battleText.text += letter;
            yield return new WaitForSeconds(.01f);
        }
    }

    public void updateHUD(Character unit, TextMeshProUGUI health, TextMeshProUGUI mana)
    {
        health.text = "HP: " + unit.hp + "/" + unit.maxHP;
        mana.text = "MP: " + unit.mp + "/" + unit.maxMP;
    }

    public void updatePartyHUD()
    {
        if (p1_exists)
        {
            updateHUD(p1, p1HP, p1MP);
        }
        if (p2_exists)
        {
            updateHUD(p2, p2HP, p2MP);
        }
        if (p3_exists)
        {
            updateHUD(p3, p3HP, p3MP);
        }
        if (p4_exists)
        {
            updateHUD(p4, p4HP, p4MP);
        }

        dayCounter.text = ("Day -" + GM.Days);
        goldCounter.text = ("Gold -" + GM.Gold);
    }

    public void buttonEncounter()
    {
        FindObjectOfType<EnemyFormations>().rollEncounter(GM.difficulty);
        // Update Player Party Stats before changing scene
        partyInformation.Instance.p1Type = GM.playerParty[0].type;
        partyInformation.Instance.p1Name = GM.playerParty[0].characterName;
        partyInformation.Instance.p1hp = GM.playerParty[0].hp;
        partyInformation.Instance.p1maxHP = GM.playerParty[0].maxHP;
        partyInformation.Instance.p1mp = GM.playerParty[0].mp;
        partyInformation.Instance.p1maxMP = GM.playerParty[0].maxMP;
        partyInformation.Instance.p1attack = GM.playerParty[0].attack;
        partyInformation.Instance.p1defense = GM.playerParty[0].defense;
        partyInformation.Instance.p1magic = GM.playerParty[0].magic;
        partyInformation.Instance.p1resistance = GM.playerParty[0].resistance;
        partyInformation.Instance.p1hpGrowth = GM.playerParty[0].hpGrowth;
        partyInformation.Instance.p1atkGrowth = GM.playerParty[0].atkGrowth;
        partyInformation.Instance.p1defGrowth = GM.playerParty[0].defGrowth;
        partyInformation.Instance.p1magGrowth = GM.playerParty[0].magGrowth;
        partyInformation.Instance.p1resGrowth = GM.playerParty[0].resGrowth;
        partyInformation.Instance.p1growthList = GM.playerParty[0].growthList;
        partyInformation.Instance.p1skillList = GM.playerParty[0].skillList;
        partyInformation.Instance.p1growthText = GM.playerParty[0].growthText;
        partyInformation.Instance.p1weak = GM.playerParty[0].weak;
        partyInformation.Instance.p1strong = GM.playerParty[0].strong;
        partyInformation.Instance.p1immune = GM.playerParty[0].immune;

        partyInformation.Instance.p2Type = GM.playerParty[1].type;
        partyInformation.Instance.p2Name = GM.playerParty[1].characterName;
        partyInformation.Instance.p2hp = GM.playerParty[1].hp;
        partyInformation.Instance.p2maxHP = GM.playerParty[1].maxHP;
        partyInformation.Instance.p2mp = GM.playerParty[1].mp;
        partyInformation.Instance.p2maxMP = GM.playerParty[1].maxMP;
        partyInformation.Instance.p2attack = GM.playerParty[1].attack;
        partyInformation.Instance.p2defense = GM.playerParty[1].defense;
        partyInformation.Instance.p2magic = GM.playerParty[1].magic;
        partyInformation.Instance.p2resistance = GM.playerParty[1].resistance;
        partyInformation.Instance.p2hpGrowth = GM.playerParty[1].hpGrowth;
        partyInformation.Instance.p2atkGrowth = GM.playerParty[1].atkGrowth;
        partyInformation.Instance.p2defGrowth = GM.playerParty[1].defGrowth;
        partyInformation.Instance.p2magGrowth = GM.playerParty[1].magGrowth;
        partyInformation.Instance.p2resGrowth = GM.playerParty[1].resGrowth;
        partyInformation.Instance.p2growthList = GM.playerParty[1].growthList;
        partyInformation.Instance.p2skillList = GM.playerParty[1].skillList;
        partyInformation.Instance.p2growthText = GM.playerParty[1].growthText;
        partyInformation.Instance.p2weak = GM.playerParty[1].weak;
        partyInformation.Instance.p2strong = GM.playerParty[1].strong;
        partyInformation.Instance.p2immune = GM.playerParty[1].immune;

        partyInformation.Instance.p3Type = GM.playerParty[2].type;
        partyInformation.Instance.p3Name = GM.playerParty[2].characterName;
        partyInformation.Instance.p3hp = GM.playerParty[2].hp;
        partyInformation.Instance.p3maxHP = GM.playerParty[2].maxHP;
        partyInformation.Instance.p3mp = GM.playerParty[2].mp;
        partyInformation.Instance.p3maxMP = GM.playerParty[2].maxMP;
        partyInformation.Instance.p3attack = GM.playerParty[2].attack;
        partyInformation.Instance.p3defense = GM.playerParty[2].defense;
        partyInformation.Instance.p3magic = GM.playerParty[2].magic;
        partyInformation.Instance.p3resistance = GM.playerParty[2].resistance;
        partyInformation.Instance.p3hpGrowth = GM.playerParty[2].hpGrowth;
        partyInformation.Instance.p3atkGrowth = GM.playerParty[2].atkGrowth;
        partyInformation.Instance.p3defGrowth = GM.playerParty[2].defGrowth;
        partyInformation.Instance.p3magGrowth = GM.playerParty[2].magGrowth;
        partyInformation.Instance.p3resGrowth = GM.playerParty[2].resGrowth;
        partyInformation.Instance.p3growthList = GM.playerParty[2].growthList;
        partyInformation.Instance.p3skillList = GM.playerParty[2].skillList;
        partyInformation.Instance.p3growthText = GM.playerParty[2].growthText;
        partyInformation.Instance.p3weak = GM.playerParty[2].weak;
        partyInformation.Instance.p3strong = GM.playerParty[2].strong;
        partyInformation.Instance.p3immune = GM.playerParty[2].immune;

        partyInformation.Instance.p4Type = GM.playerParty[3].type;
        partyInformation.Instance.p4Name = GM.playerParty[3].characterName;
        partyInformation.Instance.p4hp = GM.playerParty[3].hp;
        partyInformation.Instance.p4maxHP = GM.playerParty[3].maxHP;
        partyInformation.Instance.p4mp = GM.playerParty[3].mp;
        partyInformation.Instance.p4maxMP = GM.playerParty[3].maxMP;
        partyInformation.Instance.p4attack = GM.playerParty[3].attack;
        partyInformation.Instance.p4defense = GM.playerParty[3].defense;
        partyInformation.Instance.p4magic = GM.playerParty[3].magic;
        partyInformation.Instance.p4resistance = GM.playerParty[3].resistance;
        partyInformation.Instance.p4hpGrowth = GM.playerParty[3].hpGrowth;
        partyInformation.Instance.p4atkGrowth = GM.playerParty[3].atkGrowth;
        partyInformation.Instance.p4defGrowth = GM.playerParty[3].defGrowth;
        partyInformation.Instance.p4magGrowth = GM.playerParty[3].magGrowth;
        partyInformation.Instance.p4resGrowth = GM.playerParty[3].resGrowth;
        partyInformation.Instance.p4growthList = GM.playerParty[3].growthList;
        partyInformation.Instance.p4skillList = GM.playerParty[3].skillList;
        partyInformation.Instance.p4growthText = GM.playerParty[3].growthText;
        partyInformation.Instance.p4weak = GM.playerParty[3].weak;
        partyInformation.Instance.p4strong = GM.playerParty[3].strong;
        partyInformation.Instance.p4immune = GM.playerParty[3].immune;

        partyInformation.Instance.enemyParty = GM.enemyParty;
        //Debug.Log(partyInformation.Instance.enemyParty);

        SceneManager.LoadScene("Battle_Scene_Test");
    }
}
