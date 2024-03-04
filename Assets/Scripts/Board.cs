using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tilePrefab;
    private Background[,] alltiles;

    // Start is called before the first frame update
    void Start()
    {
        alltiles = new Background[width, height];
        SetupGrid();
    }

    private void SetupGrid()
    {
        for (int i = 0; i <= width; i++)
        {
            for (int j = 0; j <= height; j++)
            {
                Vector2 tilePosition = new Vector2(i, j);
                GameObject tile = Instantiate(tilePrefab, tilePosition,Quaternion.identity);
            }
        }
    }
}
