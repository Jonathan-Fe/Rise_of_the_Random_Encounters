using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    public GameObject shopScreen;
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

    public GameObject potionNum_p;
    public GameObject hiPotionNum_p;
    public GameObject etherNum_p;
    public GameObject hiEtherNum_p;
    public GameObject fullPotionNum_p;
    public GameObject refreshNum_p;
    public GameObject revivalHerbNum_p;
    public GameObject paviseNum_p;
    public GameObject wardingCharmNum_p;
    public GameObject mandragoraNum_p;
    public GameObject bombNum_p;
    public GameObject gasBombNum_p;
    public GameObject smokeBombNum_p;

    public GameObject inventoryButtonBase;
    public GameObject encounterButtonBase;
    public GameObject shopButton;

    public void openShop()
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

        potionNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.potionPrice.ToString();
        hiPotionNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.hiPotionPrice.ToString();
        etherNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.etherPrice.ToString();
        hiEtherNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.hiEtherPrice.ToString();
        fullPotionNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.fullPotionPrice.ToString();
        refreshNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.refreshPrice.ToString();
        revivalHerbNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.revivalHerbPrice.ToString();
        paviseNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.pavisePrice.ToString();
        wardingCharmNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.wardingCharmPrice.ToString();
        mandragoraNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.mandragoraPrice.ToString();
        bombNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.bombPrice.ToString();
        gasBombNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.gasBombPrice.ToString();
        smokeBombNum_p.GetComponentInChildren<TextMeshProUGUI>().text = partyInformation.Instance.smokeBombPrice.ToString();

        inventoryButtonBase.SetActive(false);
        encounterButtonBase.SetActive(false);
        shopButton.SetActive(false);
        shopScreen.SetActive(true);
        // gomenasai
    }

    public void closeShop()
    {
        shopScreen.SetActive(false);
        inventoryButtonBase.SetActive(true);
        encounterButtonBase.SetActive(true);
        shopButton.SetActive(true);
    }

    public void buyPotion()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.potionPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.potionPrice;
        partyInformation.Instance.potion++;
        potionNum_t.text = "x" + partyInformation.Instance.potion;
        Debug.Log("Bought a Potion!");
    }
    public void buyHiPotion()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.hiPotionPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.hiPotionPrice;
        partyInformation.Instance.hiPotion++;
        hiPotionNum_t.text = "x" + partyInformation.Instance.hiPotion;
        Debug.Log("Bought a Hi-Potion!");
    }

    public void buyEther()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.etherPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.etherPrice;
        partyInformation.Instance.hiEther++;
        etherNum_t.text = "x" + partyInformation.Instance.ether;
        Debug.Log("Bought a Ether!");
    }
    public void buyHiEther()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.hiEtherPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.hiEtherPrice;
        partyInformation.Instance.hiEther++;
        hiEtherNum_t.text = "x" + partyInformation.Instance.hiEther;
        Debug.Log("Bought a Hi-Ether!");
    }
    public void buyFullPotion()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.fullPotionPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.fullPotionPrice;
        partyInformation.Instance.fullPotion++;
        fullPotionNum_t.text = "x" + partyInformation.Instance.fullPotion;
        Debug.Log("Bought a Full Potion!");
    }

    public void buyRefresh()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.refreshPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.refreshPrice;
        partyInformation.Instance.refresh++;
        refreshNum_t.text = "x" + partyInformation.Instance.refresh;
        Debug.Log("Bought a Refresh!");
    }
    public void buyRevivalHerb()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.revivalHerbPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.revivalHerbPrice;
        partyInformation.Instance.revivalHerb++;
        revivalHerbNum_t.text = "x" + partyInformation.Instance.revivalHerb;
        Debug.Log("Bought a Revival herb!");
    }

    public void buyPavise()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.pavisePrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.pavisePrice;
        partyInformation.Instance.pavise++;
        paviseNum_t.text = "x" + partyInformation.Instance.pavise;
        Debug.Log("Bought a Pavise!");
    }

    public void buyWardingCharm()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.wardingCharmPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.wardingCharmPrice;
        partyInformation.Instance.wardingCharm++;
        wardingCharmNum_t.text = "x" + partyInformation.Instance.wardingCharm;
        Debug.Log("Bought a Warding Charm!");
    }

    public void buyMandragora()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.mandragoraPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.mandragoraPrice;
        partyInformation.Instance.mandragora++;
        mandragoraNum_t.text = "x" + partyInformation.Instance.mandragora;
        Debug.Log("Bought a Mandragora!");
    }

    public void buyBomb()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.bombPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.bombPrice;
        partyInformation.Instance.bomb++;
        bombNum_t.text = "x" + partyInformation.Instance.bomb;
        Debug.Log("Bought a Bomb!");
    }

    public void buyGasBomb()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.gasBombPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.gasBombPrice;
        partyInformation.Instance.gasBomb++;
        gasBombNum_t.text = "x" + partyInformation.Instance.gasBomb;
        Debug.Log("Bought a Gas Bomb!");
    }
    public void buySmokeBomb()
    {
        if (FindObjectOfType<GameManager>().Gold < partyInformation.Instance.smokeBombPrice)
        {
            Debug.Log("Not enough gold!");
            return;
        }

        FindObjectOfType<GameManager>().Gold -= partyInformation.Instance.smokeBombPrice;
        partyInformation.Instance.smokeBomb++;
        smokeBombNum_t.text = "x" + partyInformation.Instance.smokeBomb;
        Debug.Log("Bought a Smoke Bomb!");
    }

}
