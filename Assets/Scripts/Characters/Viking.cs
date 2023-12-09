using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Viking : Character
{
    // Viking Stats
    // Stronger Fighter
    public Viking()
    {
        type = "Enemy";
        characterName = "Viking";
        sprite = Resources.Load<GameObject>("p_VIKING");

        hp = 30;
        maxHP = 30;
        mp = 25;
        maxMP = 25;
        attack = 15;
        defense = 5;
        magic = 1;
        resistance = 1;
    }

    // Basic Viking's AI
    // Basic Attack
    // Armor Smash -  Basic Attack + Lowers Defense
    public override void enemyAI(Character self)
    {
        Debug.Log("Fighter AI running...");
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
            if (playerTarget.KO == true)
            {
                Debug.Log("Rerolling Target...");
                enemyAI(self);
                return;
            }
            Debug.Log("Target: " + playerTarget.characterName);
            Debug.Log("Attacker: " + self.characterName);
            int randomAction = Random.Range(0, 2);

            switch (randomAction)
            {
                case 0:
                    sk.attack_E(self, playerTarget);
                    break;
                case 1:
                    sk.armorSmash_E(self, playerTarget);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Viking AI Error");
                    break;
            }
        }
    }
}
