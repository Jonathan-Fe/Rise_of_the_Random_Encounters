using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Fighter : Character
{
    // Fighter Stats
    // Slightly Higher HP and attack than Knight
    // Lower Defenses and Magic
    public Fighter()
    {
        type = "Enemy";
        characterName = "Fighter";
        sprite = Resources.Load<GameObject>("p_FIGHTER");

        hp = 23;
        maxHP = 22;
        mp = 25;
        maxMP = 25;
        attack = 11;
        defense = 2;
        magic = 0;
        resistance = 0;
        //Debug.Log("Fighter Created!");
    }

    // Basic Fighter's AI
    // Basically a carbon copy of the Knight AI
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
            sk.attack_E(self, playerTarget);
        }
    }
}
