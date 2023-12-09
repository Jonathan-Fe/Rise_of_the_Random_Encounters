using System;
using System.Collections;
using System.Collections.Generic;
//using System.Security.Cryptography;
using TMPro;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.UIElements;
using static Character;
using static SkillDictionary;
using static UnityEngine.UI.CanvasScaler;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public GameObject GM;
    public GameObject bs;
    public TextMeshProUGUI battleText;

    SkillDictionary sk;

    // This variable checks if all the text of a given sentence has been displayed
    // This is to keep the "GetMouseButton" update in check and prevent it from advancing multiple lines at once.
    //public bool textDisplayed = true;

    //UI and text variables
    public GameObject p1Window;
    public GameObject p1Menu;
    public GameObject p1Skills;
    public GameObject p1_1;
    public Button p1skill1;
    public TextMeshProUGUI p1skill1_t;
    public GameObject p1_2;
    public Button p1skill2;
    public TextMeshProUGUI p1skill2_t;
    public GameObject p1_3;
    public Button p1skill3;
    public TextMeshProUGUI p1skill3_t;
    public GameObject p1_4;
    public Button p1skill4;
    public TextMeshProUGUI p1skill4_t;
    public Character p1;
    public TextMeshProUGUI p1Name;
    public TextMeshProUGUI p1HP;
    public TextMeshProUGUI p1MP;
    public GameObject p1_status1;
    public GameObject p1_status2;
    public GameObject p1_status3;
    public GameObject p1_status4;
    public GameObject p1_status5;
    public bool p1_exists = true;

    public GameObject p2Window;
    public GameObject p2Menu;
    public GameObject p2Skills;
    public GameObject p2_1;
    public Button p2skill1;
    public TextMeshProUGUI p2skill1_t;
    public GameObject p2_2;
    public Button p2skill2;
    public TextMeshProUGUI p2skill2_t;
    public GameObject p2_3;
    public Button p2skill3;
    public TextMeshProUGUI p2skill3_t;
    public GameObject p2_4;
    public Button p2skill4;
    public TextMeshProUGUI p2skill4_t;
    public Character p2;
    public TextMeshProUGUI p2Name;
    public TextMeshProUGUI p2HP;
    public TextMeshProUGUI p2MP;
    public GameObject p2_status1;
    public GameObject p2_status2;
    public GameObject p2_status3;
    public GameObject p2_status4;
    public GameObject p2_status5;
    public bool p2_exists = false;

    public GameObject p3Window;
    public GameObject p3Menu;
    public GameObject p3Skills;
    public GameObject p3_1;
    public Button p3skill1;
    public TextMeshProUGUI p3skill1_t;
    public GameObject p3_2;
    public Button p3skill2;
    public TextMeshProUGUI p3skill2_t;
    public GameObject p3_3;
    public Button p3skill3;
    public TextMeshProUGUI p3skill3_t;
    public GameObject p3_4;
    public Button p3skill4;
    public TextMeshProUGUI p3skill4_t;
    public Character p3;
    public TextMeshProUGUI p3Name;
    public TextMeshProUGUI p3HP;
    public TextMeshProUGUI p3MP;
    public GameObject p3_status1;
    public GameObject p3_status2;
    public GameObject p3_status3;
    public GameObject p3_status4;
    public GameObject p3_status5;
    public bool p3_exists = false;

    public GameObject p4Window;
    public GameObject p4Menu;
    public GameObject p4Skills;
    public GameObject p4_1;
    public Button p4skill1;
    public TextMeshProUGUI p4skill1_t;
    public GameObject p4_2;
    public Button p4skill2;
    public TextMeshProUGUI p4skill2_t;
    public GameObject p4_3;
    public Button p4skill3;
    public TextMeshProUGUI p4skill3_t;
    public GameObject p4_4;
    public Button p4skill4;
    public TextMeshProUGUI p4skill4_t;
    public Character p4;
    public TextMeshProUGUI p4Name;
    public TextMeshProUGUI p4HP;
    public TextMeshProUGUI p4MP;
    public GameObject p4_status1;
    public GameObject p4_status2;
    public GameObject p4_status3;
    public GameObject p4_status4;
    public GameObject p4_status5;
    public bool p4_exists = false;

    public Character activeUser;
    public GameObject activeUI;
    public GameObject activeSkills;
    public List<GameObject> activeSkillList;
    public GameObject aS1, aS2, aS3, aS4;
    public Button aB1, aB2, aB3, aB4;
    public TextMeshProUGUI aS1t, aS2t, aS3t, aS4t;

    //public List<Character> players = new List<Character>();
    //public List<Character> enemies;

    public Character en_1;
    public GameObject en_g1;
    public bool en1_exists = false;
    public Character en_2;
    public GameObject en_g2;
    public bool en2_exists = false;
    public Character en_3;
    public GameObject en_g3;
    public bool en3_exists = false;

    public Transform enemyLoc1;
    public GameObject en1_status1;
    public GameObject en1_status2;
    public GameObject en1_status3;
    public GameObject en1_status4;
    public GameObject en1_status5;

    public Transform enemyLoc2;
    public GameObject en2_status1;
    public GameObject en2_status2;
    public GameObject en2_status3;
    public GameObject en2_status4;
    public GameObject en2_status5;

    public Transform enemyLoc3;
    public GameObject en3_status1;
    public GameObject en3_status2;
    public GameObject en3_status3;
    public GameObject en3_status4;
    public GameObject en3_status5;

    // Turn Variables
    public bool turnFinished = false;
    public bool p1Turn = false;
    public bool p2Turn = false;
    public bool p3Turn = false;
    public bool p4Turn = false;

    // Variables for Ending the Battle
    public int playerCount;
    public int enemyCount;
    public bool endBattle = false;

    public GameObject battleWinWindow;
    public TextMeshProUGUI p1Level_t;
    public GameObject p1Level;
    public TextMeshProUGUI p2Level_t;
    public GameObject p2Level;
    public TextMeshProUGUI p3Level_t;
    public GameObject p3Level;
    public TextMeshProUGUI p4Level_t;
    public GameObject p4Level;
    public TextMeshProUGUI goldGained_t;
    public GameObject goldGained;

   // public GameObject atkUP;

    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        sk = bs.GetComponent<SkillDictionary>();
        state = BattleState.START;
        Debug.Log("Battle Start!");
        GM = GameObject.Find("GameManager");//FindObjectOfType<GameManager>();
        //playerParty.Add(new Slime("Terry"));
        // players[0] = GM.GetComponent<GameManager>().playerParty[0];
        // players[1] = GM.GetComponent<GameManager>().playerParty[1];
        // players[2] = GM.GetComponent<GameManager>().playerParty[2];
        // players[3] = GM.GetComponent<GameManager>().playerParty[3];

        if (GM.GetComponent<GameManager>().playerParty[0].type != "DUMMY")
        {
            p1_exists = true;
            playerCount = 1;
        }

        if (GM.GetComponent<GameManager>().playerParty[1].type != "DUMMY")
        {
            p2_exists = true;
            playerCount = 2;
        }

        if (GM.GetComponent<GameManager>().playerParty[2].type != "DUMMY")
        {
            p3_exists = true;
            playerCount = 3;
        }

        if (GM.GetComponent<GameManager>().playerParty[3].type != "DUMMY")
        {
            p4_exists = true;
            playerCount = 4;
        }
        // Debug.Log(GM.GetComponent<GameManager>().playerParty[0].characterName);

        //playerCount = GM.GetComponent<GameManager>().playerParty.Count;
        //enemyCount = GM.GetComponent<GameManager>().enemyParty.Count;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        if (p1_exists)
        {
            p1Window.SetActive(true);
            p1 = GM.GetComponent<GameManager>().playerParty[0];
            p1Name.text = p1.characterName; //GM.GetComponent<GameManager>().playerParty[0].characterName;
            p1HP.text = "HP: " + p1.hp + "/" + p1.maxHP;
            p1MP.text = "MP: " + p1.mp + "/" + p1.maxMP;
        } else
        {
            p1Window.SetActive(false);
        }

        if (p2_exists)
        {
            p2Window.SetActive(true);
            p2 = GM.GetComponent<GameManager>().playerParty[1];
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
            p3 = GM.GetComponent<GameManager>().playerParty[2];
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
            p4 = GM.GetComponent<GameManager>().playerParty[3];
            p4Name.text = p4.characterName;
            p4HP.text = "HP: " + p4.hp + "/" + p4.maxHP;
            p4MP.text = "MP: " + p4.mp + "/" + p4.maxMP;
        }
        else
        {
            p4Window.SetActive(false);
        }

        updatePartyHUD();

        Debug.Log(partyInformation.Instance.enemyPartyIndex);
        GM.GetComponent<GameManager>().enemyParty = GM.GetComponent<EnemyFormations>().formationList[partyInformation.Instance.enemyPartyIndex];
        GM.GetComponent<GameManager>().goldReward = GM.GetComponent<EnemyFormations>().goldTable[partyInformation.Instance.enemyPartyIndex];

        Debug.Log(GM.GetComponent<GameManager>().enemyParty.ToString());
        Debug.Log(GM.GetComponent<GameManager>().enemyParty[0].characterName);
        //Debug.Log(GM.GetComponent<GameManager>().enemyParty[1].characterName);
        //Debug.Log(GM.GetComponent<GameManager>().enemyParty[2].characterName);

        switch (GM.GetComponent<GameManager>().enemyParty.Count)
        {
            case 1:
                en_1 = GM.GetComponent<GameManager>().enemyParty[0];//GM.GetComponent<EnemyFormations>().formationList[0][0];
                en_g1 = Instantiate(en_1.sprite, enemyLoc1);
                en1_exists = true;
                enemyCount = 1;

                battleDialogue(GM.GetComponent<GameManager>().enemyDialogue);//battleDialogue(GM.GetComponent<EnemyFormations>().formationDialogue[0]);

                Debug.Log("Staring Battle with " + GM.GetComponent<GameManager>().enemyParty.Count + " enemy.");
                break;
            case 2:
                en_1 = GM.GetComponent<GameManager>().enemyParty[0];
                en_g1 = Instantiate(en_1.sprite, enemyLoc1);
                en1_exists = true;
                en_2 = GM.GetComponent<GameManager>().enemyParty[1];
                en_g2 = Instantiate(en_2.sprite, enemyLoc2);
                en2_exists = true;
                enemyCount = 2;

                battleDialogue(GM.GetComponent<GameManager>().enemyDialogue);

                Debug.Log("Staring Battle with " + GM.GetComponent<GameManager>().enemyParty.Count + " enemies.");
                break;
            case 3:
                en_1 = GM.GetComponent<GameManager>().enemyParty[0];
                en_g1 = Instantiate(en_1.sprite, enemyLoc1);//.layer = LayerMask.NameToLayer("Sprites");
                en1_exists = true;
                en_2 = GM.GetComponent<GameManager>().enemyParty[1];
                en_g2 = Instantiate(en_2.sprite, enemyLoc2);//.layer = LayerMask.NameToLayer("Sprites");
                en2_exists = true;
                en_3 = GM.GetComponent<GameManager>().enemyParty[2];
                en_g3 = Instantiate(en_3.sprite, enemyLoc3);//.layer = LayerMask.NameToLayer("Sprites");
                en3_exists = true;
                enemyCount = 3;


                Debug.Log("Staring Battle with " + GM.GetComponent<GameManager>().enemyParty.Count + " enemies.");

                battleDialogue(GM.GetComponent<GameManager>().enemyDialogue);
               // FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                break;
            default:
                Debug.Log("This shouldn't happen : BATTTLE SETUP - ENEMY FORMATION ERROR");
                break;
        }

        yield return new WaitForSeconds(2f);

        if (intimidateCheck())
        {
            intimidate(activeUser);
            updatePartyHUD_Enemy();
            yield return new WaitForSeconds(2f);
        }
        //updatePartyHUD();
        //updatePartyHUD_Enemy();
        Debug.Log("Wait has finished");
        state = BattleState.PLAYERTURN;
        StartCoroutine(playerTurn());
        Debug.Log("PlayerTurn has run");
        yield return null;
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

    public void updateHUD(Character unit, TextMeshProUGUI health, TextMeshProUGUI mana, GameObject status1, GameObject status2, GameObject status3, GameObject status4, GameObject status5)
    {
        health.text = "HP: " + unit.hp + "/" + unit.maxHP;
        mana.text = "MP: " + unit.mp + "/" + unit.maxMP;

        if (unit.ATKUP || unit.ATKDWN)
        {
            status1.GetComponentInChildren<TextMeshProUGUI>().text = unit.atkCounter.ToString();
            if (unit.ATKUP)
            {
                status1.transform.GetChild(1).gameObject.SetActive(false);
                status1.transform.GetChild(0).gameObject.SetActive(true);
            } else if (unit.ATKDWN)
            {
                status1.transform.GetChild(0).gameObject.SetActive(false);
                status1.transform.GetChild(1).gameObject.SetActive(true);
            }
            
            status1.SetActive(true);
        } else
        {
            status1.SetActive(false);
            status1.transform.GetChild(0).gameObject.SetActive(false);
            status1.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (unit.DEFUP || unit.DEFDWN)
        {
            status2.GetComponentInChildren<TextMeshProUGUI>().text = unit.defCounter.ToString();
            if (unit.DEFUP)
            {
                status2.transform.GetChild(1).gameObject.SetActive(false);
                status2.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (unit.DEFDWN)
            {
                status2.transform.GetChild(0).gameObject.SetActive(false);
                status2.transform.GetChild(1).gameObject.SetActive(true);
            }

            status2.SetActive(true);
        }
        else
        {
            status2.SetActive(false);
            status2.transform.GetChild(0).gameObject.SetActive(false);
            status2.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (unit.MAGUP || unit.MAGDWN)
        {
            status3.GetComponentInChildren<TextMeshProUGUI>().text = unit.defCounter.ToString();
            if (unit.MAGUP)
            {
                status3.transform.GetChild(1).gameObject.SetActive(false);
                status3.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (unit.MAGDWN)
            {
                status3.transform.GetChild(0).gameObject.SetActive(false);
                status3.transform.GetChild(1).gameObject.SetActive(true);
            }

            status3.SetActive(true);
        }
        else
        {
            status3.SetActive(false);
            status3.transform.GetChild(0).gameObject.SetActive(false);
            status3.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (unit.RESUP || unit.RESDWN)
        {
            status4.GetComponentInChildren<TextMeshProUGUI>().text = unit.defCounter.ToString();
            if (unit.RESUP)
            {
                status4.transform.GetChild(1).gameObject.SetActive(false);
                status4.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (unit.RESDWN)
            {
                status4.transform.GetChild(0).gameObject.SetActive(false);
                status4.transform.GetChild(1).gameObject.SetActive(true);
            }

            status4.SetActive(true);
        }
        else
        {
            status4.SetActive(false);
            status4.transform.GetChild(0).gameObject.SetActive(false);
            status4.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (unit.PSN)
        {
            // Poison has no counter
            //status4.GetComponentInChildren<TextMeshProUGUI>().text = unit.defCounter.ToString();
            status5.transform.GetChild(0).gameObject.SetActive(true);

            status5.SetActive(true);
        }
        else
        {
            status5.SetActive(false);
            status5.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void updateHUD_Enemy(Character unit, GameObject status1, GameObject status2, GameObject status3, GameObject status4, GameObject status5)
    {
        if (unit.ATKUP || unit.ATKDWN)
        {
            //tatus1.GetComponentInChildren<TextMeshProUGUI>().text = unit.atkCounter.ToString();
            if (unit.ATKUP)
            {
                Debug.Log(unit.characterName + " has an Attack Up for " + unit.atkCounter + " more turns.");
                status1.transform.GetChild(1).gameObject.SetActive(false);
                status1.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (unit.ATKDWN)
            {
                Debug.Log(unit.characterName + " has an Attack Down for " + unit.atkCounter + " more turns.");
                status1.transform.GetChild(0).gameObject.SetActive(false);
                status1.transform.GetChild(1).gameObject.SetActive(true);
            }

            status1.SetActive(true);
        }
        else
        {
            Debug.Log(unit.characterName + " has no Attack Buff/Debuff");
            status1.SetActive(false);
            status1.transform.GetChild(0).gameObject.SetActive(false);
            status1.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (unit.DEFUP || unit.DEFDWN)
        {
            //status2.GetComponentInChildren<TextMeshProUGUI>().text = unit.defCounter.ToString();
            if (unit.DEFUP)
            {
                status2.transform.GetChild(1).gameObject.SetActive(false);
                status2.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (unit.DEFDWN)
            {
                status2.transform.GetChild(0).gameObject.SetActive(false);
                status2.transform.GetChild(1).gameObject.SetActive(true);
            }

            status2.SetActive(true);
        }
        else
        {
            status2.SetActive(false);
            status2.transform.GetChild(0).gameObject.SetActive(false);
            status2.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (unit.MAGUP || unit.MAGDWN)
        {
            //status3.GetComponentInChildren<TextMeshProUGUI>().text = unit.defCounter.ToString();
            if (unit.MAGUP)
            {
                status3.transform.GetChild(1).gameObject.SetActive(false);
                status3.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (unit.MAGDWN)
            {
                status3.transform.GetChild(0).gameObject.SetActive(false);
                status3.transform.GetChild(1).gameObject.SetActive(true);
            }

            status3.SetActive(true);
        }
        else
        {
            status3.SetActive(false);
            status3.transform.GetChild(0).gameObject.SetActive(false);
            status3.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (unit.RESUP || unit.RESDWN)
        {
            //status4.GetComponentInChildren<TextMeshProUGUI>().text = unit.defCounter.ToString();
            if (unit.RESUP)
            {
                status4.transform.GetChild(1).gameObject.SetActive(false);
                status4.transform.GetChild(0).gameObject.SetActive(true);
            }
            else if (unit.RESDWN)
            {
                status4.transform.GetChild(0).gameObject.SetActive(false);
                status4.transform.GetChild(1).gameObject.SetActive(true);
            }

            status4.SetActive(true);
        }
        else
        {
            status4.SetActive(false);
            status4.transform.GetChild(0).gameObject.SetActive(false);
            status4.transform.GetChild(1).gameObject.SetActive(false);
        }

        if (unit.PSN)
        {
            // Poison has no counter
            //status4.GetComponentInChildren<TextMeshProUGUI>().text = unit.defCounter.ToString();
            status5.transform.GetChild(0).gameObject.SetActive(true);

            status5.SetActive(true);
        }
        else
        {
            status5.SetActive(false);
            status5.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void updatePartyHUD()
    {
        if (p1_exists)
        {
            updateHUD(p1, p1HP, p1MP, p1_status1, p1_status2, p1_status3, p1_status4, p1_status5);
        }
        if (p2_exists)
        {
            updateHUD(p2, p2HP, p2MP, p2_status1, p2_status2, p2_status3, p2_status4, p2_status5);
        }
        if (p3_exists)
        {
            updateHUD(p3, p3HP, p3MP, p3_status1, p3_status2, p3_status3, p3_status4, p3_status5);
        }
        if (p4_exists)
        {
            updateHUD(p4, p4HP, p4MP, p4_status1, p4_status2, p4_status3, p4_status4, p4_status5);
        }
    }

    public void updatePartyHUD_Enemy()
    {
        if (en1_exists)
        {
            updateHUD_Enemy(en_1, en1_status1, en1_status2, en1_status3, en1_status4, en1_status5);
        }

        if (en2_exists)
        {
            updateHUD_Enemy(en_2, en2_status1, en2_status2, en2_status3, en2_status4, en2_status5);
        }

        if (en3_exists)
        {
            updateHUD_Enemy(en_3, en3_status1, en3_status2, en3_status3, en3_status4, en3_status5);
        }
    }
    public IEnumerator checkPlayerKO()
    {
        // This short pause prevents this text from overlapping with the enemy's attack text
        yield return new WaitForSeconds(1f);
        Debug.Log("Checking Player HP...");
        if (p1_exists)
        {
            p1.checkHP();

            if (p1.KO == true && p1.currKO == false)
            {
                p1.currKO = true;
                battleDialogue(p1.characterName + " has been KO'd!");
                yield return new WaitForSeconds(2f);
            }
        }
        if (p2_exists)
        {
            p2.checkHP();

            if (p2.KO == true && p2.currKO == false)
            {
                p2.currKO = true;
                battleDialogue(p2.characterName + " has been KO'd!");
                yield return new WaitForSeconds(2f);
            }
        }
        if (p3_exists)
        {
            p3.checkHP();

            if (p3.KO == true && p3.currKO == false)
            {
                p3.currKO = true;
                battleDialogue(p3.characterName + " has been KO'd!");
                yield return new WaitForSeconds(2f);
            }
        }
        if (p4_exists)
        {
            p4.checkHP();
            if (p4.KO == true && p4.currKO == false)
            {
                p4.currKO = true;
                battleDialogue(p4.characterName + " has been KO'd!");
                yield return new WaitForSeconds(2f);
            }
        }

        yield return new WaitForSeconds(0.1f);
    }

    public void enemyKO()
    {
        Debug.Log("Checking enemy KO...");
        if (en1_exists)
        {
            if (en_1.KO == true)
            {
                Debug.Log("Enemy 1 should be KO'd");
                //Debug.Log(en_g1.GetComponent<SpriteRenderer>().color);
                en_g1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
            } else
            {
                en_g1.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }

        if (en2_exists)
        {
            if (en_2.KO == true)
            {
                //Debug.Log(en_g2.GetComponent<SpriteRenderer>().color);
                en_g2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
            }else
            {
                en_g2.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }

        if (en3_exists)
        {
            if (en_3.KO == true)
            {
                //Debug.Log(en_g3.GetComponent<SpriteRenderer>().color);
                en_g3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
            }else
            {
                en_g3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }
    }

    public void checkBattleState()
    {
        Debug.Log("Checking Battle Status...");
        int i = 0;
        Debug.Log(GM.GetComponent<GameManager>().enemyParty.ToString());
        Debug.Log(GM.GetComponent<GameManager>().enemyParty.Count);
        //Debug.Log(GM.GetComponent<GameManager>().enemyParty[0].characterName);
        foreach (Character c in GM.GetComponent<GameManager>().enemyParty)
        {
            if (c.KO == true)
            {
                i++;
            }
        }

        Debug.Log("Enemy: " + i + " vs. " + enemyCount);
        if (i == enemyCount)
        {
            state = BattleState.WON;
            endBattle = true;
            Debug.Log("Player has won the battle! BATTLE WON!");
            //StopAllCoroutines();
            battleWon();
        }

        i = 0;

        foreach (Character c in GM.GetComponent<GameManager>().playerParty)
        {
            if (c.KO == true)
            {
                i++;
            }
        }

        Debug.Log("Players: " + i + " vs. " + playerCount);

        if (i == playerCount)
        {
            state = BattleState.LOST;
            endBattle = true;
            //StopAllCoroutines();
            //battleDialogue("Player's Party has Fallen! GAME OVER!");
            Debug.Log("Player has lost the battle! GAME OVER");
            battleLost();
        }
    }

    public void battleWon()
    {
        //StopAllCoroutines();
        battleDialogue("Player's Party is Victorious! BATTLE WON!");
        StartCoroutine(victoryWindow());
    }

    public IEnumerator victoryWindow()
    {
        yield return new WaitForSeconds(1f);
        battleWinWindow.SetActive(true);
        if (p1_exists)
        {
            yield return new WaitForSeconds(1f);
            p1.levelUP();
            p1Level_t.text = "Player 1 - Level UP - HP: " + p1.maxHP + "(" + p1.growthText[0] + ") MP: " + p1.maxMP + "(" + p1.growthText[1] + ") ATK: " + p1.attack + "(" + p1.growthText[2] + ") DEF: " + p1.defense + "(" + p1.growthText[3] + ") MAG: " + p1.magic + "(" + p1.growthText[4] + ") RES: " + p1.resistance + "(" + p1.growthText[5] + ")";
            p1Level.SetActive(true);
        }
        if (p2_exists)
        {
            yield return new WaitForSeconds(1f);
            p2.levelUP();
            p2Level_t.text = "Player 2 - Level UP - HP: " + p2.maxHP + "(" + p2.growthText[0] + ") MP: " + p2.maxMP + "(" + p2.growthText[1] + ") ATK: " + p2.attack + "(" + p2.growthText[2] + ") DEF: " + p2.defense + "(" + p2.growthText[3] + ") MAG: " + p2.magic + "(" + p2.growthText[4] + ") RES: " + p2.resistance + "(" + p2.growthText[5] + ")";
            p2Level.SetActive(true);
        }
        if (p3_exists)
        {
            yield return new WaitForSeconds(1f);
            p3.levelUP();
            p3Level_t.text = "Player 3 - Level UP - HP: " + p3.maxHP + "(" + p3.growthText[0] + ") MP: " + p3.maxMP + "(" + p3.growthText[1] + ") ATK: " + p3.attack + "(" + p3.growthText[2] + ") DEF: " + p3.defense + "(" + p3.growthText[3] + ") MAG: " + p3.magic + "(" + p3.growthText[4] + ") RES: " + p3.resistance + "(" + p3.growthText[5] + ")";
            p3Level.SetActive(true);
        }
        if (p4_exists)
        {
            yield return new WaitForSeconds(1f);
            p4.levelUP();
            p4Level_t.text = "Player 4 - Level UP - HP: " + p4.maxHP + "(" + p4.growthText[0] + ") MP: " + p4.maxMP + "(" + p4.growthText[1] + ") ATK: " + p4.attack + "(" + p4.growthText[2] + ") DEF: " + p4.defense + "(" + p4.growthText[3] + ") MAG: " + p4.magic + "(" + p4.growthText[4] + ") RES: " + p4.resistance + "(" + p4.growthText[5] + ")";
            p4Level.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        GM.GetComponent<GameManager>().Gold += GM.GetComponent<EnemyFormations>().goldTable[partyInformation.Instance.enemyPartyIndex];
        goldGained_t.text = "Gold Gained -  " + GM.GetComponent<GameManager>().Gold + " (+ " + GM.GetComponent<EnemyFormations>().goldTable[partyInformation.Instance.enemyPartyIndex] + ")";
        goldGained.SetActive(true);
        storeStats();
        //GM.GetComponent<GameManager>().Gold += GM.GetComponent<EnemyFormations>().goldTable[0];

    }
    public void battleLost()
    {
        //yield return new WaitForSeconds(2f);
        battleDialogue("Player's Party has Fallen! GAME OVER!");
        StartCoroutine(gameOver());
    }

    public IEnumerator gameOver()
    {
        yield return new WaitForSeconds(2f);
        int exp = UnityEngine.Random.Range(500, 2500);
        battleDialogue("Enemy Party gained " + exp + " exp!\n Enemy Party gained " + FindObjectOfType<GameManager>().Gold + " Gold!");
        yield return new WaitForSeconds(2f);
        Debug.Log("Load Game Over");
        FindObjectOfType<GameManager>().loadGameOver();
    }

    public void createSkillList()
    {
        //GameObject b1, b2, b3, b4;
        switch (activeUser.skillList.Count)
        {
            case 1:
                Debug.Log("1 skill found");
                //p1skill1;
                aS1t.text = activeUser.skillList[0];
                aS1.SetActive(true);
                break;
            case 2:
                Debug.Log("2 skills found");
                aS1t.text = activeUser.skillList[0];
                aS1.SetActive(true);
                aS2t.text = activeUser.skillList[1];
                aS2.SetActive(true);
                break;
            case 3:
                Debug.Log("3 skills found");
                aS1t.text = activeUser.skillList[0];
                aS1.SetActive(true);
                aS2t.text = activeUser.skillList[1];
                aS2.SetActive(true);
                aS3t.text = activeUser.skillList[2];
                aS3.SetActive(true);
                break;
            case 4:
                Debug.Log("4 skills found");
                aS1t.text = activeUser.skillList[0];
                aS1.SetActive(true);
                aS2t.text = activeUser.skillList[1];
                aS2.SetActive(true);
                aS3t.text = activeUser.skillList[2];
                aS3.SetActive(true);
                aS4t.text = activeUser.skillList[3];
                aS4.SetActive(true);
                break;
            default:
                Debug.Log("0 skills found");
                break;
        }
    }

    IEnumerator playerTurn()
    {
        Debug.Log("Player phase - Start");

        if (p1_exists && state == BattleState.PLAYERTURN && endBattle != true)
        {
            p1.isDefending = false;
            if (p1.KO != true)
            {

                turnFinished = false;
                p1Menu.SetActive(true);
                activeUser = p1;
                activeUI = p1Menu;
                activeSkills = p1Skills;

                aS1 = p1_1;
                aS2 = p1_2;
                aS3 = p1_3;
                aS4 = p1_4;

                aB1 = p1skill1;
                aB2 = p1skill2;
                aB3 = p1skill3;
                aB4 = p1skill4;

                aS1t = p1skill1_t;
                aS2t = p1skill2_t;
                aS3t = p1skill3_t;
                aS4t = p1skill4_t;
                battleDialogue("What will " + p1.characterName + " do?");

                Debug.Log("Waiting for Player 1 (" + p1.characterName + ") input");
                while (!turnFinished)
                {
                    yield return null;
                }

                Debug.Log("Player 1 (" + p1.characterName + ") turn finished");

                // Tick Poison damage when applicable
                p1.poisonDamage();

                // Regen should be able to negate poison damage
                if (p1.pass == Passive.REGENERATOR)
                {
                   // p1.regen();
                }

                p1.decreaseStatus();

                updatePartyHUD();
                enemyKO();
                updatePartyHUD_Enemy();

                yield return new WaitForSeconds(2f);
            }
            checkBattleState();
        }

        //checkBattleState();

        if (p2_exists && state == BattleState.PLAYERTURN && endBattle != true)
        {
            p2.isDefending = false;
            if (p2.KO != true)
            {

                turnFinished = false;
                p2Menu.SetActive(true);
                activeUser = p2;
                activeUI = p2Menu;

                activeSkills = p2Skills;

                aS1 = p2_1;
                aS2 = p2_2;
                aS3 = p2_3;
                aS4 = p2_4;

                aB1 = p2skill1;
                aB2 = p2skill2;
                aB3 = p2skill3;
                aB4 = p2skill4;

                aS1t = p2skill1_t;
                aS2t = p2skill2_t;
                aS3t = p2skill3_t;
                aS4t = p2skill4_t;

                battleDialogue("What will " + p2.characterName + " do?");

                Debug.Log("Waiting for Player 2 (" + p2.characterName + ") input");
                while (!turnFinished)
                {
                    yield return null;
                }
                Debug.Log("Player 2 (" + p2.characterName + ") turn finished");

                p2.poisonDamage();

                if (p2.pass == Passive.REGENERATOR)
                {
                    p2.regen();
                }

                p2.decreaseStatus();

                updatePartyHUD();
                enemyKO();
                updatePartyHUD_Enemy();

                yield return new WaitForSeconds(2f);
            }
            checkBattleState();
        }

        //checkBattleState();
        

        if (p3_exists && state == BattleState.PLAYERTURN && endBattle != true)
        {
            p3.isDefending = false;
            if (p3.KO != true)
            {

                turnFinished = false;
                p3Menu.SetActive(true);
                activeUser = p3;
                activeUI = p3Menu;

                activeSkills = p3Skills;

                aS1 = p3_1;
                aS2 = p3_2;
                aS3 = p3_3;
                aS4 = p3_4;

                aB1 = p3skill1;
                aB2 = p3skill2;
                aB3 = p3skill3;
                aB4 = p3skill4;

                aS1t = p3skill1_t;
                aS2t = p3skill2_t;
                aS3t = p3skill3_t;
                aS4t = p3skill4_t;

                battleDialogue("What will " + p3.characterName + " do?");

                Debug.Log("Waiting for Player 3 (" + p3.characterName + ") input");
                while (!turnFinished)
                {
                    yield return null;
                }
                Debug.Log("Player 3 (" + p3.characterName + ") turn finished");

                p3.poisonDamage();

                if (p3.pass == Passive.REGENERATOR)
                {
                    p3.regen();
                }

                p3.decreaseStatus();

                updatePartyHUD();
                enemyKO();
                updatePartyHUD_Enemy();

                yield return new WaitForSeconds(2f);
            }
            checkBattleState();
        }

        //checkBattleState();
        //StartCoroutine(checkBattleState());

        if (p4_exists && state == BattleState.PLAYERTURN && endBattle != true)
        {
            p4.isDefending = false;
            if (p4.KO != true)
            {

                turnFinished = false;
                p4Menu.SetActive(true);
                activeUser = p4;
                activeUI = p4Menu;

                activeSkills = p4Skills;

                aS1 = p4_1;
                aS2 = p4_2;
                aS3 = p4_3;
                aS4 = p4_4;

                aB1 = p4skill1;
                aB2 = p4skill2;
                aB3 = p4skill3;
                aB4 = p4skill4;

                aS1t = p4skill1_t;
                aS2t = p4skill2_t;
                aS3t = p4skill3_t;
                aS4t = p4skill4_t;

                battleDialogue("What will " + p4.characterName + " do?");

                Debug.Log("Waiting for Player 4 (" + p4.characterName + ") input");
                while (!turnFinished)
                {
                    yield return null;
                }
                Debug.Log("Player 4 (" + p4.characterName + ") turn finished");

                p4.poisonDamage();

                if (p4.pass == Passive.REGENERATOR)
                {
                    p4.regen();
                }

                p4.decreaseStatus();

                updatePartyHUD();
                enemyKO();
                updatePartyHUD_Enemy();

                yield return new WaitForSeconds(2f);
            }
            checkBattleState();
        }

        //checkBattleState();

        /*
        GameManager GS = FindObjectOfType<GameManager>();
        int i = 0;
        foreach (Character c in GS.playerParty)
        {
            if (c.type == "DUMMY")
            {
                i++;
            }
        }
        int range = GS.playerParty.Count - i;

        Debug.Log("Enemy AI range: " + (range - 1));
        */
        // Start the enemy Turn 
        //state = BattleState.ENEMYTURN;
        if (endBattle == false)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(enemyTurn());
        }
    }
    
    IEnumerator enemyTurn()
    {
        Debug.Log("ENEMY PHASE - Start");
        //yield return null;

        // Todo, make a check to see if an enemy is alive before performing their AI
        int numEnemies = GM.GetComponent<GameManager>().enemyParty.Count;
        int i = 0;
        //Debug.Log(GM.GetComponent<GameManager>().enemyParty.ToString());


        foreach (Character c in GM.GetComponent<GameManager>().enemyParty)
        {
            // Enemies who have been KO'd cannot attack
            if (c.KO != true && state == BattleState.ENEMYTURN && endBattle != true)
            {
                Debug.Log(c.characterName + " (" + i + ") is about to attack.");
                c.enemyAI(c);
                i++;

                c.decreaseStatus();
                c.poisonDamage();
                updatePartyHUD();
                StartCoroutine(checkPlayerKO());
                Debug.Log("Enemy turn " + i + " end");
                //checkBattleState();

                yield return new WaitForSeconds(2f);
            }
            checkBattleState();

            if (state == BattleState.LOST)
            {
                break;
            }
        }

        updatePartyHUD_Enemy();
        /**
        for ( int i = 0; i < numEnemies - 1; i++)
        {
            GM.GetComponent<GameManager>().enemyParty[i].enemyAI(GM.GetComponent<GameManager>().enemyParty[i]);
            //battleDialogue(GM.GetComponent<GameManager>().enemyParty[i].characterName + " attacks ")
            yield return new WaitForSeconds(2f);
        }
        */
        /**
        if (GM.GetComponent<GameManager>().enemyParty[0].type != "DUMMY")
        {
            turnFinished = false;
            p1Menu.SetActive(true);
            activeUser = p1;
            activeUI = p1Menu;
            battleDialogue("What will " + p1.characterName + " do?");

            Debug.Log("Waiting for Player 1 (" + p1.characterName + ") input");
            while (!turnFinished)
            {
                yield return null;
            }
            Debug.Log("Player 1 (" + p1.characterName + ") turn finished");
            yield return new WaitForSeconds(2f);
        }
        */

        // Restart the player Turn
        if (endBattle == false)
        {
            state = BattleState.PLAYERTURN;
            StartCoroutine(playerTurn());
        }
    }

    public void buttonAttack()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(sk.attack());
        //StartCoroutine(sk.luckyStar());
    }

    public void buttonDefend()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(sk.defend());
    }

    public void buttonInventory()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        activeUI.SetActive(false);
        FindObjectOfType<Inventory>().openInventory();
    }

    public void buttonCloseInventory()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        FindObjectOfType<Inventory>().closeInventory();
        activeUI.SetActive(true);
    }

    public void openSkills()
    {
        Debug.Log(activeUser.characterName + "'s number of skills: " + (activeUser.skillList.Count));
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        if(activeUser.skillList.Count == 0)
        {
            Debug.Log(activeUser.characterName + " has no skills!");
            return;
        }
        activeUI.SetActive(false);
        activeSkills.SetActive(true);
        createSkillList();

    }

    public void callSkill()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        string t = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(t);
        Debug.Log("Skill Called!");

        switch (t)
        {
            case "Lucky Star (5)":
                if (activeUser.mp < 5)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 5;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running Luck Star~™...");
                StartCoroutine(sk.luckyStar());
                break;

            case "Heal (3)":
                if (activeUser.mp < 3)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 3;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running heal...");
                StartCoroutine(sk.heal());
                break;

            case "Rally ATK (4)":
                if (activeUser.mp < 4)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 4;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running Rally Attack...");
                StartCoroutine(sk.rallyATK());
                break;

            case "Rally DEF (4)":
                if (activeUser.mp < 4)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 4;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running Rally Defense...");
                StartCoroutine(sk.rallyDEF());
                break;

            case "Rally MAG (4)":
                if (activeUser.mp < 4)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 4;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running Rally Magic...");
                StartCoroutine(sk.rallyMAG());
                break;

            case "Rally RES (4)":
                if (activeUser.mp < 4)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 4;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running Rally Resistance...");
                StartCoroutine(sk.rallyRES());
                break;

            case "Nuke (1)":
                if (activeUser.mp < 1)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 1;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running NUKE...");
                StartCoroutine(sk.nuke());
                break;

            case "Poison Spore (3)":
                if (activeUser.mp < 3)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 3;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running Poison Spore...");
                StartCoroutine(sk.poisonSpore());
                break;

            case "Heal Spore (7)":
                if (activeUser.mp < 7)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 7;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running Heal Spore...");
                StartCoroutine(sk.healSpore());
                break;

            case "Wild Swing (4)":
                if (activeUser.mp < 4)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 4;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running Wild Swing...");
                StartCoroutine(sk.wildSwing());
                break;

            case "Ghastly Wail (6)":
                if (activeUser.mp < 1)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 1;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running Ghastly Wail...");
                StartCoroutine(sk.ghastlyWail());
                break;

            case "Armor Smash (5)":
                if (activeUser.mp < 1)
                {
                    battleDialogue("Not enough MP!");
                    return;
                }
                activeUser.mp -= 1;
                Debug.Log(activeUser.characterName + "'s MP: " + activeUser.mp + "/" + activeUser.maxMP);
                Debug.Log("Running Armor Smash...");
                StartCoroutine(sk.armorSmash());
                break;

            default:
                // Anti-Soft Lock check
                // If a skill that doesn't exist is called for some reason, pressing the button does nothing and keeps the skill list up
                Debug.Log("No Skill Found Error (?) - This shouldn't happen normally");
                return;
        }

        activeSkills.SetActive(false);
        aS1.SetActive(false);
        aS2.SetActive(false);
        aS3.SetActive(false);
        aS4.SetActive(false);
    }

    public void buttonLuckyStar()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(sk.luckyStar());
    }

    // Item Button Code
    public void usePotion()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if(partyInformation.Instance.potion <= 0)
        {
            Debug.Log("You have no Potions!");
            return;
        }

        partyInformation.Instance.potion -= 1;
        Debug.Log("Potions remaining: " + partyInformation.Instance.potion);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running Potion...");
        StartCoroutine(sk.potion());
    }

    public void useHiPotion()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (partyInformation.Instance.hiPotion <= 0)
        {
            Debug.Log("You have no HiPotions!");
            return;
        }

        partyInformation.Instance.hiPotion -= 1;
        Debug.Log("Hi-Potions remaining: " + partyInformation.Instance.hiPotion);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running HiPotion...");
        StartCoroutine(sk.hiPotion());
    }

    public void useEther()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (partyInformation.Instance.ether <= 0)
        {
            Debug.Log("You have no ethers!");
            return;
        }

        partyInformation.Instance.ether -= 1;
        Debug.Log("Ethers remaining: " + partyInformation.Instance.ether);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running ether...");
        StartCoroutine(sk.ether());
    }

    public void useHiEther()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (partyInformation.Instance.hiEther <= 0)
        {
            Debug.Log("You have no hi-ethers!");
            return;
        }

        partyInformation.Instance.hiEther -= 1;
        Debug.Log("Hi-Ethers remaining: " + partyInformation.Instance.hiEther);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running hi-ether...");
        StartCoroutine(sk.hiEther());
    }

    public void useFullPotion()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (partyInformation.Instance.fullPotion <= 0)
        {
            Debug.Log("You have no full potions!");
            return;
        }

        partyInformation.Instance.fullPotion -= 1;
        Debug.Log("Full Potions remaining: " + partyInformation.Instance.fullPotion);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running full potion...");
        StartCoroutine(sk.fullPotion());
    }

    public void useRefresh()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (partyInformation.Instance.refresh <= 0)
        {
            Debug.Log("You have no refreshes!");
            return;
        }

        partyInformation.Instance.refresh -= 1;
        Debug.Log("Refreshes remaining: " + partyInformation.Instance.refresh);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running refresh...");
        StartCoroutine(sk.refresh());
    }

    public void useRevivalHerb()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (partyInformation.Instance.revivalHerb <= 0)
        {
            Debug.Log("You have no revival herb!");
            return;
        }

        // This item should ONLY work if there is a KO'd ally
        // If not, this would cause a softlock
        bool KOCheck = false;

        foreach (Character c in GM.GetComponent<GameManager>().playerParty)
        {
            if (c.type != "DUMMY")
            {
                if (c.KO == true)
                {
                    KOCheck = true;
                }
            }
        }

        if (KOCheck == false)
        {
            battleDialogue("No use for this item! (No KO'd allies)");
            return;
        }

        partyInformation.Instance.revivalHerb -= 1;
        Debug.Log("Revival Herbs remaining: " + partyInformation.Instance.revivalHerb);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running revival herb...");
        StartCoroutine(sk.revivalHerb());
    }
    public void usePavise()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (partyInformation.Instance.pavise <= 0)
        {
            Debug.Log("You have no Pavises!");
            return;
        }

        partyInformation.Instance.pavise -= 1;
        Debug.Log("Pavises remaining: " + partyInformation.Instance.pavise);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running Pavise...");
        StartCoroutine(sk.pavise());
    }

    public void useWardingCharm()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (partyInformation.Instance.wardingCharm <= 0)
        {
            Debug.Log("You have no Warding Charms!");
            return;
        }

        partyInformation.Instance.wardingCharm -= 1;
        Debug.Log("Warding Charms remaining: " + partyInformation.Instance.wardingCharm);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running Warding Charm...");
        StartCoroutine(sk.wardingCharm());
    }

    public void useMandragora()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (partyInformation.Instance.mandragora <= 0)
        {
            Debug.Log("You have no Mandragoras!");
            return;
        }

        partyInformation.Instance.mandragora -= 1;
        Debug.Log("Mandragora remaining: " + partyInformation.Instance.mandragora);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running Mandragora...");
        StartCoroutine(sk.mandragora());
    }
    public void useBomb()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (partyInformation.Instance.bomb <= 0)
        {
            Debug.Log("You have no Bombs!");
            return;
        }

        partyInformation.Instance.bomb -= 1;
        Debug.Log("Bombs remaining: " + partyInformation.Instance.bomb);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running Bomb...");
        StartCoroutine(sk.bomb());
    }

    public void useGasBomb()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (FindObjectOfType<Inventory>().gasBomb <= 0)
        {
            Debug.Log("You have no Gas Bombs!");
            return;
        }

        FindObjectOfType<Inventory>().gasBomb -= 1;
        Debug.Log("Potions remaining: " + FindObjectOfType<Inventory>().gasBomb);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running Gas Bomb...");
        StartCoroutine(sk.gasBomb());
    }

    public void useSmokeBomb()
    {
        //partyInformation.Instance.difficulty = 3;
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        if (partyInformation.Instance.smokeBomb <= 0)
        {
            Debug.Log("You have no Smoke Bombs!");
            return;
        }

        if(partyInformation.Instance.difficulty == 3 || partyInformation.Instance.difficulty == 5)
        {
            battleDialogue("You can't escape this fight!");
            return;
        }

        partyInformation.Instance.smokeBomb -= 1;
        Debug.Log("Smoke Bombs remaining: " + partyInformation.Instance.smokeBomb);
        FindObjectOfType<Inventory>().closeInventory();
        Debug.Log("Running Smoke Bomb...");
        StartCoroutine(sk.smokeBomb());
    }

    // Skill Check Codes

    void intimidate(Character unit)
    {
        foreach (Character c in GM.GetComponent<GameManager>().enemyParty)
        {
            c.attackDown();
            /*
            c.defenseDown();
            c.magicDown();
            c.resDown();
            c.poison();
            */
        }

        battleDialogue(unit.characterName + "'s Intimidation cut the enemy party's attack!");
    }

     bool intimidateCheck()
    {
        bool timid = false;

        foreach(Character c in GM.GetComponent<GameManager>().playerParty)
        {
            if (c.type != "DUMMY")
            {
                if (c.pass == Passive.INTIMIDATE)
                {
                    timid = true;
                    activeUser = c;
                }
            }
        }

        return timid;
    }

    public void storeStats()
    {
        partyInformation.Instance.p1Type = GM.GetComponent<GameManager>().playerParty[0].type;
        partyInformation.Instance.p1Name = GM.GetComponent<GameManager>().playerParty[0].characterName;
        partyInformation.Instance.p1hp = GM.GetComponent<GameManager>().playerParty[0].hp;
        partyInformation.Instance.p1maxHP = GM.GetComponent<GameManager>().playerParty[0].maxHP;
        partyInformation.Instance.p1mp = GM.GetComponent<GameManager>().playerParty[0].mp;
        partyInformation.Instance.p1maxMP = GM.GetComponent<GameManager>().playerParty[0].maxMP;
        partyInformation.Instance.p1attack = GM.GetComponent<GameManager>().playerParty[0].attack;
        partyInformation.Instance.p1defense = GM.GetComponent<GameManager>().playerParty[0].defense;
        partyInformation.Instance.p1magic = GM.GetComponent<GameManager>().playerParty[0].magic;
        partyInformation.Instance.p1resistance = GM.GetComponent<GameManager>().playerParty[0].resistance;
        partyInformation.Instance.p1hpGrowth = GM.GetComponent<GameManager>().playerParty[0].hpGrowth;
        partyInformation.Instance.p1atkGrowth = GM.GetComponent<GameManager>().playerParty[0].atkGrowth;
        partyInformation.Instance.p1defGrowth = GM.GetComponent<GameManager>().playerParty[0].defGrowth;
        partyInformation.Instance.p1magGrowth = GM.GetComponent<GameManager>().playerParty[0].magGrowth;
        partyInformation.Instance.p1resGrowth = GM.GetComponent<GameManager>().playerParty[0].resGrowth;
        partyInformation.Instance.p1growthList = GM.GetComponent<GameManager>().playerParty[0].growthList;
        partyInformation.Instance.p1skillList = GM.GetComponent<GameManager>().playerParty[0].skillList;
        partyInformation.Instance.p1growthText = GM.GetComponent<GameManager>().playerParty[0].growthText;
        partyInformation.Instance.p1weak = GM.GetComponent<GameManager>().playerParty[0].weak;
        partyInformation.Instance.p1strong = GM.GetComponent<GameManager>().playerParty[0].strong;
        partyInformation.Instance.p1immune = GM.GetComponent<GameManager>().playerParty[0].immune;

        partyInformation.Instance.p2Type = GM.GetComponent<GameManager>().playerParty[1].type;
        partyInformation.Instance.p2Name = GM.GetComponent<GameManager>().playerParty[1].characterName;
        partyInformation.Instance.p2hp = GM.GetComponent<GameManager>().playerParty[1].hp;
        partyInformation.Instance.p2maxHP = GM.GetComponent<GameManager>().playerParty[1].maxHP;
        partyInformation.Instance.p2mp = GM.GetComponent<GameManager>().playerParty[1].mp;
        partyInformation.Instance.p2maxMP = GM.GetComponent<GameManager>().playerParty[1].maxMP;
        partyInformation.Instance.p2attack = GM.GetComponent<GameManager>().playerParty[1].attack;
        partyInformation.Instance.p2defense = GM.GetComponent<GameManager>().playerParty[1].defense;
        partyInformation.Instance.p2magic = GM.GetComponent<GameManager>().playerParty[1].magic;
        partyInformation.Instance.p2resistance = GM.GetComponent<GameManager>().playerParty[1].resistance;
        partyInformation.Instance.p2hpGrowth = GM.GetComponent<GameManager>().playerParty[1].hpGrowth;
        partyInformation.Instance.p2atkGrowth = GM.GetComponent<GameManager>().playerParty[1].atkGrowth;
        partyInformation.Instance.p2defGrowth = GM.GetComponent<GameManager>().playerParty[1].defGrowth;
        partyInformation.Instance.p2magGrowth = GM.GetComponent<GameManager>().playerParty[1].magGrowth;
        partyInformation.Instance.p2resGrowth = GM.GetComponent<GameManager>().playerParty[1].resGrowth;
        partyInformation.Instance.p2growthList = GM.GetComponent<GameManager>().playerParty[1].growthList;
        partyInformation.Instance.p2skillList = GM.GetComponent<GameManager>().playerParty[1].skillList;
        partyInformation.Instance.p2growthText = GM.GetComponent<GameManager>().playerParty[1].growthText;
        partyInformation.Instance.p2weak = GM.GetComponent<GameManager>().playerParty[1].weak;
        partyInformation.Instance.p2strong = GM.GetComponent<GameManager>().playerParty[1].strong;
        partyInformation.Instance.p2immune = GM.GetComponent<GameManager>().playerParty[1].immune;

        partyInformation.Instance.p3Type = GM.GetComponent<GameManager>().playerParty[2].type;
        partyInformation.Instance.p3Name = GM.GetComponent<GameManager>().playerParty[2].characterName;
        partyInformation.Instance.p3hp = GM.GetComponent<GameManager>().playerParty[2].hp;
        partyInformation.Instance.p3maxHP = GM.GetComponent<GameManager>().playerParty[2].maxHP;
        partyInformation.Instance.p3mp = GM.GetComponent<GameManager>().playerParty[2].mp;
        partyInformation.Instance.p3maxMP = GM.GetComponent<GameManager>().playerParty[2].maxMP;
        partyInformation.Instance.p3attack = GM.GetComponent<GameManager>().playerParty[2].attack;
        partyInformation.Instance.p3defense = GM.GetComponent<GameManager>().playerParty[2].defense;
        partyInformation.Instance.p3magic = GM.GetComponent<GameManager>().playerParty[2].magic;
        partyInformation.Instance.p3resistance = GM.GetComponent<GameManager>().playerParty[2].resistance;
        partyInformation.Instance.p3hpGrowth = GM.GetComponent<GameManager>().playerParty[2].hpGrowth;
        partyInformation.Instance.p3atkGrowth = GM.GetComponent<GameManager>().playerParty[2].atkGrowth;
        partyInformation.Instance.p3defGrowth = GM.GetComponent<GameManager>().playerParty[2].defGrowth;
        partyInformation.Instance.p3magGrowth = GM.GetComponent<GameManager>().playerParty[2].magGrowth;
        partyInformation.Instance.p3resGrowth = GM.GetComponent<GameManager>().playerParty[2].resGrowth;
        partyInformation.Instance.p3growthList = GM.GetComponent<GameManager>().playerParty[2].growthList;
        partyInformation.Instance.p3skillList = GM.GetComponent<GameManager>().playerParty[2].skillList;
        partyInformation.Instance.p3growthText = GM.GetComponent<GameManager>().playerParty[2].growthText;
        partyInformation.Instance.p3weak = GM.GetComponent<GameManager>().playerParty[2].weak;
        partyInformation.Instance.p3strong = GM.GetComponent<GameManager>().playerParty[2].strong;
        partyInformation.Instance.p3immune = GM.GetComponent<GameManager>().playerParty[2].immune;

        partyInformation.Instance.p4Type = GM.GetComponent<GameManager>().playerParty[3].type;
        partyInformation.Instance.p4Name = GM.GetComponent<GameManager>().playerParty[3].characterName;
        partyInformation.Instance.p4hp = GM.GetComponent<GameManager>().playerParty[3].hp;
        partyInformation.Instance.p4maxHP = GM.GetComponent<GameManager>().playerParty[3].maxHP;
        partyInformation.Instance.p4mp = GM.GetComponent<GameManager>().playerParty[3].mp;
        partyInformation.Instance.p4maxMP = GM.GetComponent<GameManager>().playerParty[3].maxMP;
        partyInformation.Instance.p4attack = GM.GetComponent<GameManager>().playerParty[3].attack;
        partyInformation.Instance.p4defense = GM.GetComponent<GameManager>().playerParty[3].defense;
        partyInformation.Instance.p4magic = GM.GetComponent<GameManager>().playerParty[3].magic;
        partyInformation.Instance.p4resistance = GM.GetComponent<GameManager>().playerParty[3].resistance;
        partyInformation.Instance.p4hpGrowth = GM.GetComponent<GameManager>().playerParty[3].hpGrowth;
        partyInformation.Instance.p4atkGrowth = GM.GetComponent<GameManager>().playerParty[3].atkGrowth;
        partyInformation.Instance.p4defGrowth = GM.GetComponent<GameManager>().playerParty[3].defGrowth;
        partyInformation.Instance.p4magGrowth = GM.GetComponent<GameManager>().playerParty[3].magGrowth;
        partyInformation.Instance.p4resGrowth = GM.GetComponent<GameManager>().playerParty[3].resGrowth;
        partyInformation.Instance.p4growthList = GM.GetComponent<GameManager>().playerParty[3].growthList;
        partyInformation.Instance.p4skillList = GM.GetComponent<GameManager>().playerParty[3].skillList;
        partyInformation.Instance.p4growthText = GM.GetComponent<GameManager>().playerParty[3].growthText;
        partyInformation.Instance.p4weak = GM.GetComponent<GameManager>().playerParty[3].weak;
        partyInformation.Instance.p4strong = GM.GetComponent<GameManager>().playerParty[3].strong;
        partyInformation.Instance.p4immune = GM.GetComponent<GameManager>().playerParty[3].immune;

        /*
        Debug.Log("Mandragora's: " + partyInformation.Instance.mandragora);

        partyInformation.Instance.potion = GM.GetComponent<Inventory>().potion;
        partyInformation.Instance.hiPotion = GM.GetComponent<Inventory>().hiPotion;
        partyInformation.Instance.ether = GM.GetComponent<Inventory>().ether;
        partyInformation.Instance.hiEther = GM.GetComponent<Inventory>().hiEther;
        partyInformation.Instance.fullPotion = GM.GetComponent<Inventory>().fullPotion;
        partyInformation.Instance.refresh = GM.GetComponent<Inventory>().refresh;
        partyInformation.Instance.revivalHerb = GM.GetComponent<Inventory>().revivalHerb;
        partyInformation.Instance.pavise = GM.GetComponent<Inventory>().pavise;
        partyInformation.Instance.wardingCharm = GM.GetComponent<Inventory>().wardingCharm;
        partyInformation.Instance.mandragora = GM.GetComponent<Inventory>().mandragora;
        partyInformation.Instance.bomb = GM.GetComponent<Inventory>().bomb;
        partyInformation.Instance.gasBomb =  GM.GetComponent<Inventory>().gasBomb;
        partyInformation.Instance.smokeBomb = GM.GetComponent<Inventory>().smokeBomb;

        Debug.Log("Mandragora's: " + GM.GetComponent<Inventory>().mandragora);
        */
        partyInformation.Instance.Gold = GM.GetComponent<GameManager>().Gold;
        partyInformation.Instance.Days = GM.GetComponent<GameManager>().Days;
    }
}
