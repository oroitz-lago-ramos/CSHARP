using System.Linq;
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
    public int price;
    public string description;
    public void Use(string tag) {
        var member = Team.main.members.First();
        if (tag == "HealthPotion")
        { member.currentStats.health = Mathf.Min(member.currentStats.health + value, member.baseStats.health); }
        else if (tag == "ManaPotion")
        {member.currentStats.mana = Mathf.Min(member.currentStats.mana + value, member.baseStats.mana);}
    }
}
public class Items : MonoBehaviour{
    public static Items main;
    public Item[] list;
	public Item this[ItemType itemType] => this.list[(int)itemType];
    public void Awake() => Items.main = this;
}