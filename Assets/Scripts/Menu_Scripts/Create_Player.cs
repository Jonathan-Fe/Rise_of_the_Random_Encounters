using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Character;

public class Create_Player : MonoBehaviour
{
    public bool nameEntered = false;
    public bool cancel = false;
    public GameObject textEntry;
    public TMP_InputField textInput;
    public string playerName = "test";
    GameManager GM;
    partyInformation PI;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();//GameManager.Instance;
        PI = GameObject.Find("partyInfo").GetComponent<partyInformation>();
    }

    public void openTextEntry()
    {
        cancel = false;
        nameEntered = false;
        textEntry.SetActive(true);
    }

    public void closeTextEntry()
    {
        textEntry.SetActive(false);
    }

    public void cancelButton()
    {
        cancel = true;
        nameEntered = true;
        closeTextEntry();
        StopAllCoroutines();
    }

    public void submitName()
    {
        Debug.Log("Text Input: " + textInput.text);
        playerName = textInput.text;
        Debug.Log("Player 1's name is: " + playerName);
        closeTextEntry();
        nameEntered = true;
    }
    public void slimeButton()
    {
        openTextEntry();
        StartCoroutine(playerSlime());
    }

    public void orcButton()
    {
        openTextEntry();
        StartCoroutine(playerOrc());
    }

    public void phantomButton()
    {
        openTextEntry();
        StartCoroutine(playerPhantom());
    }

    public void mushButton()
    {
        openTextEntry();
        StartCoroutine(playerMushfella());
    }
    public void goldSlimeButton()
    {
        openTextEntry();
        StartCoroutine(playerGoldSlime());
    }
    public IEnumerator playerSlime()
    {
        Debug.Log("Waiting for Player 1's name input");
        while (!nameEntered)
        {
            yield return null;
        }

        if (cancel)
        {
            Debug.Log("Cancelling Name Entry...");
            yield return null;
        }
        else
        {
            GM.playerParty[0] = (new Slime(playerName));
            GM.playerParty[1] = (new Orc(generateOrcName()));
            GM.playerParty[2] = (new Phantom(generatePhantomName()));
            GM.playerParty[3] = (new Mushfella(generateMushName()));
            //GM.playerParty.Add(new Slime(playerName));
            //GM.p1 = new Slime(playerName);
            //GameManager.Instance.playerParty[0] = GM.GetComponent<Slime>().createSlime(playerName); ;//(new Slime(playerName));
            //GM.playerParty[1] = (new Character());
            //GM.playerParty[2] = (new Character());
            //GM.playerParty[3] = (new Character());
            GM.Gold = 5000;
            //Debug.Log(GameManager.Instance.playerParty[0].characterName);
            Debug.Log(GM.playerParty[0].characterName);
            //Debug.Log(GM.playerParty[0].type);
            //Debug.Log(GM.playerParty[0].maxHP);
            //Debug.Log(GameManager.Instance.Gold);
            Debug.Log(GM.Gold);
            //GM.GM = GM;
            GM.p1Name = GM.playerParty[0].characterName;
            Debug.Log(GM.p1Name);
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

            GM.loadBase();
        }
    }

    public IEnumerator playerOrc()
    {
        Debug.Log("Waiting for Player 1's name input");
        while (!nameEntered)
        {
            yield return null;
        }

        if (cancel)
        {
            Debug.Log("Cancelling Name Entry...");
            yield return null;
        }
        else
        {
            GM.playerParty[0] = (new Orc(playerName));
            GM.playerParty[1] = (new Slime(generateSlimeName()));
            GM.playerParty[2] = (new Phantom(generatePhantomName()));
            GM.playerParty[3] = (new Mushfella(generateMushName()));
            Debug.Log(GM.playerParty[0].characterName);
            Debug.Log(GM.playerParty[0].type);
            Debug.Log(GM.playerParty[0].maxHP);
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

            GM.loadBase();
        }
    }

    public IEnumerator playerPhantom()
    {
        Debug.Log("Waiting for Player 1's name input");
        while (!nameEntered)
        {
            yield return null;
        }

        if (cancel)
        {
            Debug.Log("Cancelling Name Entry...");
            yield return null;
        }
        else
        {
            GM.playerParty[0] = (new Phantom(playerName));
            GM.playerParty[1] = (new Slime(generateSlimeName()));
            GM.playerParty[2] = (new Orc(generateOrcName()));
            GM.playerParty[3] = (new Mushfella(generateMushName()));
            Debug.Log(GM.playerParty[0].characterName);
            Debug.Log(GM.playerParty[0].type);
            Debug.Log(GM.playerParty[0].maxHP);
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

            GM.loadBase();
        }
    }

    public IEnumerator playerMushfella()
    {
        Debug.Log("Waiting for Player 1's name input");
        while (!nameEntered)
        {
            yield return null;
        }

        if (cancel)
        {
            Debug.Log("Cancelling Name Entry...");
            yield return null;
        }
        else
        {
            GM.playerParty[0] = (new Mushfella(playerName));
            GM.playerParty[1] = (new Slime(generateSlimeName()));
            GM.playerParty[2] = (new Orc(generateOrcName()));
            GM.playerParty[3] = (new Phantom(generatePhantomName()));
            Debug.Log(GM.playerParty[0].characterName);
            Debug.Log(GM.playerParty[0].type);
            Debug.Log(GM.playerParty[0].maxHP);
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

            GM.loadBase();
        }
    }

    public IEnumerator playerGoldSlime()
    {
        Debug.Log("Waiting for Player 1's name input");
        while (!nameEntered)
        {
            yield return null;
        }

        if (cancel)
        {
            Debug.Log("Cancelling Name Entry...");
            yield return null;
        }
        else
        {
            GM.playerParty[0] = (new GoldSlime(playerName));
            GM.playerParty[1] = (new Orc(generateOrcName()));
            GM.playerParty[2] = (new Phantom(generatePhantomName()));
            GM.playerParty[3] = (new Mushfella(generateMushName()));
            Debug.Log(GM.playerParty[0].characterName);
            Debug.Log(GM.playerParty[0].type);
            Debug.Log(GM.playerParty[0].maxHP);
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

            GM.loadBase();
        }
    }

    public string generateSlimeName()
    {
        int randomName = Random.Range(0, 11);
        string name = "default";

        switch (randomName)
        {
            case 0:
                //Debug.Log("Name - Gooey");
                name = "Gooey";
                break;
            case 1:
                //Debug.Log("Name - Gooey");
                name = "Goomy";
                break;
            case 2:
                //Debug.Log("Name - Gooey");
                name = "Sligoo";
                break;
            case 3:
                //Debug.Log("Name - Gooey");
                name = "Blooper";
                break;
            case 4:
                //Debug.Log("Name - Gooey");
                name = "Suu";
                break;
            case 5:
                //Debug.Log("Name - Gooey");
                name = "Chuchu";
                break;
            case 6:
                //Debug.Log("Name - Gooey");
                name = "Slick";
                break;
            case 7:
                //Debug.Log("Name - Gooey");
                name = "Gormy";
                break;
            case 8:
                //Debug.Log("Name - Gooey");
                name = "Doughy";
                break;
            case 9:
                //Debug.Log("Name - Gooey");
                name = "Goodra";
                break;
            case 10:
                //Debug.Log("Name - Gooey");
                name = "Solution";
                break;
            default:
                name = "Slimey";
                break;
        }

        return name;
    }

    public string generateOrcName()
    {
        int randomName = Random.Range(0, 11);
        string name = "default";

        switch (randomName)
        {
            case 0:
                //Debug.Log("Name - Gooey");
                name = "Gorloc";
                break;
            case 1:
                //Debug.Log("Name - Gooey");
                name = "Gonzalez";
                break;
            case 2:
                //Debug.Log("Name - Gooey");
                name = "Ganon";
                break;
            case 3:
                //Debug.Log("Name - Gooey");
                name = "Dorf";
                break;
            case 4:
                //Debug.Log("Name - Gooey");
                name = "Koridai";
                break;
            case 5:
                //Debug.Log("Name - Gooey");
                name = "Oku";
                break;
            case 6:
                //Debug.Log("Name - Gooey");
                name = "Oga";
                break;
            case 7:
                //Debug.Log("Name - Gooey");
                name = "Porkchop";
                break;
            case 8:
                //Debug.Log("Name - Gooey");
                name = "DeGroot";
                break;
            case 9:
                //Debug.Log("Name - Gooey");
                name = "Porco";
                break;
            case 10:
                //Debug.Log("Name - Gooey");
                name = "Rosso";
                break;
            default:
                name = "Orcy";
                break;
        }

        return name;
    }

    public string generatePhantomName()
    {
        int randomName = Random.Range(0, 11);
        string name = "default";

        switch (randomName)
        {
            case 0:
                //Debug.Log("Name - Gooey");
                name = "Yurei";
                break;
            case 1:
                //Debug.Log("Name - Gooey");
                name = "Honeda";
                break;
            case 2:
                //Debug.Log("Name - Gooey");
                name = "Perona";
                break;
            case 3:
                //Debug.Log("Name - Gooey");
                name = "Gaster";
                break;
            case 4:
                //Debug.Log("Name - Gooey");
                name = "Casper";
                break;
            case 5:
                //Debug.Log("Name - Gooey");
                name = "Whispy";
                break;
            case 6:
                //Debug.Log("Name - Gooey");
                name = "Youmu";
                break;
            case 7:
                //Debug.Log("Name - Gooey");
                name = "Zero";
                break;
            case 8:
                //Debug.Log("Name - Gooey");
                name = "Shiki";
                break;
            case 9:
                //Debug.Log("Name - Gooey");
                name = "Poe";
                break;
            case 10:
                //Debug.Log("Name - Gooey");
                name = "Yuyuko";
                break;
            default:
                name = "Spooky";
                break;
        }

        return name;
    }

    public string generateMushName()
    {
        int randomName = Random.Range(0, 11);
        string name = "default";

        switch (randomName)
        {
            case 0:
                //Debug.Log("Name - Gooey");
                name = "Mallow";
                break;
            case 1:
                //Debug.Log("Name - Gooey");
                name = "Marshall";
                break;
            case 2:
                //Debug.Log("Name - Gooey");
                name = "Mycel";
                break;
            case 3:
                //Debug.Log("Name - Gooey");
                name = "Kinoko";
                break;
            case 4:
                //Debug.Log("Name - Gooey");
                name = "Nasu";
                break;
            case 5:
                //Debug.Log("Name - Gooey");
                name = "Mosshead";
                break;
            case 6:
                //Debug.Log("Name - Gooey");
                name = "Molder";
                break;
            case 7:
                //Debug.Log("Name - Gooey");
                name = "Bonnette";
                break;
            case 8:
                //Debug.Log("Name - Gooey");
                name = "Sporeticus";
                break;
            case 9:
                //Debug.Log("Name - Gooey");
                name = "Foongus";
                break;
            case 10:
                //Debug.Log("Name - Gooey");
                name = "Amoongus";
                break;
            default:
                name = "Capp'n";
                break;
        }

        return name;
    }

}
