using UnityEngine;

public class WaterStep : MonoBehaviour
{
    public new AudioSource audio;
    public LayerMask characterLayer;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var layer = 1 << collision.gameObject.layer;
        if ((layer & this.characterLayer) != 0)
        {
            audio.Play();
        }
    }
}
