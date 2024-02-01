using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DigManager : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private TileBase hole;
	[SerializeField] private MapManager mapManager;

    public void replaceTile(Vector3Int position)
    {
        map.SetTile(position, hole);
    }

    public void Dig()
    {
        
    }
}
