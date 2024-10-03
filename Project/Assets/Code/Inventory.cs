using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    public static Inventory main;
    public Dictionary<Item, int> items = new();

    private void Awake()
    {
        main = this;
    }

    public void OnItemUsed(Item item)
    {
        if (items[item] > 1)
        {
            items[item]--;
        }
        else
        {
            items.Remove(item);
        }
    }
}