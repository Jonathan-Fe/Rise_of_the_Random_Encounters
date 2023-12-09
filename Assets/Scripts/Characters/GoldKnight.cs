using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class GoldKnight : Character
{
    // Start is called before the first frame update
    public GoldKnight()
    {
        type = "Enemy";
        characterName = "Gold Knight";
        sprite = Resources.Load<GameObject>("p_GOLDKNIGHT");

        hp = 25;
        maxHP = 25;
        mp = 25;
        maxMP = 25;
        attack = 11;
        defense = 6;
        magic = 2;
        resistance = 3;
    }

    // Gold Knight's unique AI
    // Slightly More advanced, also has an option to support allies with defense buffs
    // Attack - Basic Attack
    // Rally Defense - Raise an Ally's Defense
    public override void enemyAI(Character self)
    {
        Debug.Log("Gold Knight AI running...");
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
                    sk.rallyDEF_E(self);
                    break;
                default:
                    Debug.Log("This shouldn't happen (Gold Knight AI Error");
                    break;
            }
        }
    }
}
