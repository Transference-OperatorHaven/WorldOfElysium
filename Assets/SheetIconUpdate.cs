using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SheetIconUpdate : MonoBehaviour
{
    [SerializeField] int ID;
    Button statButton;
    [SerializeField] List<Texture2D> points;
    Player player;

    private void Start()
    {
        statButton = gameObject.GetComponent<Button>();
        player = FindFirstObjectByType<Player>();

        UpdateStatIcon();

    }

    public void UpdateStatIcon()
    {
        Texture2D pointTexture = points[player.stats.stats[ID].statLevel];
        Rect rec = new Rect(0, 0, pointTexture.width, pointTexture.height);
        statButton.image.sprite = Sprite.Create(pointTexture, rec, Vector2.zero, 1 );
    }
}
