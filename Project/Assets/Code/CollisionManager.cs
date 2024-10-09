using UnityEngine;

public class CollisionManager : MonoBehaviour{
    public ViewController viewController;

    public LayerMask itemsLayer;
    public LayerMask interactableLayer;
    public LayerMask dangerLayer;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var layer = 1 << collision.gameObject.layer;
        if ((layer & this.itemsLayer) != 0)
        {
            var inventory = this.GetComponent<Inventory>();
            var itemType = collision.gameObject.tag;
            inventory.items[itemType] = inventory.items.ContainsKey(itemType) ? inventory.items[itemType] + 1 : 1;
            GameObject.Destroy(collision.gameObject);
        }
        if ((layer & this.dangerLayer) != 0 && Random.Range(0, 50) == 0)
        {
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        var layer = 1 << collision.gameObject.layer;
        if ((layer & this.dangerLayer) != 0 && Random.Range(0, 200) == 0 && !ViewController.onCombat)
        {
            viewController.ToggleCombat();
        }
    }
}
