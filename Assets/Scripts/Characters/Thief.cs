using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Character
{
    // Thieves are relatively weak, frail classes that annoy with status effects
    public Thief()
    {
        type = "Enemy";
        characterName = "Thief";
        sprite = Resources.Load<GameObject>("p_THIEF");

        hp = 19;
        maxHP = 19;
        mp = 25;
        maxMP = 25;
        attack = 7;
        defense = 2;
        magic = 2;
        resistance = 2;
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
                    sk.cripple_E(self, playerTarget);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Thief AI Error");
                    break;
            }
        }
    }
}
