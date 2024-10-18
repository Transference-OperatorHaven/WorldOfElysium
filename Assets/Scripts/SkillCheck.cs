using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class SkillCheck : MonoBehaviour
{
    public enum Attribute
    {
        Strength,
        Dexterity,
        Stamina,
        Charisma,
        Manipulation,
        Composure,
        Intelligence,
        Wits,
        Resolve
    }
    public enum Skill
    {
        Athletics,
        Brawl,
        Craft,
        Drive,
        Firearms,
        Melee,
        Larceny,
        Stealth,
        Survival,
        AnimalKen,
        Etiquette,
        Insight,
        Intimidation,
        Leadership,
        Performance,
        Persuasion,
        Streetwise,
        Subterfuge,
        Academics,
        Awareness,
        Finance,
        Investigation,
        Medicine,
        Occult,
        Politics,
        Science,
        Technology
    }

    public Attribute attribute;
    public Skill skill;
    public int difficulty;
    public int successCount;
    public bool bSucceeded, bMessyCrit, bBestialFail;


    Player player;
    RollResults rollResults;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        rollResults = GameObject.FindGameObjectWithTag("Roll").GetComponent<RollResults>();
    }

    public void CheckSkill(int Difficulty)
    {
        successCount = 0;
        bSucceeded = false;
        bMessyCrit = false;
        bBestialFail = false;
        difficulty = Difficulty;
        int hungerDice = player.hunger;
        int attributeDice = player.stats.stats[(int)attribute].statLevel;
        int skillDice = player.stats.stats[9+(int)skill].statLevel;

        for(int i = 0; i < attributeDice; i++)
        {
            if(hungerDice > 0)
            {
                successCount += DiceRoll(true);
                hungerDice--;
            }
            else
            {
                successCount += DiceRoll(false);
            }
        }
        for (int i = 0; i < skillDice; i++)
        {
            if (hungerDice > 0)
            {
                successCount += DiceRoll(true);
                hungerDice--;
            }
            else
            {
                successCount += DiceRoll(false);
            }
        }

        bSucceeded = successCount >= difficulty ? true : false;
        Debug.Log("Succeed? " + bSucceeded + ", Successes: " + successCount + ", Bestial Failure? " + bBestialFail + ", Messy Crit? " + bMessyCrit);

        if(bSucceeded)
        {
            rollResults.RollResultsStart(true, successCount, bMessyCrit);
        }
        else
        {
            rollResults.RollResultsStart(false, successCount, bBestialFail);
        }
        
        
    }

    int DiceRoll(bool hungerRoll)
    {
        int success = 0;
        if (hungerRoll)
        {

            int result = Random.Range(1, 11);
            if (result == 1)
            {
                bBestialFail = true;
                success = 0;
            }
            else if (result > 1 && result < 6)
            {
                success = 0;
            }
            else if (result > 5 && result < 10)
            {
                success = 1;
            }
            else if (result == 10)
            {
                success = 2;
                bMessyCrit = true;
            }

        }
        else
        {
            int result = Random.Range(1, 11);
            if(result > 5 & result < 10)
            {
                success = 1;
            }
            else if (result == 10)
            {
                success = 2;
            }
            else
            {
                success = 0;
            }
        }


        return success;
    }

    


}
