using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Druid : Character
{
    // Stronger Variant of Mage
    public Druid()
    {
        type = "Enemy";
        characterName = "Druid";
        sprite = Resources.Load<GameObject>("p_DRUID");

        hp = 22;
        maxHP = 22;
        mp = 25;
        maxMP = 25;
        attack = 6;
        defense = 4;
        magic = 14;
        resistance = 6;
    }

    // Druid AI
    // Basic Attack
    // Magic Missle
    // Fire
    // Thunder
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
                    sk.magicMissle_E(self, playerTarget);
                    break;
                case 2:
                    sk.fire_E(self, playerTarget);
                    break;
                case 3:
                    sk.thunder_E(self, playerTarget);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Druid AI Error");
                    break;
            }
        }
    }
}
