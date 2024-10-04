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
    public void Use(ref float stat) => stat += this.value;
}
public class Items : MonoBehaviour{
    public static Items main;
    public Item[] list;
    public void Awake() => Items.main = this;
}