using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public int price;
    public enum ItemType
    {
        HealthPotion,
        ManaPotion,
        Money
    };
    public ItemType type;

    void Start()
    {

    }

    void Update()
    {

    }

    public void BuyItem()
    {
        if (Inventory.main.items.ContainsKey("Money") && Inventory.main.items["Money"] >= price)
        {

            Inventory.main.items["Money"] -= price;
            Inventory.main.AddItems(new Item { name = type.ToString(), price = price });
            if (Inventory.main.items["Money"] == 0) {
                Inventory.main.items.Remove("Money");
            }
            Debug.Log($"Achat réussi : {type} pour {price} pièces.");
        }
        else
        {
            Debug.Log("BOUHHHH SALE GUEUX");
        }
    }
}