using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static Character;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class SkillDictionary : MonoBehaviour
{
    Dictionary<int, System.Action> skills = new Dictionary<int, System.Action>();

    public BattleSystem bs;

    public GameObject en_button_1;
    public GameObject en_button_2;
    public GameObject en_button_3;

    public GameObject p_button_1;
    public GameObject p_button_2;
    public GameObject p_button_3;
    public GameObject p_button_4;

    Character user;
    Character target;
    string targetButton = "nothing";
    string test = "test";
    bool targetChosen = false;

    int targetValue;

    
    void Start()
    {
        bs = FindObjectOfType<BattleSystem>();
    }
    

    public void getButtonName()
    {
        targetButton =  EventSystem.current.currentSelectedGameObject.name;
        //Debug.Log("FIRST TARGET BUTTON RETURN " + targetButton.ToString());
        targetButtons();
    }
  
    public bool targetButtons()
    {
        //targetButton = "nothing";
        targetValue = -1;
        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        //targetButton = EventSystem.current.currentSelectedGameObject.name;

        /*
        if (targetButton != "Enemy_Button_1" || targetButton != "Enemy_Button_2" || targetButton != "Enemy_Button_3")
        {
            return false;
        }
        */
        Debug.Log(targetButton);

        switch (targetButton)
        {
            case "Enemy_Button_1":
                targetValue = 0;
                Debug.Log("Targeting Enemy 1");
                en_button_1.SetActive(false);
                en_button_2.SetActive(false);
                en_button_3.SetActive(false);
                targetChosen = true;
                return true;
               // break;

            case "Enemy_Button_2":
                targetValue = 1;
                Debug.Log("Targeting Enemy 2");
                en_button_1.SetActive(false);
                en_button_2.SetActive(false);
                en_button_3.SetActive(false);
                targetChosen = true;
                return true;
                //break;

            case "Enemy_Button_3":
                targetValue = 2;
                Debug.Log("Targeting Enemy 3");
                en_button_1.SetActive(false);
                en_button_2.SetActive(false);
                en_button_3.SetActive(false);
                targetChosen = true;
                return true;
                //break;

            default:
                Debug.Log("This shouldn't happen / Waiting on input");
                return false;
               // break;
        }
    }

    public bool targetButtonsAlly()
    {
        //targetButton = "nothing";
        targetValue = -1;
        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        //targetButton = EventSystem.current.currentSelectedGameObject.name;

        /*
        if (targetButton != "Enemy_Button_1" || targetButton != "Enemy_Button_2" || targetButton != "Enemy_Button_3")
        {
            return false;
        }
        */
        Debug.Log(targetButton);

        switch (targetButton)
        {
            case "Ally_Button_1":
                targetValue = 0;
                Debug.Log("Targeting Ally 1");
                p_button_1.SetActive(false);
                p_button_2.SetActive(false);
                p_button_3.SetActive(false);
                p_button_4.SetActive(false);
                targetChosen = true;
                return true;
            // break;

            case "Ally_Button_2":
                targetValue = 1;
                Debug.Log("Targeting Ally 2");
                p_button_1.SetActive(false);
                p_button_2.SetActive(false);
                p_button_3.SetActive(false);
                p_button_4.SetActive(false);
                targetChosen = true;
                return true;
            //break;

            case "Ally_Button_3":
                targetValue = 2;
                Debug.Log("Targeting Ally 3");
                p_button_1.SetActive(false);
                p_button_2.SetActive(false);
                p_button_3.SetActive(false);
                p_button_4.SetActive(false);
                targetChosen = true;
                return true;

            case "Ally_Button_4":
                targetValue = 3;
                Debug.Log("Targeting Ally 4");
                p_button_1.SetActive(false);
                p_button_2.SetActive(false);
                p_button_3.SetActive(false);
                p_button_4.SetActive(false);
                targetChosen = true;
                return true;

            default:
                Debug.Log("Waiting on input");
                return false;
                // break;
        }
    }

    // From this point here is just skills
    public IEnumerator singleTarget()
    {
        targetButton = "nothing";
        user = bs.GetComponent<BattleSystem>().activeUser;
        bs.GetComponent<BattleSystem>().activeUI.SetActive(false);
        Debug.Log("Who will " + user.characterName + " target?");
        bs.battleDialogue("Who will " + user.characterName + " target? (Click on an Enemy)");

        /*
        switch (bs.GM.GetComponent<EnemyFormations>().formationList[0].Count)
        {
            case 1:
                en_button_1.SetActive(true);
                break;

            case 2:
                en_button_1.SetActive(true);
                en_button_2.SetActive(true);
                break;

            case 3:
                en_button_1.SetActive(true);
                en_button_2.SetActive(true);
                en_button_3.SetActive(true);
                break;

            default:
                Debug.Log("This shouldn't happen");
                break;
        }
        */
       // bs = FindObjectOfType<BattleSystem>();
        if (bs.en1_exists)
        {
            if (bs.en_1.KO != true)
            {
                en_button_1.SetActive(true);
            }
        }

        if (bs.en2_exists)
        {
            if (bs.en_2.KO != true)
            {
                en_button_2.SetActive(true);
            }
        }

        if (bs.en3_exists)
        {
            if (bs.en_3.KO != true)
            {
                en_button_3.SetActive(true);
            }
        }
        /*
        Debug.Log("target chosen, targeting enemy number " + (targetValue + 1));
        target = bs.GM.GetComponent<EnemyFormations>().formationList[0][targetValue];
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);

        target = bs.GM.GetComponent<EnemyFormations>().formationList[0][targetValue];
        //StartCoroutine(setTarget());
        //StopAllCoroutines();
        */
        while (!targetChosen)
        {
            yield return null;
        }
        Debug.Log("Single Target is done");
        // Wait for player to input a target
    }

    public IEnumerator singleTargetAlly()
    {
        targetButton = "nothing";
        user = bs.GetComponent<BattleSystem>().activeUser;
        bs.GetComponent<BattleSystem>().activeUI.SetActive(false);
        Debug.Log("Who will " + user.characterName + " target?");
        bs.battleDialogue("Who will " + user.characterName + " target? (Click on an Ally)");

        if (bs.p1_exists)
        {
            if (bs.p1.KO != true)
            {
                p_button_1.SetActive(true);
            }
        }

        if (bs.p2_exists)
        {
            if (bs.p2.KO != true)
            {
                p_button_2.SetActive(true);
            }
        }

        if (bs.p3_exists)
        {
            if (bs.p3.KO != true)
            {
                p_button_3.SetActive(true);
            }
        }

        if (bs.p4_exists)
        {
            if (bs.p4.KO != true)
            {
                p_button_4.SetActive(true);
            }
        }
        /*
        Debug.Log("target chosen, targeting enemy number " + (targetValue + 1));
        target = bs.GM.GetComponent<EnemyFormations>().formationList[0][targetValue];
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);

        target = bs.GM.GetComponent<EnemyFormations>().formationList[0][targetValue];
        //StartCoroutine(setTarget());
        //StopAllCoroutines();
        */
        while (!targetChosen)
        {
            yield return null;
        }
        Debug.Log("Single Target (Ally) is done!");
        // Wait for player to input a target
    }

    public IEnumerator singleTargetAllyKO()
    {
        targetButton = "nothing";
        user = bs.GetComponent<BattleSystem>().activeUser;
        bs.GetComponent<BattleSystem>().activeUI.SetActive(false);
        Debug.Log("Who will " + user.characterName + " target?");
        bs.battleDialogue("Who will " + user.characterName + " target? (Click on an Ally)");

        if (bs.p1_exists)
        {
            if (bs.p1.KO == true)
            {
                p_button_1.SetActive(true);
            }
        }

        if (bs.p2_exists)
        {
            if (bs.p2.KO == true)
            {
                p_button_2.SetActive(true);
            }
        }

        if (bs.p3_exists)
        {
            if (bs.p3.KO == true)
            {
                p_button_3.SetActive(true);
            }
        }

        if (bs.p4_exists)
        {
            if (bs.p4.KO == true)
            {
                p_button_4.SetActive(true);
            }
        }
        /*
        Debug.Log("target chosen, targeting enemy number " + (targetValue + 1));
        target = bs.GM.GetComponent<EnemyFormations>().formationList[0][targetValue];
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);

        target = bs.GM.GetComponent<EnemyFormations>().formationList[0][targetValue];
        //StartCoroutine(setTarget());
        //StopAllCoroutines();
        */
        while (!targetChosen)
        {
            yield return null;
        }
        Debug.Log("Single Target (Ally) is done!");
        // Wait for player to input a target
    }

    public IEnumerator attack()
    {
        targetChosen = false;
        StartCoroutine(singleTarget());
        yield return new WaitUntil(targetButtons);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().enemyParty[targetValue]; //<EnemyFormations>().formationList[0][targetValue];

        if (target.immune != ELEMENTS.PHYS)
        {
            Debug.Log(user.characterName + " Attack: " + user.attack + "( w/ Modifiers: " + user.attack * user.atkModifier + ")");
            Debug.Log(target.characterName + " Defense: " + target.defense + "( w/ Modifiers: " + target.defense * target.defModifier + ")");
            float damage = (int)((user.attack * user.atkModifier) - (target.defense * target.defModifier));
            // All attacks should deal 1 damage minimum
            // This also prevents "negative" damage calculates from healing the target
            if (damage <= 0)
            {
                damage = 1;
            }
            Debug.Log(user.characterName + " attacked " + target.characterName + " for " + damage + " HP!");
            bs.battleDialogue(user.characterName + " attacked " + target.characterName + " for " + damage + " HP!");
            //target.hp = target.hp - (int) damage;
            Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (before)");

            target.hp -= (int)damage;

            Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (after)");

            // Pause before killing the enemy
            yield return new WaitForSeconds(2f);
            target.checkHP();
            if (target.KO == true)
            {
                bs.battleDialogue(target.characterName + " has been KO'd!");
                yield return new WaitForSeconds(2f);
            }
        }
        else
        {
            bs.battleDialogue(target.characterName + " is immune!");
            yield return new WaitForSeconds(2f);
        }
        bs.turnFinished = true;
    }

    public IEnumerator armorSmash()
    {
        targetChosen = false;
        StartCoroutine(singleTarget());
        yield return new WaitUntil(targetButtons);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().enemyParty[targetValue]; //<EnemyFormations>().formationList[0][targetValue];

        if (target.immune != ELEMENTS.PHYS)
        {
            Debug.Log(user.characterName + " Attack: " + user.attack + "( w/ Modifiers: " + user.attack * user.atkModifier + ")");
            Debug.Log(target.characterName + " Defense: " + target.defense + "( w/ Modifiers: " + target.defense * target.defModifier + ")");
            float damage = (int)((user.attack * user.atkModifier) - (target.defense * target.defModifier));
            // All attacks should deal 1 damage minimum
            // This also prevents "negative" damage calculates from healing the target
            if (damage <= 0)
            {
                damage = 1;
            }
            Debug.Log(user.characterName + " used Armor Smash on " + target.characterName + " for " + damage + " HP!");
            bs.battleDialogue(user.characterName + " used Armor Smash " + target.characterName + " for " + damage + " HP!");
            //target.hp = target.hp - (int) damage;
            Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (before)");

            target.hp -= (int)damage;
            target.defenseDown();

            Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (after)");

            // Pause before killing the enemy
            yield return new WaitForSeconds(2f);
            target.checkHP();
            if (target.KO == true)
            {
                bs.battleDialogue(target.characterName + " has been KO'd!");
                yield return new WaitForSeconds(2f);
            }
        }
        else
        {
            bs.battleDialogue(target.characterName + " is immune!");
            yield return new WaitForSeconds(2f);
        }
        bs.turnFinished = true;
    }

    public IEnumerator wildSwing()
    {
        user = bs.GetComponent<BattleSystem>().activeUser;
        int damage = (int)(user.attack * 0.5);
        Debug.Log(user.characterName + " swung wildy at the enemy party for " + damage + " HP!");
        bs.battleDialogue(user.characterName + " swung wildy at the enemy party for " + damage + " HP!");

        yield return new WaitForSeconds(2f);
        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            if (c.KO == false)
            {
                c.hp -= 15;
                c.checkHP();
                if (c.KO == true)
                {
                    bs.battleDialogue(c.characterName + " has been KO'd!");
                    yield return new WaitForSeconds(1f);
                }
            }
        }

        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }
    public void attack_E(Character e, Character p)
    {
        if (p.immune != ELEMENTS.PHYS)
        {

            int damage = (int)((e.attack * e.atkModifier) - (p.defense * p.defModifier));
            if (p.isDefending)
            {
                damage = (damage / 2);
            }

            if (damage <= 0)
            {
                damage = 1;
            }
            Debug.Log(e.characterName);
            Debug.Log(p.characterName);
            Debug.Log("Damage: " + damage);
            bs = FindObjectOfType<BattleSystem>();
            bs.battleDialogue(e.characterName + " attacked " + p.characterName + " for " + damage + " HP!");
            //bs.battleDialogue("Enemy Attacks!");
            //yield return new WaitForSeconds(2f);

            Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");

            p.hp -= damage;

            Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");


            p.checkHP();
        } else
        {
            bs.battleDialogue(p.characterName + " is immune!");
        }
        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }

    // A "Physical" Attack that bypasses PHYS immunity
    public void swordBeam_E(Character e, Character p)
    {
        int damage = (int)((e.attack * e.atkModifier) - (p.defense * p.defModifier));
        if (p.isDefending)
        {
            damage = (damage / 2);
        }

        if (damage <= 0)
        {
            damage = 1;
        }
        Debug.Log(e.characterName);
        Debug.Log(p.characterName);
        Debug.Log("Damage: " + damage);
        bs = FindObjectOfType<BattleSystem>();
        bs.battleDialogue(e.characterName + " shot a Sword Beam at " + p.characterName + " for " + damage + " HP!");
        //bs.battleDialogue("Enemy Attacks!");
        //yield return new WaitForSeconds(2f);

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");

        p.hp -= damage;

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");


        p.checkHP();
        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }

    // Slightly weaker physical attack that inflicts poison
    public void poisonStab_E(Character e, Character p)
    {
        if (p.immune != ELEMENTS.PHYS)
        {

            int damage = (int)((e.attack * e.atkModifier) * .75f - (p.defense * p.defModifier));
            if (p.isDefending)
            {
                damage = (damage / 2);
            }

            if (damage <= 0)
            {
                damage = 1;
            }
            Debug.Log(e.characterName);
            Debug.Log(p.characterName);
            Debug.Log("Damage: " + damage);
            bs = FindObjectOfType<BattleSystem>();
            bs.battleDialogue(e.characterName + " attacked " + p.characterName + " for " + damage + " HP and inflicted poison!");
            //bs.battleDialogue("Enemy Attacks!");
            //yield return new WaitForSeconds(2f);

            Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");

            p.hp -= damage;
            p.poison();

            Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");


            p.checkHP();
        }
        else
        {
            bs.battleDialogue(p.characterName + " is immune!");
        }
        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }

    // Mortal Wound
    // Sets Target's HP to 1
    public void mortalWound_E(Character e, Character p)
    {
        if (p.immune != ELEMENTS.PHYS)
        {
            Debug.Log(e.characterName);
            Debug.Log(p.characterName);
            bs = FindObjectOfType<BattleSystem>();
            bs.battleDialogue(e.characterName + " mortally wounds' " + p.characterName + "!");
            //bs.battleDialogue("Enemy Attacks!");
            //yield return new WaitForSeconds(2f);

            Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");

            p.hp = 1;

            Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");


            p.checkHP();
        }
        else
        {
            bs.battleDialogue(p.characterName + " is immune!");
        }
        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }


    public void magicMissle_E(Character e, Character p)
    {
        int damage = (int)((e.magic * e.magModifier) - (p.resistance * p.resModifier));
        if (p.isDefending)
        {
            damage = (damage / 2);
        }

        if (damage <= 0)
        {
            damage = 1;
        }
        Debug.Log(e.characterName);
        Debug.Log(p.characterName);
        Debug.Log("Damage: " + damage);
        bs = FindObjectOfType<BattleSystem>();
        bs.battleDialogue(e.characterName + " cast Magic Missle on " + p.characterName + " for " + damage + " HP!");
        //bs.battleDialogue("Enemy Attacks!");
        //yield return new WaitForSeconds(2f);

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");

        p.hp -= damage;

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");


        p.checkHP();
        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }

    // Light Element Magic Spell
    // Deals Double Damage to Characters weak to LIGHT
    public void purge_E(Character e, Character p)
    {
        int damage = (int)((e.magic * e.magModifier) * 1.2 - (p.resistance * p.resModifier));
        if (p.isDefending)
        {
            damage = (damage / 2);
        }

        if (damage <= 0)
        {
            damage = 1;
        }

        // If target is weak, deal double damage
        if (p.weak == ELEMENTS.LIGHT)
        {
            damage = (damage * 2);
        }
        Debug.Log(e.characterName);
        Debug.Log(p.characterName);
        Debug.Log("Damage: " + damage);
        bs = FindObjectOfType<BattleSystem>();
        bs.battleDialogue(e.characterName + " cast Purge on " + p.characterName + " for " + damage + " HP!");
        //bs.battleDialogue("Enemy Attacks!");
        //yield return new WaitForSeconds(2f);

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");

        p.hp -= damage;

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");


        p.checkHP();
        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }

    // Fire Element Magic Spell
    // Deals Double Damage to Characters weak to FIRE
    public void fire_E(Character e, Character p)
    {
        int damage = (int)((e.magic * e.magModifier) * 1.2 - (p.resistance * p.resModifier));
        if (p.isDefending)
        {
            damage = (damage / 2);
        }

        if (damage <= 0)
        {
            damage = 1;
        }

        // If target is weak, deal double damage
        if (p.weak == ELEMENTS.FIRE)
        {
            damage = (damage * 2);
        }
        Debug.Log(e.characterName);
        Debug.Log(p.characterName);
        Debug.Log("Damage: " + damage);
        bs = FindObjectOfType<BattleSystem>();
        bs.battleDialogue(e.characterName + " cast fire on " + p.characterName + " for " + damage + " HP!");
        //bs.battleDialogue("Enemy Attacks!");
        //yield return new WaitForSeconds(2f);

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");

        p.hp -= damage;

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");


        p.checkHP();
        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }

    // Stronger Magic Spell
    public void thunder_E(Character e, Character p)
    {
        int damage = (int)((e.magic * e.magModifier) * 1.5 - (p.resistance * p.resModifier));
        if (p.isDefending)
        {
            damage = (damage / 2);
        }

        if (damage <= 0)
        {
            damage = 1;
        }

        Debug.Log(e.characterName);
        Debug.Log(p.characterName);
        Debug.Log("Damage: " + damage);
        bs = FindObjectOfType<BattleSystem>();
        bs.battleDialogue(e.characterName + " cast thunder on " + p.characterName + " for " + damage + " HP!");
        //bs.battleDialogue("Enemy Attacks!");
        //yield return new WaitForSeconds(2f);

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");

        p.hp -= damage;

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");


        p.checkHP();
        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }

    // Basic Single Target Attack that lower's the target's defense afterward
    // Slightly Stronger too
    // Physical Attack that cannot hit PHYS Immune
    public void armorSmash_E(Character e, Character p)
    {
        if (p.immune != ELEMENTS.PHYS)
        {
            int damage = (int)((e.attack * e.atkModifier) * 1.2 - (p.defense * p.defModifier));
            if (p.isDefending)
            {
                damage = (damage / 2);
            }

            if (damage <= 0)
            {
                damage = 1;
            }
            Debug.Log(e.characterName);
            Debug.Log(p.characterName);
            Debug.Log("Damage: " + damage);
            bs = FindObjectOfType<BattleSystem>();
            bs.battleDialogue(e.characterName + " used armor smash on " + p.characterName + " for " + damage + " HP!");
            //bs.battleDialogue("Enemy Attacks!");
            //yield return new WaitForSeconds(2f);

            Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");

            p.hp -= damage;
            p.defenseDown();

            Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");


            p.checkHP();
        } else
        {
            bs.battleDialogue(p.characterName + " is immune!");
        }
        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }

    // Attack reducing variant of armor smash
    // Physical Attack that cannot hit PHYS Immune
    public void cripple_E(Character e, Character p)
    {
        if (p.immune != ELEMENTS.PHYS)
        {
            int damage = (int)((e.attack * e.atkModifier) * 1.2 - (p.defense * p.defModifier));
            if (p.isDefending)
            {
                damage = (damage / 2);
            }

            if (damage <= 0)
            {
                damage = 1;
            }
            Debug.Log(e.characterName);
            Debug.Log(p.characterName);
            Debug.Log("Damage: " + damage);
            bs = FindObjectOfType<BattleSystem>();
            bs.battleDialogue(e.characterName + " used cripple on " + p.characterName + " for " + damage + " HP!");
            //bs.battleDialogue("Enemy Attacks!");
            //yield return new WaitForSeconds(2f);

            Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");

            p.hp -= damage;
            p.attackDown();

            Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");


            p.checkHP();
        } else
        {
            bs.battleDialogue(p.characterName + " is immune!");
        }
        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }

    // Inflicts an all stats down on the target
    public void sneer_E(Character e, Character p)
    {
        Debug.Log(e.characterName);
        Debug.Log(p.characterName);
        bs = FindObjectOfType<BattleSystem>();
        bs.battleDialogue(e.characterName + " sneers at " + p.characterName + "!");
        //bs.battleDialogue("Enemy Attacks!");
        //yield return new WaitForSeconds(2f);

        p.attackDown();
        p.defenseDown();
        p.magicDown();
        p.resDown();

        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }

    // Inflicts a defense and ress debuff on the enemy party
    // weaker mandragora effect
    public IEnumerator ghastlyWail()
    {
        user = bs.GetComponent<BattleSystem>().activeUser;
        Debug.Log(user.characterName + " let out a ghastly wail to frighten the enemy party!");
        bs.battleDialogue(user.characterName + " let out a ghastly wail to frighten the enemy party!");

        // This item should only have an effect on a KO'd opponent
        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            c.defenseDown();
            c.resDown();
        }

        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    // This won't work on a Boss Enemy
    public IEnumerator poisonSpore()
    {
        targetChosen = false;
        StartCoroutine(singleTarget());
        yield return new WaitUntil(targetButtons);

        target = bs.GM.GetComponent<GameManager>().enemyParty[targetValue];

        bs.battleDialogue(user.characterName + " shot poisons spores at " + target.characterName + "!");
        yield return new WaitForSeconds(1f);

        target.poison();

        bs.turnFinished = true;
    }

    // Full party Heal
    public IEnumerator healSpore()
    {
        user = bs.GetComponent<BattleSystem>().activeUser;
        Debug.Log(user.characterName + " used a healing spores to heal the party for 15 HP and clear statuses!");
        bs.battleDialogue(user.characterName + " used a healing spores to heal the party for 15 HP and clear statuses!");

        // Give each viable ally a defense up buff
        foreach (Character c in FindObjectOfType<GameManager>().GetComponent<GameManager>().playerParty)
        {
            if (c.type != "DUMMY" && c.KO == false)
            {
                c.hp += 15;
                c.statusRestore();
                c.checkHP();
            }
        }


        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    public IEnumerator defend()
    {
        user = bs.GetComponent<BattleSystem>().activeUser;
        bs.GetComponent<BattleSystem>().activeUI.SetActive(false);
        user.isDefending = true;
        bs.battleDialogue(user.characterName + " is defending!");
        yield return new WaitForSeconds(2f);
        bs.turnFinished = true;
    }

    // This is a spell that deals random set damage regardless of the user and target's stats
    // The odds are roughly as follows:
    //  10% - 1 damage
    //  20% - 5 damage
    //  30% - 10 damage
    //  30% - 15 damage
    //  1%  - 99 damage (Lucky!)
    //  9%  - 25 damage
    public IEnumerator luckyStar()
    {
        targetChosen = false;
        StartCoroutine(singleTarget());
        yield return new WaitUntil(targetButtons);

        target = bs.GM.GetComponent<GameManager>().enemyParty[targetValue];

        bs.battleDialogue(user.characterName + " cast Lucky Star on " + target.characterName + "!");
        yield return new WaitForSeconds(1f);

        int star = Random.Range(0, 100);
        float damage = 0f;
        Debug.Log("Lucky Star Roll: " + star);

        if (star <=10)
        {
            damage = 1;
            bs.battleDialogue("Lucky Star dealt " + damage + "!");
        } else if (10 < star && star <= 30) {
            damage = 5;
            bs.battleDialogue("Lucky Star dealt " + damage + "!");
        } else if (30 < star && star <= 60)
        {
            damage = 10;
            bs.battleDialogue("Lucky Star dealt " + damage + "!");
        } else if (60 < star && star <= 90)
        {
            damage = 15;
            bs.battleDialogue("Lucky Star dealt " + damage + "!");
        } else if (star == 91)
        {
            damage = 99;
            bs.battleDialogue("LUCKY! Lucky Star dealt " + damage + "!");
        } else if (91 < star)
        {
            damage = 25;
            bs.battleDialogue("Lucky Star dealt " + damage + "!");
        }
        Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (before)");

        target.hp -= (int)damage;

        Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (after)");

        // Pause before killing the enemy
        yield return new WaitForSeconds(2f);
        target.checkHP();
        if (target.KO == true)
        {
            bs.battleDialogue(target.characterName + " has been KO'd!");
            yield return new WaitForSeconds(2f);
        }
        bs.turnFinished = true;
    }

    public IEnumerator heal()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAlly());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " Magic: " + user.magic);
        float healing = (user.magic + 5);
        Debug.Log(user.characterName + " healed " + target.characterName + " for " + healing + " HP!");
        bs.battleDialogue(user.characterName + " healed " + target.characterName + " for " + healing + " HP!");
        //target.hp = target.hp - (int) damage;
        Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (before)");

        target.hp += (int)healing;

         Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (after)");

         // Pause for text
         yield return new WaitForSeconds(2f);

        // Fix HP if it is higher than it should be
         target.checkHP();
        bs.turnFinished = true;
    }

    // Heal Function for enemies
    // Heals all enemies in the party for a small set amount (5)
    // Why not factor in enemy magic stat? - Causes Too much healing
    // Keep it low, keep it fair and fun for the player
    public void heal_E(Character e)
    {
        //List<Character> enemyList = bs.GM.GetComponent<GameManager>().enemyParty;
        bs = FindObjectOfType<BattleSystem>();

        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            if(c.KO == false)
            {
                c.hp += 5;
                c.checkHP();
            }
        }
        Debug.Log(e.characterName + " healed the enemy party!");
        bs.battleDialogue(e.characterName + " healed the enemy party!");

        bs.updatePartyHUD_Enemy();
    }

    public IEnumerator rallyATK()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAlly());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " boosted " + target.characterName + "'s attack!");
        bs.battleDialogue(user.characterName + " boosted " + target.characterName + "'s attack!");
        //target.hp = target.hp - (int) damage;

        target.attackUp();
        Debug.Log(target.characterName + "'s atk buiff counter = " + target.atkCounter);

        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    public void rallyATK_E(Character e)
    {
        //List<Character> enemyList = bs.GM.GetComponent<GameManager>().enemyParty;
        bs = FindObjectOfType<BattleSystem>();

        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            if(c.KO == false)
            {
                c.attackUp();
            }
        }
        Debug.Log(e.characterName + " boosted the enemy party's attack!");
        bs.battleDialogue(e.characterName + " boosted the enemy party's attack!");

        bs.updatePartyHUD_Enemy();
    }

    public IEnumerator rallyDEF()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAlly());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " boosted " + target.characterName + "'s defense!");
        bs.battleDialogue(user.characterName + " boosted " + target.characterName + "'s defense!");
        //target.hp = target.hp - (int) damage;

        target.defenseUp();
        Debug.Log(target.characterName + "'s def buiff counter = " + target.defCounter);

        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    // Rally Defense - Enemy Variant
    public void rallyDEF_E(Character e)
    {
        //List<Character> enemyList = bs.GM.GetComponent<GameManager>().enemyParty;
        bs = FindObjectOfType<BattleSystem>();

        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            if (c.KO == false)
            {
                c.defenseUp();
            }
        }
        Debug.Log(e.characterName + " boosted the enemy party's defense!");
        bs.battleDialogue(e.characterName + " boosted the enemy party's defense!");

        bs.updatePartyHUD_Enemy();
    }

    public IEnumerator rallyMAG()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAlly());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " boosted " + target.characterName + "'s magic!");
        bs.battleDialogue(user.characterName + " boosted " + target.characterName + "'s magic!");
        //target.hp = target.hp - (int) damage;

        target.magicUp();
        Debug.Log(target.characterName + "'s mag buiff counter = " + target.magCounter);

        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    // Rally Magic - Enemy Variant
    public void rallyMAG_E(Character e)
    {
        //List<Character> enemyList = bs.GM.GetComponent<GameManager>().enemyParty;
        bs = FindObjectOfType<BattleSystem>();

        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            if (c.KO == false)
            {
                c.attackUp();
            }
        }
        Debug.Log(e.characterName + " boosted the enemy party's magic!");
        bs.battleDialogue(e.characterName + " boosted the enemy party's magic!");

        bs.updatePartyHUD_Enemy();
    }

    public IEnumerator rallyRES()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAlly());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " boosted " + target.characterName + "'s resistance!");
        bs.battleDialogue(user.characterName + " boosted " + target.characterName + "'s resistance!");
        //target.hp = target.hp - (int) damage;

        target.resUp();
        Debug.Log(target.characterName + "'s res buiff counter = " + target.resCounter);

        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    // Rally Enemy Resistance
    public void rallyRES_E(Character e)
    {
        //List<Character> enemyList = bs.GM.GetComponent<GameManager>().enemyParty;
        bs = FindObjectOfType<BattleSystem>();

        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            if (c.KO == false)
            {
                c.resUp();
            }
        }
        Debug.Log(e.characterName + " boosted the enemy party's resistance!");
        bs.battleDialogue(e.characterName + " boosted the enemy party's resistance!");

        bs.updatePartyHUD_Enemy();
    }

    // Heals all enemy status effects
    public void healStatus_E(Character e)
    {
        //List<Character> enemyList = bs.GM.GetComponent<GameManager>().enemyParty;
        bs = FindObjectOfType<BattleSystem>();

        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            if (c.KO == false)
            {
                c.statusRestore();
            }
        }
        Debug.Log(e.characterName + " removed all negative status effects!");
        bs.battleDialogue(e.characterName + " removed all negative status effects!");

        bs.updatePartyHUD_Enemy();
    }

    public void minusStrike_E(Character e, Character p)
    {
        int damage = (e.maxHP - e.hp);//(int)((e.attack * e.atkModifier) - (p.defense * p.defModifier));
        if (p.isDefending)
        {
            damage = (damage / 2);
        }

        if (damage <= 0)
        {
            damage = 1;
        }
        Debug.Log(e.characterName);
        Debug.Log(p.characterName);
        Debug.Log("Damage: " + damage);
        bs = FindObjectOfType<BattleSystem>();
        bs.battleDialogue(e.characterName + " used Minus Strike on " + p.characterName + " for " + damage + " HP!");
        //bs.battleDialogue("Enemy Attacks!");
        //yield return new WaitForSeconds(2f);

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");

        p.hp -= damage;

        Debug.Log(p.characterName + " HP: " + p.hp + "/" + p.maxHP + " (before)");


        p.checkHP();
        /*
        if (p.KO == true)
        {
            bs.battleDialogue(p.characterName + " has been KO'd!");
            //yield return new WaitForSeconds(2f);
        }
        */
    }


    // ITEM METHODS
    public IEnumerator potion()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAlly());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " healed " + target.characterName + " for 20 HP!");
        bs.battleDialogue(user.characterName + " used a potion and healed " + target.characterName + " for 20 HP!");
        //target.hp = target.hp - (int) damage;
        Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (before)");

        target.hp += 20;

        Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (after)");

        // Pause for text
        yield return new WaitForSeconds(2f);

        // Fix HP if it is higher than it should be
        target.checkHP();
        bs.turnFinished = true;
    }

    public IEnumerator hiPotion()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAlly());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " healed " + target.characterName + " for 50 HP!");
        bs.battleDialogue(user.characterName + " used a HiPotion and healed " + target.characterName + " for 50 HP!");
        //target.hp = target.hp - (int) damage;
        Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (before)");

        target.hp += 50;

        Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (after)");

        // Pause for text
        yield return new WaitForSeconds(2f);

        // Fix HP if it is higher than it should be
        target.checkHP();
        bs.turnFinished = true;
    }

    public IEnumerator ether()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAlly());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " used an ether to restore 20 MP to " + target.characterName + "!");
        bs.battleDialogue(user.characterName + " used an ether to restore 20 MP to " + target.characterName + "!");
        //target.hp = target.hp - (int) damage;
        Debug.Log(target.characterName + " (" + targetValue + ") MP: " + target.mp + "/" + target.maxMP + " (before)");

        target.mp += 20;

        Debug.Log(target.characterName + " (" + targetValue + ") MP: " + target.mp + "/" + target.maxMP + " (after)");

        // Pause for text
        yield return new WaitForSeconds(2f);

        // Fix HP if it is higher than it should be
        target.checkMP();
        bs.turnFinished = true;
    }

    public IEnumerator hiEther()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAlly());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " used an ether to restore 50 MP to " + target.characterName + "!");
        bs.battleDialogue(user.characterName + " used an ether to restore 50 MP to " + target.characterName + "!");
        //target.hp = target.hp - (int) damage;
        Debug.Log(target.characterName + " (" + targetValue + ") MP: " + target.mp + "/" + target.maxMP + " (before)");

        target.mp += 50;

        Debug.Log(target.characterName + " (" + targetValue + ") MP: " + target.mp + "/" + target.maxMP + " (after)");

        // Pause for text
        yield return new WaitForSeconds(2f);

        // Fix HP if it is higher than it should be
        target.checkMP();
        bs.turnFinished = true;
    }

    public IEnumerator fullPotion()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAlly());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " used a full potion on " + target.characterName + "!");
        bs.battleDialogue(user.characterName + " used a full potion on " + target.characterName + "!");

        Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (before)");
        Debug.Log(target.characterName + " (" + targetValue + ") MP: " + target.mp + "/" + target.maxMP + " (before)");

        target.fullRestore();

        Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (after)");
        Debug.Log(target.characterName + " (" + targetValue + ") MP: " + target.mp + "/" + target.maxMP + " (after)");

        // Pause for text
        yield return new WaitForSeconds(2f);

        // Fix HP if it is higher than it should be
        target.checkHP();
        target.checkMP();
        bs.turnFinished = true;
    }

    // This item cures any negative status effects a Character has
    // Does not effect positive status effects
    public IEnumerator refresh()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAlly());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " used a refresh on " + target.characterName + "!");
        bs.battleDialogue(user.characterName + " used a refresh " + target.characterName + "!");

        //Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + " (before)");
        //Debug.Log(target.characterName + " (" + targetValue + ") MP: " + target.mp + "/" + target.maxMP + " (before)");

        target.statusRestore();

        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    public IEnumerator revivalHerb()
    {
        targetChosen = false;
        StartCoroutine(singleTargetAllyKO());
        yield return new WaitUntil(targetButtonsAlly);
        /*
        en_button_1.SetActive(false);
        en_button_2.SetActive(false);
        en_button_3.SetActive(false);
        */
        target = bs.GM.GetComponent<GameManager>().playerParty[targetValue];

        Debug.Log(user.characterName + " used a revival Herb on " + target.characterName + "!");
        bs.battleDialogue(user.characterName + " used a revival Herb on " + target.characterName + "!");

        // This item should only have an effect on a KO'd Ally
        if (target.KO == true)
        {
            Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + ", KO: " + target.KO + " (before)");
            target.cureKO();

            // Restore HP to half after revival
            target.hp = (int)(target.maxHP / 2);

            Debug.Log(target.characterName + " (" + targetValue + ") HP: " + target.hp + "/" + target.maxHP + ", KO: " + target.KO + " (After)");
        }


        // Pause for text
        yield return new WaitForSeconds(2f);

        target.checkHP();
        bs.turnFinished = true;
    }

    // Grants a defense up to the entire player party
    public IEnumerator pavise()
    {
        user = bs.GetComponent<BattleSystem>().activeUser;
        Debug.Log(user.characterName + " used a pavise to boost their party's defenses!");
        bs.battleDialogue(user.characterName + " used a pavise to boost their party's defenses!");

        // Give each viable ally a defense up buff
        foreach (Character c in FindObjectOfType<GameManager>().GetComponent<GameManager>().playerParty)
        {
            if (c.type != "DUMMY" && c.KO == false)
            {
                c.defenseUp();
            }
        }


        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    // Grants a resistance up to the entire player party
    public IEnumerator wardingCharm()
    {
        user = bs.GetComponent<BattleSystem>().activeUser;
        Debug.Log(user.characterName + " used a warding charm to boost their party's resistance!");
        bs.battleDialogue(user.characterName + " used a warding charm to boost their party's resistance!");

        // Give each viable party memebver
        foreach (Character c in FindObjectOfType<GameManager>().GetComponent<GameManager>().playerParty)
        {
            if (c.type != "DUMMY" && c.KO == false)
            {
                c.resUp();
            }
        }


        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    // Inflicts an all stat down debuff to the entire enemy party
    public IEnumerator mandragora()
    {
        user = bs.GetComponent<BattleSystem>().activeUser;
        Debug.Log(user.characterName + " used a Mandragora to frighten the enemy party!");
        bs.battleDialogue(user.characterName + " used a Mandragora to frighten the enemy party!");

        // This item should only have an effect on a KO'd opponent
        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            c.attackDown();
            c.defenseDown();
            c.magicDown();
            c.resDown();
        }

        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    // Deals a flat 15 damage to all enemies on the screen
    public IEnumerator bomb()
    {
        user = bs.GetComponent<BattleSystem>().activeUser;
        Debug.Log(user.characterName + " used a Bomb to damage the enemy party for 15 HP!");
        bs.battleDialogue(user.characterName + " used a Bomb to damage the enemy party for 15 HP!");

        yield return new WaitForSeconds(2f);
        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            if (c.KO == false)
            {
                c.hp -= 15;
                c.checkHP();
                if (c.KO == true)
                {
                    bs.battleDialogue(c.characterName + " has been KO'd!");
                    yield return new WaitForSeconds(1f);
                }
            }
        }

        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    // Deals a 
    public IEnumerator gasBomb()
    {
        user = bs.GetComponent<BattleSystem>().activeUser;
        Debug.Log(user.characterName + " used a gas bomb to poison the enemy party!");
        bs.battleDialogue(user.characterName + " used a gas bomb to poison the enemy party!");

        // This item should only have an effect on a KO'd opponent
        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            if(c.KO == false)
            {
                c.poison();
            }
        }

        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }

    public IEnumerator smokeBomb()
    {
        user = bs.GetComponent<BattleSystem>().activeUser;
        Debug.Log(user.characterName + " used a smoke bomb to escape!");
        bs.battleDialogue(user.characterName + " used a smoke bomb to escape!");

        yield return new WaitForSeconds(2f);
        bs.turnFinished = true;
        FindObjectOfType<GameManager>().loadBase();
    }

    public IEnumerator nuke()
    {
        user = bs.GetComponent<BattleSystem>().activeUser;
        Debug.Log(user.characterName + " Nuked the enemy party for 99 HP!");
        bs.battleDialogue(user.characterName + " Nuked the damage the enemy party for 99 HP!");

        yield return new WaitForSeconds(2f);
        // This item should only have an effect on a KO'd opponent
        foreach (Character c in bs.GM.GetComponent<GameManager>().enemyParty)
        {
            if (c.KO == false)
            {
                c.hp -= 99;
                c.checkHP();
                if (c.KO == true)
                {
                    bs.battleDialogue(c.characterName + " has been KO'd!");
                    yield return new WaitForSeconds(1f);
                }
            }
        }

        // Pause for text
        yield return new WaitForSeconds(2f);

        bs.turnFinished = true;
    }
}
