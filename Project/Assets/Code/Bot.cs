using UnityEngine;
public enum BotDifficulty{
    Easy,
    Normal,
    Hard
}
[System.Serializable]
public class Bot : Entity{
    public BotDifficulty difficulty;
    public float thinkTime;
	[HideInInspector] public float thinkEnd;
    [HideInInspector] public bool thinking{
		get => this.thinkEnd > Time.time + this.thinkTime;
		set{
			if(!value){return;}
			this.thinkEnd = Time.time + this.thinkTime;
		}
	}
}