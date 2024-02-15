using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Dictionary<Item, int> inventory = new Dictionary<Item, int>();

    // Add item to the inventory
    public void AddItem(Item item, int quantity)
    {
        if (inventory.ContainsKey(item))
            inventory[item] += quantity;
        else
            inventory[item] = quantity;

        // Update UI or perform any other necessary actions
        Debug.Log(item.name + " added to inventory. Total: " + inventory[item]);
    }

    // Remove item from the inventory
    public void RemoveItem(Item item, int quantity)
    {
        if (inventory.ContainsKey(item))
        {
            inventory[item] -= quantity;

            if (inventory[item] <= 0)
                inventory.Remove(item);

            // Update UI or perform any other necessary actions
            Debug.Log(quantity + " " + item.name + "(s) removed from inventory.");
        }
        else
        {
            Debug.LogWarning("Item not found in inventory: " + item.name);
        }
    }
}

