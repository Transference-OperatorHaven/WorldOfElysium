using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class SkillCheckUI : MonoBehaviour
{
    public TMP_InputField attribute, skill, diffculty;
    public SkillCheck skillCheck;
    public void ButtonPress()
    {
        skillCheck.attribute = (SkillCheck.Attribute)Convert.ToInt32(attribute.text);
        skillCheck.skill = (SkillCheck.Skill)(Convert.ToInt32(skill.text)-9);
        skillCheck.CheckSkill(Convert.ToInt32(diffculty.text));
    }

}
