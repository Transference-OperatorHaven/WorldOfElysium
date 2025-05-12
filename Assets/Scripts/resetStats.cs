using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetStats : MonoBehaviour
{
    public Player player;
    Canvas canvas;
    void Start()
    {
        canvas = FindFirstObjectByType<Canvas>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void Reset()
    {
        for(int i = 0; i < 36; i++)
        {
            player.stats.stats[i].statLevel = 0;
        }
        foreach (Button button in canvas.GetComponentsInChildren<Button>())
        {
            if(button.GetComponent<SheetIconUpdate>() != null)
            {
                button.GetComponent<SheetIconUpdate>().UpdateStatIcon();
            }
        }
    }
}
