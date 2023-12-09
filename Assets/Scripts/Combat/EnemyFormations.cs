using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using static Character;

public class EnemyFormations : MonoBehaviour
{
    GameManager GM;
    public List<List<Character>> formationList =  new List<List<Character>>();

    public List<string> formationDialogue = new List<string>();

    public List<int> goldTable = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();

        formationList.Add(new List<Character> { new Knight()}); // 0
        formationDialogue.Add("A lone knight ATTACKS!");
        goldTable.Add(250);
        // , new GoldKnight(), new BlackKnight()

        formationList.Add(new List<Character> { new Mage() }); // 1
        formationDialogue.Add("A lone mage ATTACKS!");
        goldTable.Add(250);

        formationList.Add(new List<Character> { new Fighter() }); // 2
        formationDialogue.Add("A lone fighter ATTACKS!");
        goldTable.Add(250);

        formationList.Add(new List<Character> { new Cleric() }); // 3
        formationDialogue.Add("A lone cleric ATTACKS!");
        goldTable.Add(250);

        formationList.Add(new List<Character> { new Thief() }); // 4
        formationDialogue.Add("A lone thief ATTACKS!");
        goldTable.Add(250);

        formationList.Add(new List<Character> { new GoldKnight(), new Nun() }); // 5
        formationDialogue.Add("A Knight n' Nun ATTACKS!");
        goldTable.Add(500);

        formationList.Add(new List<Character> { new Priestess(), new Druid() }); // 6
        formationDialogue.Add("A Magical Duo ATTACKS!");
        goldTable.Add(500);

        formationList.Add(new List<Character> { new Rogue(), new Thief(), new Thief() }); // 7
        formationDialogue.Add("An Underworld troupe ATTACKS!");
        goldTable.Add(500);

        formationList.Add(new List<Character> { new Viking(), new Fighter(), new Fighter() }); // 8
        formationDialogue.Add("A Brawler Pack ATTACKS!");
        goldTable.Add(500);

        formationList.Add(new List<Character> { new GoldKnight(), new Fighter(), new Nun() }); // 9
        formationDialogue.Add("A pack of adventurers ATTACKS!");
        goldTable.Add(500);

        formationList.Add(new List<Character> { new Dragoon(), new Knight(), new GoldKnight() }); // 10
        formationDialogue.Add("The Dragoon Platoon ATTACKS!");
        goldTable.Add(1000);

        formationList.Add(new List<Character> { new BlackKnight(), new GoldKnight(), new GoldKnight() }); // 11
        formationDialogue.Add("The Royal Guard ATTACKS!");
        goldTable.Add(750);

        formationList.Add(new List<Character> { new Priestess(), new Berserker(), new Rogue() }); // 12
        formationDialogue.Add("The Priestess and her retainers ATTACK!");
        goldTable.Add(750);

        formationList.Add(new List<Character> { new Priestess(), new Sage(), new Sage() }); // 13
        formationDialogue.Add("The Magical Trio ATTACKS!");
        goldTable.Add(750);

        formationList.Add(new List<Character> { new Berserker(), new Viking(), new Viking() }); // 14
        formationDialogue.Add("The Muscle Mob ATTACKS!");
        goldTable.Add(750);

        formationList.Add(new List<Character> { new Assassin(), new Rogue(), new BlackKnight() }); // 15
        formationDialogue.Add("The Assassin Clan ATTACKS!");
        goldTable.Add(750);

        formationList.Add(new List<Character> { new Hero(), new Fairy(), new Fairy() }); // 12
        formationDialogue.Add("The Hero of Light ATTACKS!");
        goldTable.Add(2000);
    }

    public void rollEncounter(int difficulty)
    {
        int randomValue = Random.Range(0, 5);
        //randomValue = 2;
        //difficulty = 4;
        //partyInformation.Instance.difficulty = 3;
        Debug.Log("Random Value = " + randomValue);
        switch (difficulty)
        {
            case 1:
                switch (randomValue)
                {
                    case 0:
                        Debug.Log("Enemy Formation 1-1");
                        GM.enemyParty = formationList[0];
                        GM.enemyDialogue = formationDialogue[0];
                        GM.goldReward = goldTable[0];
                        partyInformation.Instance.enemyParty = formationList[0];
                        partyInformation.Instance.enemyDialogue = formationDialogue[0];
                        partyInformation.Instance.goldReward = goldTable[0];
                        partyInformation.Instance.enemyPartyIndex = 0;
                        break;
                    case 1:
                        Debug.Log("Enemy Formation 1-2");
                        GM.enemyParty = formationList[1];
                        GM.enemyDialogue = formationDialogue[1];
                        GM.goldReward = goldTable[1];
                        partyInformation.Instance.enemyParty = formationList[1];
                        partyInformation.Instance.enemyDialogue = formationDialogue[1];
                        partyInformation.Instance.goldReward = goldTable[1];
                        Debug.Log("Party Information - First Enemy is: " + partyInformation.Instance.enemyParty[0].characterName);
                        partyInformation.Instance.enemyPartyIndex = 1;
                        break;
                    case 2:
                        Debug.Log("Enemy Formation 1-3");
                        GM.enemyParty = formationList[2];
                        GM.enemyDialogue = formationDialogue[2];
                        GM.goldReward = goldTable[2];
                        partyInformation.Instance.enemyParty = formationList[2];
                        partyInformation.Instance.enemyDialogue = formationDialogue[2];
                        partyInformation.Instance.goldReward = goldTable[2];
                        Debug.Log("Party Information - First Enemy is: " + partyInformation.Instance.enemyParty[0].characterName);
                        partyInformation.Instance.enemyPartyIndex = 2;
                        break;
                    case 3:
                        Debug.Log("Enemy Formation 1-4");
                        GM.enemyParty = formationList[3];
                        GM.enemyDialogue = formationDialogue[3];
                        GM.goldReward = goldTable[3];
                        partyInformation.Instance.enemyParty = formationList[3];
                        partyInformation.Instance.enemyDialogue = formationDialogue[3];
                        partyInformation.Instance.goldReward = goldTable[3];
                        partyInformation.Instance.enemyPartyIndex = 3;
                        break;
                    case 4:
                        Debug.Log("Enemy Formation 1-5");
                        GM.enemyParty = formationList[4];
                        GM.enemyDialogue = formationDialogue[4];
                        GM.goldReward = goldTable[4];
                        partyInformation.Instance.enemyParty = formationList[4];
                        partyInformation.Instance.enemyDialogue = formationDialogue[4];
                        partyInformation.Instance.goldReward = goldTable[4];
                        partyInformation.Instance.enemyPartyIndex = 4;
                        break;
                    default:
                        Debug.Log("This shouldn't happen, Encounter Roll Error - Selecting Encounter - Difficulty 1");
                        break;
                }
                break;
            case 2:
                switch (randomValue)
                {
                    case 0:
                        Debug.Log("Enemy Formation 2-1");
                        GM.enemyParty = formationList[5];
                        GM.enemyDialogue = formationDialogue[5];
                        GM.goldReward = goldTable[5];
                        partyInformation.Instance.enemyParty = formationList[5];
                        partyInformation.Instance.enemyDialogue = formationDialogue[5];
                        partyInformation.Instance.goldReward = goldTable[5];
                        partyInformation.Instance.enemyPartyIndex = 5;
                        break;
                    case 1:
                        Debug.Log("Enemy Formation 2-2");
                        GM.enemyParty = formationList[6];
                        GM.enemyDialogue = formationDialogue[6];
                        GM.goldReward = goldTable[6];
                        partyInformation.Instance.enemyParty = formationList[6];
                        partyInformation.Instance.enemyDialogue = formationDialogue[6];
                        partyInformation.Instance.goldReward = goldTable[6];
                        partyInformation.Instance.enemyPartyIndex = 6;
                        break;
                    case 2:
                        Debug.Log("Enemy Formation 2-3");
                        GM.enemyParty = formationList[7];
                        GM.enemyDialogue = formationDialogue[7];
                        GM.goldReward = goldTable[7];
                        partyInformation.Instance.enemyParty = formationList[7];
                        partyInformation.Instance.enemyDialogue = formationDialogue[7];
                        partyInformation.Instance.goldReward = goldTable[7];
                        partyInformation.Instance.enemyPartyIndex = 7;
                        break;
                    case 3:
                        Debug.Log("Enemy Formation 2-4");
                        GM.enemyParty = formationList[8];
                        GM.enemyDialogue = formationDialogue[8];
                        GM.goldReward = goldTable[8];
                        partyInformation.Instance.enemyParty = formationList[8];
                        partyInformation.Instance.enemyDialogue = formationDialogue[8];
                        partyInformation.Instance.goldReward = goldTable[8];
                        partyInformation.Instance.enemyPartyIndex = 8;
                        break;
                    case 4:
                        Debug.Log("Enemy Formation 2-5");
                        GM.enemyParty = formationList[9];
                        GM.enemyDialogue = formationDialogue[9];
                        GM.goldReward = goldTable[9];
                        partyInformation.Instance.enemyParty = formationList[9];
                        partyInformation.Instance.enemyDialogue = formationDialogue[9];
                        partyInformation.Instance.goldReward = goldTable[9];
                        partyInformation.Instance.enemyPartyIndex = 9;
                        break;
                    default:
                        Debug.Log("This shouldn't happen, Encounter Roll Error - Selecting Encounter - Difficulty 2");
                        break;
                }
                break;
            case 3:
                Debug.Log("Enemy Formation 3-1");
                GM.enemyParty = formationList[10];
                GM.enemyDialogue = formationDialogue[10];
                GM.goldReward = goldTable[10];
                partyInformation.Instance.enemyParty = formationList[10];
                partyInformation.Instance.enemyDialogue = formationDialogue[10];
                partyInformation.Instance.goldReward = goldTable[10];
                GM.boss1 = true;
                partyInformation.Instance.boss1 = true;
                partyInformation.Instance.enemyPartyIndex = 10;
                break;
            case 4:
                switch (randomValue)
                {
                    case 0:
                        Debug.Log("Enemy Formation 4-1");
                        GM.enemyParty = formationList[11];
                        GM.enemyDialogue = formationDialogue[11];
                        GM.goldReward = goldTable[11];
                        partyInformation.Instance.enemyParty = formationList[11];
                        partyInformation.Instance.enemyDialogue = formationDialogue[11];
                        partyInformation.Instance.goldReward = goldTable[11];
                        partyInformation.Instance.enemyPartyIndex = 11;
                        break;
                    case 1:
                        Debug.Log("Enemy Formation 4-2");
                        GM.enemyParty = formationList[12];
                        GM.enemyDialogue = formationDialogue[12];
                        GM.goldReward = goldTable[12];
                        partyInformation.Instance.enemyParty = formationList[12];
                        partyInformation.Instance.enemyDialogue = formationDialogue[12];
                        partyInformation.Instance.goldReward = goldTable[12];
                        partyInformation.Instance.enemyPartyIndex = 12;
                        break;
                    case 2:
                        Debug.Log("Enemy Formation 4-3");
                        GM.enemyParty = formationList[13];
                        GM.enemyDialogue = formationDialogue[13];
                        GM.goldReward = goldTable[13];
                        partyInformation.Instance.enemyParty = formationList[13];
                        partyInformation.Instance.enemyDialogue = formationDialogue[13];
                        partyInformation.Instance.goldReward = goldTable[13];
                        partyInformation.Instance.enemyPartyIndex = 13;
                        break;
                    case 3:
                        Debug.Log("Enemy Formation 4-4");
                        GM.enemyParty = formationList[14];
                        GM.enemyDialogue = formationDialogue[14];
                        GM.goldReward = goldTable[14];
                        partyInformation.Instance.enemyParty = formationList[14];
                        partyInformation.Instance.enemyDialogue = formationDialogue[14];
                        partyInformation.Instance.goldReward = goldTable[14];
                        partyInformation.Instance.enemyPartyIndex = 14;
                        break;
                    case 4:
                        Debug.Log("Enemy Formation 4-5");
                        GM.enemyParty = formationList[15];
                        GM.enemyDialogue = formationDialogue[15];
                        GM.goldReward = goldTable[15];
                        partyInformation.Instance.enemyParty = formationList[15];
                        partyInformation.Instance.enemyDialogue = formationDialogue[15];
                        partyInformation.Instance.goldReward = goldTable[15];
                        partyInformation.Instance.enemyPartyIndex = 15;
                        break;
                    default:
                        Debug.Log("This shouldn't happen, Encounter Roll Error - Selecting Encounter - Difficulty 4");
                        break;
                }
                break;
            case 5:
                Debug.Log("Enemy Formation 5-1");
                GM.enemyParty = formationList[16];
                GM.enemyDialogue = formationDialogue[16];
                GM.goldReward = goldTable[16];
                partyInformation.Instance.enemyParty = formationList[16];
                partyInformation.Instance.enemyDialogue = formationDialogue[16];
                partyInformation.Instance.goldReward = goldTable[16];
                GM.boss2 = true;
                partyInformation.Instance.boss2 = true;
                partyInformation.Instance.enemyPartyIndex = 16;
                break;
            default:
                Debug.Log("This shouldn't happen, Enounter Roll Error - Selecting Difficulty of Encounter");
                break;
        }
    }



}
