using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Tilemap map;

    [SerializeField] private List<tileData> tileDataStore;

    private Dictionary<TileBase, tileData> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, tileData>();
        foreach (var tileData in tileDataStore)
        {
            foreach (var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }

    public bool GetCanDig(TileBase clickedTile)
    {
        bool canDig = dataFromTiles[clickedTile].canDig;
        return canDig;
    }
}
