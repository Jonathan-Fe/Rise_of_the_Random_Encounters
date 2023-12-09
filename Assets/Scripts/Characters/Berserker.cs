using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berserker : Character
{
    // Berserker Stats
    // Stronger Fighter
    public Berserker()
    {
        type = "Enemy";
        characterName = "Berserker";
        sprite = Resources.Load<GameObject>("p_BERSERKER");

        hp = 40;
        maxHP = 40;
        mp = 25;
        maxMP = 25;
        attack = 18;
        defense = 6;
        magic = 1;
        resistance = 2;
    }

    // Berserker AI
    // Basic Attack
    // Armor Smash
    // Cripple
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
                    sk.cripple_E(self, playerTarget);
                    break;
                case 3:
                    sk.rallyATK_E(self);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Berserker AI Error");
                    break;
            }
        }
    }
}
