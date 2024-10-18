using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class StatChanger : MonoBehaviour
{
    public Player player;

    public TMP_InputField input;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void ChangeStat(int value)
    {

        if (player.stats.stats[Convert.ToInt32(input.text)].statLevel + value < 0 || player.stats.stats[Convert.ToInt32(input.text)].statLevel + value > 5)
        {
        }
        else
        {
            player.stats.stats[Convert.ToInt32(input.text)].statLevel += value;
        }
        



        Debug.Log("set " + player.stats.stats[Convert.ToInt32(input.text)].statName + " to " + player.stats.stats[Convert.ToInt32(input.text)].statLevel);
    }
}
