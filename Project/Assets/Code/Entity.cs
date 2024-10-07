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
    public void ResetStats(){
        this.currentStats.attack = this.baseStats.attack;
        this.currentStats.defense = this.baseStats.defense;
        this.currentStats.speed = this.baseStats.speed;
        this.currentStats.accuracy = this.baseStats.accuracy;
        this.currentStats.criticalRate = this.baseStats.criticalRate;
    }
}
