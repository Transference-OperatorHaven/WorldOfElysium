using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class XPManager : MonoBehaviour
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

    int SpentXP;
    int TempUsedXP;
    List<int> alteredSkillIDs = new List<int>();
    SkillCheck skillCheck;
    Player player;
    Canvas canvas;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();
        canvas = FindFirstObjectByType<Canvas>();
    }

    public void IncreaseLevel(int id)
    {
        if (player.stats.stats[id].statLevel >= 5) { return; }
        if (player.xp - ((player.stats.stats[id].statLevel + 1) * (id > 8 ? 3 : 5)) > 0)
        {
            player.xp -= (player.stats.stats[id].statLevel + 1) * (id > 8 ? 3 : 5);
            TempUsedXP += (player.stats.stats[id].statLevel + 1) * (id > 8 ? 3 : 5);
            player.stats.stats[id].statLevel++;
            alteredSkillIDs.Add(id);
            Debug.Log("Leveled " + player.stats.stats[id].statName + "To Level " + player.stats.stats[id].statLevel);
        }
        else
        {
            Debug.Log("not enough XP!");
        }
    }

    public void SetXP(int amount)
    {
        player.xp = amount;
    }

    public void AddXP(int amount)
    {
        player.xp += amount;
    }

    public void Apply()
    {
        TempUsedXP = 0;
        alteredSkillIDs.Clear();
    }

    public void UndoChanges()
    {
         for(int i = 0; i < alteredSkillIDs.Count; i++)
         {
            player.stats.stats[alteredSkillIDs[i]].statLevel--;
         }
        foreach (Button button in canvas.GetComponentsInChildren<Button>())
        {
            if (button.GetComponent<SheetIconUpdate>() != null)
            {
                button.GetComponent<SheetIconUpdate>().UpdateStatIcon();
            }
        }
        player.xp += TempUsedXP;
        TempUsedXP = 0;
        alteredSkillIDs.Clear();
    }
}
