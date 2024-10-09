using UnityEngine;
public enum ClassType{
    Knight,
    Archer,
    Mage
}
[System.Serializable]
public class Entity {
    public string name;
    public Sprite sprite;
    public Sprite battleSprite;
    public ClassType classType;
    public int experience;
    public int level;

    public Stats baseStats;

    [HideInInspector] public Stats currentStats;
}
