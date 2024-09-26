using UnityEngine;
[System.Serializable]
public class Entity{
    public string name;
    public Sprite sprite;
    public Stats baseStats;
    [HideInInspector] public Stats currentStats;
}
