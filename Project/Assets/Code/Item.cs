using UnityEngine;
public class Item : MonoBehaviour
{
    public Sprite sprite;
    public float value;
    public string description;
    public void Use(ref float stat) => stat += this.value;
}