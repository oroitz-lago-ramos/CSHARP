using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class Battle : MonoBehaviour{
	public static Battle main;
    public Script script;
	public Image playerImage;
	public Image opponentImage;
    [HideInInspector] public Bot opponentProfile;
    [HideInInspector] public Entity player;
    [HideInInspector] public bool opponentTurn;
    [HideInInspector] public bool choiceMade{get;set;}
    [HideInInspector] public bool over;
	[HideInInspector] public Bot opponent = new();
	public void Awake() {
		Battle.main = this;
		this.enabled = false;
    }
    public void OnEnable(){
        this.over = false;
		Team.main.members.ToList().ForEach(member => member.ResetStats());
		this.player = Team.main.members.First(x=>x.currentStats.health > 0);
		this.playerImage.sprite = this.player.battleSprite;
        this.opponentImage.sprite = this.opponentProfile.battleSprite;
		this.opponent.baseStats.health = this.opponentProfile.baseStats.health;
        this.opponent.baseStats.mana = this.opponentProfile.baseStats.mana;
        this.opponent.baseStats.attack = this.opponentProfile.baseStats.attack;
        this.opponent.baseStats.defense = this.opponentProfile.baseStats.defense;
        this.opponent.baseStats.speed = this.opponentProfile.baseStats.speed;
        this.opponent.baseStats.accuracy = this.opponentProfile.baseStats.accuracy;
		this.opponent.baseStats.criticalRate = this.opponentProfile.baseStats.criticalRate;
        this.opponent.ResetStats(true);
		this.script.content = new[]{this.opponentProfile.name + " wants to fight!"};
		this.script.enabled = true;
    }
	public void Update(){
		if(this.script.enabled || this.over){return;}
		if(this.opponent.currentStats.health <= 0){
			this.over = true;
			this.Victory();
			return;
		}
		if(this.player.currentStats.health <= 0){
            var defeated = (bool)Team.main?.members.All(x=>x.currentStats.health <= 0);
			if(defeated){
				this.over = true;
				this.Defeat();
			}
			//Force character change
        }
		if(this.opponentTurn){
			if(!this.opponent.thinking){
				var thinkMethods = new[]{"BotThinkEasy","BotThinkNormal","BotThinkHard"};
				this.Invoke(thinkMethods[(int)this.opponent.difficulty],this.opponent.thinkTime);
			}
			return;
		}
		if(!this.choiceMade){return;}
		this.choiceMade = false;
		this.opponentTurn = true;
	}
	public void Victory(){
		this.script.content = new[]{this.opponentProfile.name + " has been defeated!"};
		this.script.enabled = true;
	}
	public void Defeat(){
        this.script.content = new[]{"You have been defeated!"};
        this.script.enabled = true;
    }
	public void BotThinkEasy(){
		this.opponentTurn = false;
	}
	public void BotThinkNormal(){
		this.opponentTurn = false;
	}
	public void BotThinkHard(){
		this.opponentTurn = false;
	}
}