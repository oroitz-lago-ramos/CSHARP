using UnityEngine;

public class Music : MonoBehaviour
{
    public LayerMask characterLayer;
    public AudioSource audio;
    public AudioClip clip;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var layer = 1 << collision.gameObject.layer;
        if ((layer & this.characterLayer) != 0)
        {
            audio.clip = clip;
            audio.Play();
        }
        
    }
}