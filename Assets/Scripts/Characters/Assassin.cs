using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassin : Character
{
    // Strongerst Thief
    // Assassin has fairly high attack and dangerous skills, making it a high threat
    public Assassin()
    {
        type = "Enemy";
        characterName = "Assassin";
        sprite = Resources.Load<GameObject>("p_ASSASSIN");

        hp = 30;
        maxHP = 30;
        mp = 25;
        maxMP = 25;
        attack = 15;
        defense = 4;
        magic = 4;
        resistance = 3;
    }

    // Assassin AI
    // Basic Attack
    // Cripple
    // Poison Stab
    // Mortal Wound
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
            int randomAction = Random.Range(0, 5);

            switch (randomAction)
            {
                case 0:
                    sk.attack_E(self, playerTarget);
                    break;
                case 1:
                    sk.cripple_E(self, playerTarget);
                    break;
                case 2:
                    sk.poisonStab_E(self, playerTarget);
                    break;
                case 3:
                    sk.mortalWound_E(self, playerTarget);
                    break;
                case 4:
                    sk.sneer_E(self, playerTarget);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Assassin AI Error");
                    break;
            }
        }
    }
}
