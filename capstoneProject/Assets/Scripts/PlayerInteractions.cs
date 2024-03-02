using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item waterItem;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterBody"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Collect water
                inventoryManager.AddItem(waterItem, 1);
            }
        }
    }
}
