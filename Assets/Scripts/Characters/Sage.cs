using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sage : Character
{
    // Stronger Variant of Mage
    public Sage()
    {
        type = "Enemy";
        characterName = "Sage";
        sprite = Resources.Load<GameObject>("p_SAGE");

        hp = 28;
        maxHP = 28;
        mp = 25;
        maxMP = 25;
        attack = 7;
        defense = 5;
        magic = 18;
        resistance = 8;
    }

    // Sage AI
    // Basic Attack
    // Magic Missle
    // Fire
    // Thunder
    // Rally Magic
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
                    sk.magicMissle_E(self, playerTarget);
                    break;
                case 2:
                    sk.fire_E(self, playerTarget);
                    break;
                case 3:
                    sk.thunder_E(self, playerTarget);
                    break;
                case 4:
                    sk.rallyMAG_E(self);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Sage AI Error");
                    break;
            }
        }
    }
}
