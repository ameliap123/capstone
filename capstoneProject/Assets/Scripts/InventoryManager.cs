using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> inventory = new List<Item>(); // List to store collected items

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add item to the inventory
    public void AddItem(Item item)
    {
        inventory.Add(item);
        // Futute, add further logic here, like UI updates, etc.
    }

    // Remove item from the inventory
    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
        // Future, add further logic here, like UI updates, etc.
    }
}
