using UnityEngine;
using System.Linq;
public class Battle : MonoBehaviour{
    public Bot opponent;
    public bool opponentTurn;
    public bool choiceMade;
    public void OnEnable(){
        this.opponent.ResetStats();
        Team.main?.members.ToList().ForEach(member => member.ResetStats());
    }
    public void Update(){
        if(this.opponentTurn){
            if(!this.opponent.thinking){
                var thinkMethods = new[]{"BotThinkEasy","BotThinkNormal","BotThinkHard"};
                this.Invoke(thinkMethods[(int)this.opponent.difficulty],this.opponent.thinkTime);
            }
            return;
        }
        if(!this.choiceMade){return;}
        this.opponentTurn = true;
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