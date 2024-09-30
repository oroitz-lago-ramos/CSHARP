using UnityEngine;
using System.Threading;

public class Warp : MonoBehaviour
{
    public LayerMask characterLayer;
    public Transform destination;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var layer = 1 << collision.gameObject.layer;
        if ((layer & this.characterLayer) == 0 || destination == null) { return; }
        collision.transform.position = destination.position;
    }
}