using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Priestess : Character
{
    // Strongest variant of Cleric
    public Priestess()
    {
        type = "Enemy";
        characterName = "Priestess";
        sprite = Resources.Load<GameObject>("p_PRIESTESS");

        hp = 28;
        maxHP = 28;
        mp = 25;
        maxMP = 25;
        attack = 9;
        defense = 8;
        magic = 10;
        resistance = 11;
    }

    // Priestess AI
    // Basic Attack
    // Purge
    // Heal
    // Rally Res
    // Heal Status
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
                    sk.purge_E(self, playerTarget);
                    break;
                case 2:
                    sk.heal_E(self);
                    break;
                case 3:
                    sk.rallyRES_E(self);
                    break;
                case 4:
                    sk.healStatus_E(self);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Priestess AI Error");
                    break;
            }
        }
    }
}
