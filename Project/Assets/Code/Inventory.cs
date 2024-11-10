using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    public static Inventory main;
    public Dictionary<string, int> items = new();
    public void Awake() => Inventory.main = this;
    public void SubtractItems(Item item)
    {
        if (!items.ContainsKey(item.name) || items[item.name] > item.price) { return; }

        items[item.name] -= item.price;
        if (items[item.name] <= 0) { items.Remove(item.name); }
    }
    public void AddItems(Item item)
    {
        if (items.ContainsKey(item.name))
        {
            items[item.name] += 1;
        }

        else
        {
            items.Add(item.name, 1);
        }
    }
}
