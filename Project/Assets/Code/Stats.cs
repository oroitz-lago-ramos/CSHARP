using UnityEngine;
public enum Stat{
    Health,
    Mana,
    Attack,
    Defense,
    Speed,
    Accuracy,
    CriticalRate
}
[System.Serializable]
public class Stats{
    public float health;
    public float mana;
    public float attack;
    public float defense;
    public float speed;
    public float accuracy;
    [Range(0,100)] public float criticalRate;
    public Stats CopyTo(Stats other,bool full=true){
        if(full){
            other.health = this.health;
            other.mana = this.mana;
        }
        other.attack = this.attack;
        other.defense = this.defense;
        other.speed = this.speed;
        other.accuracy = this.accuracy;
        other.criticalRate = this.criticalRate;
		return other;
    }
    public float this[Stat stat]{
        get{
            var stats = new[]{this.health,this.mana,this.attack,this.defense,this.speed,this.accuracy,this.criticalRate};
            return (int)stat < 0 || (int)stat >= stats.Length ? 0 : stats[(int)stat];
		}
		set{
            var stats = new[]{this.health,this.mana,this.attack,this.defense,this.speed,this.accuracy,this.criticalRate};
            if((int)stat < 0 || (int)stat >= stats.Length){return;}
			if(stat is Stat.Health){this.health = value;}
			if(stat is Stat.Mana){this.mana = value;}
			if(stat is Stat.Attack){this.attack = value;}
			if(stat is Stat.Defense){this.defense = value;}
			if(stat is Stat.Speed){this.speed = value;}
			if(stat is Stat.Accuracy){this.accuracy = value;}
			if(stat is Stat.CriticalRate){this.criticalRate = value;}
        }
    }
}