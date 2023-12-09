using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Character
{
    // Start is called before the first frame update
    public Knight()
    {
        type = "Enemy";
        characterName = "Knight";
        sprite = Resources.Load<GameObject>("p_KNIGHT");

        hp = 18;
        maxHP = 18;
        mp = 25;
        maxMP = 25;
        attack = 8;
        defense = 4;
        magic = 1;
        resistance = 2;
        //Debug.Log("Knight Created!");
    }

    // Knight's unique AI
    // As the most basic enemy, it's basically just the same as the default Character AI
    public override void enemyAI(Character self)
    {
        Debug.Log("Knight AI running...");
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
