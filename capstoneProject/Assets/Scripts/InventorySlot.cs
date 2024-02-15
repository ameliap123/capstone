using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = Object.FindFirstObjectByType<InventoryManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();

        if (inventoryItem != null && inventoryItem.item.stackable && transform.childCount == 0)
        {
            inventoryItem.parentAfterDrag = transform;
            inventoryManager.AddItem(inventoryItem.item, 1);
        }
    }
}