using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerInteractions : MonoBehaviour
{
    //water variables
    public InventoryManager inventoryManager;
    public Item waterItem;
    public TMP_Text waterItemCountText;
    public TMP_Text interactionPromptText;

    //dirt variables
    public Tilemap map;
    public TileBase hole;
    public MapManager mapManager;
    private Vector3Int digDirection = new Vector3Int(1, 0, 0); //so player digs on the space to their right
    public Item dirtItem;

    private void OnTriggerEnter2D(Collider2D collision) //checking if player hit water collider
    {
        Debug.Log("Entered trigger area");
        if (collision.CompareTag("WaterBody"))
        {
            interactionPromptText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) //checking when player leaves water collider
    {
        Debug.Log("Exited trigger area");
        if (collision.CompareTag("WaterBody"))
        {
            interactionPromptText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) //checks if player is still touching water and pressing e
    {
        if (collision.CompareTag("WaterBody"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //collect water
                inventoryManager.AddItem(waterItem, 1);

                // Update the TextMeshPro text component
                UpdateWaterItemCountText();

                Debug.Log("Collected 1 water item");
            }
        }
    }
    private void UpdateWaterItemCountText() //update the inventory water item count
    {
        int waterItemCount = inventoryManager.GetItemQuantity(waterItem);
        waterItemCountText.text = waterItemCount.ToString();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q)) 
        { 
            Vector2 playerPos = transform.position;

            Vector3Int gridPos = map.WorldToCell(playerPos) + digDirection;

            TileBase chosenTile = map.GetTile(gridPos);
            bool canDig = mapManager.GetCanDig(chosenTile);

            if (canDig)
            {
                map.SetTile(gridPos, hole);
                inventoryManager.AddItem(dirtItem, 1);
            }
        }
    }
}
