using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Dragoon : Character
{
    // First Boss
    // Not too unique, but has a higher BST than most enemies
    // Raises Allies Attacks and Attacks with physical and fire attacks
    public Dragoon()
    {
        type = "Enemy";
        characterName = "Dragoon";
        sprite = Resources.Load<GameObject>("p_DRAGOON");

        hp = 50;
        maxHP = 50;
        mp = 25;
        maxMP = 25;
        attack = 15;
        defense = 8;
        magic = 8;
        resistance = 4;
    }

    // Dragoon AI
    // Basic Attack
    // Armor Smash
    // Rally Attack
    // Fire
    // Sneer
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
            int randomAction = Random.Range(0, 4);

            switch (randomAction)
            {
                case 0:
                    sk.attack_E(self, playerTarget);
                    break;
                case 1:
                    sk.armorSmash_E(self, playerTarget);
                    break;
                case 2:
                    sk.fire_E(self, playerTarget);
                    break;
                case 3:
                    sk.rallyATK_E(self);
                    break;
                case 4:
                    sk.sneer_E(self, playerTarget);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Dragoon AI Error");
                    break;
            }
        }
    }
}
