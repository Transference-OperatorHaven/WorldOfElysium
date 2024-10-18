using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterStat", order = 1)]
public class CharacterStats : ScriptableObject
{
    public enum StatType
    {
        attribute,
        skill,
        power
    }

    [System.Serializable]
    public struct Stat
    {
        public string statName;
        public string statDescLong;
        public string statDescShort;
        public int statLevel;
        public StatType statType;
    }

    public Stat[] stats;
    
}
