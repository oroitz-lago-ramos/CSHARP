using UnityEngine;

public class Music : MonoBehaviour
{
    public LayerMask characterLayer;
    public AudioSource source;
    public AudioClip clip;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var layer = 1 << collision.gameObject.layer;
        if ((layer & this.characterLayer) != 0)
        {
            source.clip = clip;
            source.Play();
        }
        
    }
}