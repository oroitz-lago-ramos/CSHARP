using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ChestContent {
    public string type;
    public int quantity;
}
public class Chest : MonoBehaviour{
    public List<ChestContent> content;
    public void OnEnable(){
        foreach(var content in this.content){
            var items = Inventory.main.items;
            items[content.type] = items.ContainsKey(content.type) ? items[content.type] + content.quantity : content.quantity;
        }
        GameObject.Destroy(this.gameObject);
    }
}
