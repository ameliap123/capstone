using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public InventoryManager inventoryManager;

    void Update()
    {
        // Detect 'Tab' key press to open/close inventory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }

        // Detect 'E' key press for interaction
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithObject();
        }
    }

    void ToggleInventory()
    {
        // Check if the inventory manager reference is set
        if (inventoryManager != null)
        {
            // Toggle the inventory UI (Will do this soon)
            Debug.Log("Inventory toggled.");
            // could use: inventoryManager.ToggleInventoryUI();
        }
    }

    void InteractWithObject()
    {
        // Handle interaction with objects (will do this soon)
        Debug.Log("Interacting with objects.");
        // could use: PerformRaycastForInteraction();
    }

    //not done yet but i way to view objects
    //void PerformRaycastForInteraction()
    //{
       // RaycastHit hit;
       // if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
       //{
            // Check if the hit object is interactable and perform the interaction
            //InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();
            //if (interactableObject != null)
            //{
                //interactableObject.Interact(); // Perform interaction with the object
            //}
        }
    }
}
