using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetStats : MonoBehaviour
{
    public Player player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void Reset()
    {
        for(int i = 0; i < 36; i++)
        {
            player.stats.stats[i].statLevel = 0;
        }
    }
}
