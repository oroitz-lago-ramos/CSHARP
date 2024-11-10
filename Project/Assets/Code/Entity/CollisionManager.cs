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
            var itemType = collision.gameObject.tag;
            inventory.items[itemType] = inventory.items.ContainsKey(itemType) ? inventory.items[itemType] + 1 : 1;
            GameObject.Destroy(collision.gameObject);
        }
        if ((layer & this.dangerLayer) != 0 && Random.Range(0, 200) == 0 && !ViewController.onCombat)
        {
            ViewController.main.ToggleCombat();
            Battle.main.opponentProfile = Enemies.main.mobs[Random.Range(0,Enemies.main.mobs.Length - 1)];
            Battle.main.enabled = true;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        var layer = 1 << collision.gameObject.layer;
        if ((layer & this.dangerLayer) != 0 && Random.Range(0, 200) == 0 && !ViewController.onCombat)
        {
            ViewController.main.ToggleCombat();
            Battle.main.opponentProfile = Enemies.main.mobs[Random.Range(0,Enemies.main.mobs.Length - 1)];
            Battle.main.enabled = true;
        }
    }
}
