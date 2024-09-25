using System;
using UnityEngine;
[Serializable]
public class Stats{
	public float health;
	public float mana;
	public float attack;
	public float defense;
	public float speed;
	public float accuracy;
	public float criticalRate;
}
public enum ClassType{
	NPC,
	Swordman,
	Archer,
	Mage
}
public class Entity : MonoBehaviour{
    public ClassType classType;
    public Stats baseStats;
	[HideInInspector] public Stats currentStats;
	public void OnEnable() => Team.main.members.Add(this);
	public void OnDisable() => Team.main.members.Remove(this);
}