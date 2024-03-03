using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item waterItem;
    public TMP_Text waterItemCountText; // Reference to the TextMeshPro text component
    public TMP_Text interactionPromptText; // Reference to the TextMeshPro text component for interaction prompt

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered trigger area");
        if (collision.CompareTag("WaterBody"))
        {
            interactionPromptText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited trigger area");
        if (collision.CompareTag("WaterBody"))
        {
            interactionPromptText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
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
    private void UpdateWaterItemCountText()
    {
        int waterItemCount = inventoryManager.GetItemQuantity(waterItem);
        waterItemCountText.text = waterItemCount.ToString();
    }
}
