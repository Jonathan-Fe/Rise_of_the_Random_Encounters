using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Mage : Character
{
    // Mages are relatively are frail, glass canon attacker units
    // Low physical stats and res, but good magic
    public Mage()
    {
        type = "Enemy";
        characterName = "Mage";
        sprite = Resources.Load<GameObject>("p_MAGE");

        hp = 17;
        maxHP = 17;
        mp = 25;
        maxMP = 25;
        attack = 5;
        defense = 2;
        magic = 10;
        resistance = 3;
    }

    // Mage AI
    // Basic Attack
    // Magic Missle
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
            int randomAction = Random.Range(0, 2);

            switch (randomAction)
            {
                case 0:
                    sk.attack_E(self, playerTarget);
                    break;
                case 1:
                    sk.magicMissle_E(self, playerTarget);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Mage AI Error");
                    break;
            }
        }
    }
}
