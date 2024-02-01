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
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition);
            bool canDig = dataFromTiles[clickedTile].canDig;
        }
    }
}
