using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Fairy : Character
{
    // A Fairy that supports the 2nd Boss
    // Paper Thin defenses, but lots of support moves
    public Fairy()
    {
        type = "Enemy";
        characterName = "Fairy";
        sprite = Resources.Load<GameObject>("p_FAIRY");

        hp = 20;
        maxHP = 20;
        mp = 25;
        maxMP = 25;
        attack = 1;
        defense = 3;
        magic = 13;
        resistance = 4;
    }

    // Fairy AI
    // Basic Attack
    // Purge
    // Heal
    // Rally Attack
    // Rally Magic
    // Rally Defense
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
            int randomAction = Random.Range(0, 8);

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
                case 5:
                    sk.rallyATK_E(self);
                    break;
                case 6:
                    sk.rallyDEF_E(self);
                    break;
                case 7:
                    sk.rallyMAG_E(self);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Fairy AI Error");
                    break;
            }
        }
    }
}
