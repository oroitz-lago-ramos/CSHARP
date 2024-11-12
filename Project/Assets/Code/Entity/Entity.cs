using System;
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
    public Stats baseStats = new Stats();
    /*[HideInInspector]*/ public Stats currentStats = new Stats();
	public void CheckLevel(){
		Func<bool> LeveledUp = ()=>this.experience >= 50 * this.level * this.level;
		while(LeveledUp()){
			this.baseStats.health += 10;
			this.baseStats.mana += 5;
			this.baseStats.attack += 1;
			this.baseStats.defense += 1;
			this.baseStats.speed += 1;
			this.baseStats.accuracy += 1;
			this.baseStats.criticalRate = Mathf.Clamp(this.baseStats.criticalRate + 2,0,100);
			this.baseStats.CopyTo(this.currentStats,false);
			this.level += 1;
		}
	}
}
