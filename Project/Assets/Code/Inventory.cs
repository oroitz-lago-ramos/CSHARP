using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour{
    public static Inventory main;
    public Dictionary<Item,int> items = new();

    private void Awake()
    {
        main = this;
    }
}