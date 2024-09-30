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
    public ClassType classType;
    public int experience;
    public int level => this.experience % 1000;
    public Stats baseStats{
        get{
            this.baseStats.health = this.level * 2;
            this.baseStats.mana = this.level * 2;
            this.baseStats.attack = this.level * 2;
            this.baseStats.defense = this.level * 2;
            this.baseStats.speed = this.level * 2;
            this.baseStats.accuracy = this.level * 2;
            this.baseStats.criticalRate = this.level * 2;
            return this.baseStats;
        }
    }
    [HideInInspector] public Stats currentStats;
    public void ResetStats(){
        this.currentStats.health = this.baseStats.health;
        this.currentStats.mana = this.baseStats.mana;
        this.currentStats.attack = this.baseStats.attack;
        this.currentStats.defense = this.baseStats.defense;
        this.currentStats.speed = this.baseStats.speed;
        this.currentStats.accuracy = this.baseStats.accuracy;
        this.currentStats.criticalRate = this.baseStats.criticalRate;
    }
}
