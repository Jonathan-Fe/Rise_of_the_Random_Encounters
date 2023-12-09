using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int potion = 0;
    public int hiPotion = 0;
    public int ether = 0;
    public int hiEther = 0;
    public int fullPotion = 0;
    public int refresh = 0;
    public int revivalHerb = 0;
    public int pavise = 0;
    public int wardingCharm = 0;
    public int mandragora = 0;
    public int bomb = 0;
    public int gasBomb = 0;
    public int smokeBomb = 0;

    public GameObject inventoryScreen;
    //public TextMeshProUGUI potion_t;
    public TextMeshProUGUI potionNum_t;
    //public TextMeshProUGUI hiPotion_t;
    public TextMeshProUGUI hiPotionNum_t;
    //public TextMeshProUGUI ether_t;
    public TextMeshProUGUI etherNum_t;
    //public TextMeshProUGUI hiEther_t;
    public TextMeshProUGUI hiEtherNum_t;
    //public TextMeshProUGUI fullPotion_t;
    public TextMeshProUGUI fullPotionNum_t;
    //public TextMeshProUGUI refresh_t;
    public TextMeshProUGUI refreshNum_t;
    //public TextMeshProUGUI revivalHerb_t;
    public TextMeshProUGUI revivalHerbNum_t;
    //public TextMeshProUGUI pavise_t;
    public TextMeshProUGUI paviseNum_t;
    //public TextMeshProUGUI wardingCharm_t;
    public TextMeshProUGUI wardingCharmNum_t;
    public TextMeshProUGUI mandragoraNum_t;
    //public TextMeshProUGUI bomb_t;
    public TextMeshProUGUI bombNum_t;
    //public TextMeshProUGUI gasBomb_t;
    public TextMeshProUGUI gasBombNum_t;
    //public TextMeshProUGUI smokeBomb_t;
    public TextMeshProUGUI smokeBombNum_t;

    public GameObject inventoryButtonBase;
    public GameObject encounterButtonBase;
    public GameObject shopButton;

    // Start is called before the first frame update
    void Start()
    {
        /*
        potion = 5;
        hiPotion = 1;
        ether = 5;
        hiEther = 1;
        fullPotion = 1;
        refresh = 1;
        revivalHerb = 1;
        pavise = 1;
        wardingCharm = 1;
        mandragora = 1;
        bomb = 1;
        gasBomb = 1;
        smokeBomb = 1;
        */
        
        /*
        potion = partyInformation.Instance.potion;
        hiPotion = partyInformation.Instance.hiPotion;
        ether = partyInformation.Instance.ether;
        hiEther = partyInformation.Instance.hiEther;
        fullPotion = partyInformation.Instance.fullPotion;
        refresh = partyInformation.Instance.refresh;
        revivalHerb = partyInformation.Instance.revivalHerb;
        pavise = partyInformation.Instance.pavise;
        wardingCharm = partyInformation.Instance.wardingCharm;
        mandragora = partyInformation.Instance.mandragora;
        bomb = partyInformation.Instance.bomb;
        gasBomb = partyInformation.Instance.gasBomb;
        smokeBomb = partyInformation.Instance.smokeBomb;

        Debug.Log("Number of Mandragora's: " + mandragora);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openInventory()
    {
        //potion_t.text = "Potion";
        potionNum_t.text = "x" + partyInformation.Instance.potion;//potion;
        //hiPotion_t.text = "High Potion";
        hiPotionNum_t.text = "x" + partyInformation.Instance.hiPotion;
        //ether_t.text = "Ether";
        etherNum_t.text = "x" + partyInformation.Instance.ether;
        hiEtherNum_t.text = "x" + partyInformation.Instance.hiEther;
        fullPotionNum_t.text = "x" + partyInformation.Instance.fullPotion;
        refreshNum_t.text = "x" + partyInformation.Instance.refresh;
        revivalHerbNum_t.text = "x" + partyInformation.Instance.revivalHerb;
        paviseNum_t.text = "x" + partyInformation.Instance.pavise;
        wardingCharmNum_t.text = "x" + partyInformation.Instance.wardingCharm;
        mandragoraNum_t.text = "x" + partyInformation.Instance.mandragora;//mandragora;
        bombNum_t.text = "x" + partyInformation.Instance.bomb;
        gasBombNum_t.text = "x" + partyInformation.Instance.gasBomb;
        smokeBombNum_t.text = "x" + partyInformation.Instance.smokeBomb;
        //highEther_t.text = "High Ether x" + highEther;
        //fullPotion_t.text = "Full Potion x" + fullPotion;
        //refresh_t.text = "Refresh x" + refresh;
        //revivalHerb_t.text = "Revival Herb x" + revivalHerb;
        //pavise_t.text = "Pavise x" + pavise;
        //wardingCharm_t.text = "Warding Charm x" + wardingCharm;
        //bomb_t.text = "Bomb x" + bomb;
        //gasBomb_t.text = "Gas Bomb x" + gasBomb;
        //smokeBomb_t.text = "Smoke Bomb x" + smokeBomb;

        inventoryScreen.SetActive(true);
    }

    public void openInventoryBase()
    {
        //potion_t.text = "Potion";
        potionNum_t.text = "x" + partyInformation.Instance.potion;
        //hiPotion_t.text = "High Potion";
        hiPotionNum_t.text = "x" + partyInformation.Instance.hiPotion;
        //ether_t.text = "Ether";
        etherNum_t.text = "x" + partyInformation.Instance.ether;
        hiEtherNum_t.text = "x" + partyInformation.Instance.hiEther;
        fullPotionNum_t.text = "x" + partyInformation.Instance.fullPotion;
        refreshNum_t.text = "x" + partyInformation.Instance.refresh;
        revivalHerbNum_t.text = "x" + partyInformation.Instance.revivalHerb;
        paviseNum_t.text = "x" + partyInformation.Instance.pavise;
        wardingCharmNum_t.text = "x" + partyInformation.Instance.wardingCharm;
        mandragoraNum_t.text = "x" + partyInformation.Instance.mandragora;
        bombNum_t.text = "x" + partyInformation.Instance.bomb;
        gasBombNum_t.text = "x" + partyInformation.Instance.gasBomb;
        smokeBombNum_t.text = "x" + partyInformation.Instance.smokeBomb;

        inventoryButtonBase.SetActive(false);
        encounterButtonBase.SetActive(false);
        shopButton.SetActive(false);

        inventoryScreen.SetActive(true);
    }

    public void closeInventory()
    {
        inventoryScreen.SetActive(false);
    }

    public void closeInventoryBase()
    {
        inventoryScreen.SetActive(false);
        inventoryButtonBase.SetActive(true);
        encounterButtonBase.SetActive(true);
        shopButton.SetActive(true);
    }
}
