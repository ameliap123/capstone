using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWater : MonoBehaviour
{
    //private bool pickUpAllowed;
    public InventoryManager inventoryManager;
    public Item waterItem;

    /* Update is called once per frame
    private void Update()
    {
        if (!pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            pickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pickUpAllowed = true; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pickUpAllowed = false;
    }*/

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
