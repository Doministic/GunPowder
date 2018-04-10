using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSetup : MonoBehaviour
{
    public Transform tilePrefab;
    public int tileMapWidth;
    public int tileMapHeight;
    public Transform[,] tileMap;
    void Start()
    {
        transform.position = new Vector2 (tileMapWidth/-2,transform.position.y);

        tileMap = new Transform[tileMapWidth, tileMapHeight];
        for (int y = 0; y < tileMapHeight; y++)
        {
            for (int x = 0; x < tileMapWidth; x++)
            {
                Transform tile = Instantiate(tilePrefab);
                tile.transform.parent = transform;
                tile.transform.localPosition = new Vector3(x,y,0);
                tile.transform.rotation = Quaternion.identity;
                tileMap[x, y] = tile;
            }
        }
    }
}
