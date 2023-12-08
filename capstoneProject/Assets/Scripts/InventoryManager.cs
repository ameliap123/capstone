using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int inventorySpace = 20; // Maximum inventory slots
    public List<Item> items = new List<Item>(); // List to store items

    // Add an item to the inventory
    public bool AddItem(Item itemToAdd)
    {
        if (items.Count < inventorySpace)
        {
            items.Add(itemToAdd);
            Debug.Log(itemToAdd.itemName + " added to inventory.");
            return true;
        }
        else
        {
            Debug.Log("Inventory is full. Cannot add " + itemToAdd.itemName);
            return false;
        }
    }

    // Remove an item from the inventory
    public void RemoveItem(Item itemToRemove)
    {
        if (items.Contains(itemToRemove))
        {
            items.Remove(itemToRemove);
            Debug.Log(itemToRemove.itemName + " removed from inventory.");
        }
        else
        {
            Debug.Log("Item " + itemToRemove.itemName + " not found in inventory.");
        }
    }

    // Check if the inventory contains a specific item
    public bool HasItem(Item itemToCheck)
    {
        return items.Contains(itemToCheck);
    }
}
