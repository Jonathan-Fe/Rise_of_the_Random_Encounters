using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Rogue : Character
{
    // Stronger Thief
    public Rogue()
    {
        type = "Enemy";
        characterName = "Rogue";
        sprite = Resources.Load<GameObject>("p_ROGUE");

        hp = 25;
        maxHP = 25;
        mp = 25;
        maxMP = 25;
        attack = 11;
        defense = 4;
        magic = 4;
        resistance = 3;
    }

    // Rogue AI
    // Basic Attack
    // Cripple
    // Poison Stab
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
                    sk.cripple_E(self, playerTarget);
                    break;
                case 2:
                    sk.poisonStab_E(self, playerTarget);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Rogue AI Error");
                    break;
            }
        }
    }
}
