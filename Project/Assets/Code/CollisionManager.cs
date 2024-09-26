using UnityEngine;
public class CollisionManager : MonoBehaviour{
    public LayerMask itemsLayer;
    public LayerMask interactableLayer;
    public void OnTriggerEnter2D(Collider2D collision){
        var layer = 1 << collision.gameObject.layer;
        if((layer & this.itemsLayer) != 0){
            var inventory = this.GetComponent<Inventory>();
            var item = collision.gameObject.GetComponent<Item>();
            inventory.items[item] = inventory.items.ContainsKey(item) ? inventory.items[item] + 1 : 1;
            GameObject.Destroy(item.gameObject);
        }
    }
}
