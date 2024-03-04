using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public SpriteRenderer tile;
    public bool tilesPressed;
    public Color disabledColor;
    public Color enabledColor;
    public Transform myTransform;
    public bool longTile;
    // Start is called before the first frame update
    void Start()
    {
        tilesPressed = false;
    }


    void EnableTiles()
    {
        tile.color = enabledColor;
    }
    public void DisableTile()
    {
        if (tilesPressed)
            return;
        tilesPressed = true;

        tile.color = disabledColor;
    }

}
