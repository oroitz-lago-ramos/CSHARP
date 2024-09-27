using UnityEngine;

public class CollisionManager : MonoBehaviour{
    public LayerMask itemsLayer;
    public LayerMask interactableLayer;
    public LayerMask dangerLayer;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var layer = 1 << collision.gameObject.layer;
        if ((layer & this.itemsLayer) != 0)
        {
            var inventory = this.GetComponent<Inventory>();
            var item = collision.gameObject.GetComponent<Item>();
            inventory.items[item] = inventory.items.ContainsKey(item) ? inventory.items[item] + 1 : 1;
            GameObject.Destroy(item.gameObject);
        }
        if ((layer & this.dangerLayer) != 0 && Random.Range(0, 50) == 0)
        {
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        var layer = 1 << collision.gameObject.layer;
        if ((layer & this.dangerLayer) != 0 && Random.Range(0, 50) == 0)
        {
        }
    }
}
