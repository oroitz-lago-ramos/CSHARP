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
    [HideInInspector] public bool thinking;
}