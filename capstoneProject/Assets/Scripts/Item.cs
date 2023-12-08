using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item"; // Name of the item
    public Sprite icon; // Icon for the inventory
    public int quantity =1;

    public virtual void Use()
    {
        Debug.Log("Using " + itemName); 
    }
}
