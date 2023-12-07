using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // Name of the item
    public Sprite itemIcon; // Icon for the inventory
    public int itemID; // Unique ID for the item

    // Function to execute when the item is picked up
    public void PickUp()
    {
        // Add the item to the inventory
        InventoryManager.instance.AddItem(this);
        // Hide the item in the scene
        gameObject.SetActive(false);
    }
}
