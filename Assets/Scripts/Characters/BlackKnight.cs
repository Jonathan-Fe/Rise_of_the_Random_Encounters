using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackKnight : Character
{
    // Strongest, end game variant of the Knight Enemy
    // High HP for the purpose of surprising the player with damage from Minus Strike
    public BlackKnight()
    {
        type = "Enemy";
        characterName = "Black Knight";
        sprite = Resources.Load<GameObject>("p_BLACKKNIGHT");

        hp = 35;
        maxHP = 35;
        mp = 25;
        maxMP = 25;
        attack = 14;
        defense = 9;
        magic = 5;
        resistance = 5;
    }

    // Black Knight's unique AI
    // Attack - Basic Attack
    // Rally Defense - Raise an Ally's Defense
    // Minus Strike - Deals damage based on the amount of HP Loss
    public override void enemyAI(Character self)
    {
        Debug.Log("Black Knight AI running...");
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
            if(playerTarget.KO == true)
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
                    sk.rallyDEF_E(self);
                    break;
                case 2:
                    sk.minusStrike_E(self, playerTarget);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Black Knight AI Error");
                    break;
            }
        }
    }
}
