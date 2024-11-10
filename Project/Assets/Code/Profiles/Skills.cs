using UnityEngine;
public enum SkillTarget{
    Self,
    Opponent
}
[System.Serializable]
public class Skill{
    public string name;
    public string animation;
    public AudioClip voice;
    public AudioClip sound;
    public bool isActive;
    public float value;
    public int duration;
    public int cooldown;
    public int minimumLevel;
    public float cost;
    public SkillTarget target;
    public Stat statTarget;
}
public class Skills : MonoBehaviour{
    public static Skills main;
    public Skill[] knight;
    public Skill[] archer;
    public Skill[] mage;
	public Skill[] this[ClassType classType] => new Skill[][]{this.knight,this.archer,this.mage}[(int)classType];
    public void Awake() => Skills.main = this;
}