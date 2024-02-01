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

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)){
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition);
			bool canDig = mapManager.GetCanDig(clickedTile);
			if (canDig is true)
			{
				replaceTile(gridPosition);
			}
		}
    }
}
