using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DigManager : MonoBehaviour
{
    [SerializeField] private Tilemap map;
    [SerializeField] private TileBase hole;
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private Item dirtItem;
    [SerializeField] private MapManager mapManager;
	RaycastHit2D hit;


    public void replaceTile(Vector3Int position)
    {
        map.SetTile(position, hole);
        inventoryManager.AddItem(dirtItem, 1);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)){
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			hit = Physics2D.Raycast(mousePosition, Vector2.down);

			if (hit.collider != null)
            {
                Debug.Log("click on " + hit.collider.name);
				if (hit.collider.name == "WalkableGround"){
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
    }
}
