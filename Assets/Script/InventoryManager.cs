using UnityEngine;
using System.Collections.Generic;
using TMPro;

// Very small inventory manager for the assignment
public class InventoryManager : MonoBehaviour
{
    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    public TextMeshProUGUI inventoryUI;

    private static InventoryManager _instance;
    public static InventoryManager Instance => _instance;

    void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(gameObject);
        UpdateInventoryDisplay();
    }

    public void AddItem(string name, int qty = 1)
    {
        if (inventory.ContainsKey(name)) inventory[name] += qty;
        else inventory[name] = qty;
        UpdateInventoryDisplay();
    }

    public void RemoveItem(string name, int qty = 1)
    {
        if (!inventory.ContainsKey(name)) return;
        inventory[name] -= qty;
        if (inventory[name] <= 0) inventory.Remove(name);
        UpdateInventoryDisplay();
    }

    void UpdateInventoryDisplay()
    {
        if (inventoryUI == null) return;
        if (inventory.Count == 0) { inventoryUI.text = "Inventory: Empty"; return; }
        string s = "Inventory:\n";
        foreach (var kv in inventory) s += $"{kv.Key}: {kv.Value}\n";
        inventoryUI.text = s;
    }
}
