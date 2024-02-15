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
				if(!dataFromTiles.ContainsKey(tile)){

                	dataFromTiles.Add(tile, tileData);

				}
            }
        }
    
	}
    public bool GetCanDig(TileBase clickedTile)
    {
        // Check if the clickedTile is not null and exists in the dictionary
        if (clickedTile != null && dataFromTiles.TryGetValue(clickedTile, out tileData tileData))
        {
            return tileData.canDig;
        }
        // If the tile is null or doesn't exist in the dictionary, return false
        return false;
    }
}
