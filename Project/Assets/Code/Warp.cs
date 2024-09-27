using UnityEngine;
using System.Threading;

public class Warp : MonoBehaviour
{
    public LayerMask characterLayer;
    private int triggerCounter = 0;  // Compteur pour suivre les appels

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 newLocation = new Vector3(80, -40);
        var layer = 1 << collision.gameObject.layer;

        if ((layer & this.characterLayer) != 0)
        {
            collision.transform.position = newLocation;

            triggerCounter++;  // Incrémenter le compteur à chaque appel

            // Si le compteur est pair (donc chaque 2e appel)
            if (triggerCounter % 2 == 0)
            {
                collision.transform.position = new Vector3(-7, -11);
            }
        }
    }
}
