using UnityEngine;
using System.Linq;
public class Battle : MonoBehaviour{
    [HideInInspector] public Bot opponent;
    [HideInInspector] public Entity player;
    [HideInInspector] public bool opponentTurn;
    [HideInInspector] public bool choiceMade;
    [HideInInspector] public bool over;
	public void OnEnable(){
		this.opponent.ResetStats();
		Team.main?.members.ToList().ForEach(member => member.ResetStats());
		this.player = Team.main.members.First(x=>x.currentStats.health > 0);
		this.over = false;
	}
	public void Update(){
		if(this.over){return;}
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
	public void Victory(){}
	public void Defeat(){}
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