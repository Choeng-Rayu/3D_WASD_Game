using UnityEngine;

// Pick up an item and add to inventory
public class PickupObject : InteractableObject
{
    public string itemName = "Item";
    public int quantity = 1;

    protected override void OnObjectInteracted()
    {
        InventoryManager im = FindObjectOfType<InventoryManager>();
        if (im != null)
        {
            im.AddItem(itemName, quantity);
            Debug.Log($"Picked up: {itemName} x{quantity}");
        }
        Destroy(gameObject);
    }
}
