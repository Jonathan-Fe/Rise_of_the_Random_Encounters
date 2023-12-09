using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    // Second Boss
    // Generic RPG Hero with high all-around stats and plenty of strong skills
    public Hero()
    {
        type = "Enemy";
        characterName = "Hero";
        sprite = Resources.Load<GameObject>("p_HERO");

        hp = 80;
        maxHP = 80;
        mp = 25;
        maxMP = 25;
        attack = 20;
        defense = 10;
        magic = 14;
        resistance = 7;
    }

    // Hero AI
    // Basic Attack
    // Armor Smash
    // Sword Beam
    // Fire
    // Thunder
    // Rally Attack
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
            int randomAction = Random.Range(0, 6);

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
                    sk.swordBeam_E(self, playerTarget);
                    break;
                case 5:
                    sk.thunder_E(self, playerTarget);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Hero AI Error");
                    break;
            }
        }
    }
}
