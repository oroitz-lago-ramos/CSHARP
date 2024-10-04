using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour{
    public static Inventory main;
    public Dictionary<string,int> items = new();
    public void Awake() => Inventory.main = this;
}