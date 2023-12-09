using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Cleric : Character
{
    // Clerics are relatively frail support units
    // Low physical stats, high magical ones
    // Despite this they don't use offense magic much
    public Cleric()
    {
        type = "Enemy";
        characterName = "Cleric";
        sprite = Resources.Load<GameObject>("p_CLERIC");

        hp = 15;
        maxHP = 15;
        mp = 25;
        maxMP = 25;
        attack = 5;
        defense = 2;
        magic = 7;
        resistance = 6;
    }

    // Cleric AI
    // Basic Attack
    // Magic Missle
    // Heal
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
            int randomAction = Random.Range(0, 3);

            switch (randomAction)
            {
                case 0:
                    sk.attack_E(self, playerTarget);
                    break;
                case 1:
                    sk.magicMissle_E(self, playerTarget);
                    break;
                case 2:
                    sk.heal_E(self);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Cleric AI Error");
                    break;
            }
        }
    }
}
