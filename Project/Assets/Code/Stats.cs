using UnityEngine;
[System.Serializable]
public class Stats{
    public float health;
    public float mana;
    public float attack;
    public float defense;
    public float speed;
    public float accuracy;
    [Range(0,100)] public float criticalRate;
}