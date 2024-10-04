using UnityEngine;
public enum ItemType{
    HealthPotion,
    ManaPotion,
    Money
}
[System.Serializable]
public class Item{
    public string name;
    public Sprite sprite;
    public float value;
    public string description;
    public void Use(string tag) {
        if (tag == "HealthPotion")
        { }
        else if (tag == "ManaPotion")
            { }
        else if (tag == "Money")
            { }
    }
}
public class Items : MonoBehaviour{
    public static Items main;
    public Item[] list;
    public void Awake() => Items.main = this;
}