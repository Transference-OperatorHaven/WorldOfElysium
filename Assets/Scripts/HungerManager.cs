using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static SkillCheck;

public class HungerManager : MonoBehaviour
{
    public TMP_InputField hunger;
    Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void hungerButton()
    {
        Debug.Log("Set hunger to: " + Convert.ToInt32(hunger.text));
        player.hunger = Convert.ToInt32(hunger.text);
    }

}
