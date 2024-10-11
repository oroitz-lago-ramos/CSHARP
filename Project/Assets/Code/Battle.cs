using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;
public enum ActionType{
	None,
	Attack,
	ItemUse,
	TeamSwap,
}
public class Battle : MonoBehaviour{
	public static Battle main;
    public Script script;
	public Image playerImage;
	public Image opponentImage;
    public string opponentName
    {
        set
        {
			var bossFound = Enemies.main.bosses.FirstOrDefault(boss => boss.name == value);
            var mobFound = Enemies.main.mobs.FirstOrDefault(mob => mob.name == value);
            this.opponentProfile = bossFound ?? mobFound ?? this.opponentProfile;
        }
	}
    [HideInInspector] public Bot opponentProfile{get;set;}
    [HideInInspector] public Bot opponent = new();
    [HideInInspector] public Entity player{get;set;}
    [HideInInspector] public ActionType action{get;set;}
	[HideInInspector] public int currentAttack;
	[HideInInspector] public string currentItem;
    [HideInInspector] public bool opponentTurn;
    [HideInInspector] public bool over;
    [HideInInspector] public bool currentTurnEnded;
    public void Awake(){
		Battle.main = this;
		this.enabled = false;
    }
    public void OnEnable(){
        this.over = false;
		Team.main.members.ToList().ForEach(member => member.baseStats.CopyTo(member.currentStats,false));
		this.player = Team.main.members.First(x=>x.currentStats.health > 0);
		this.playerImage.sprite = this.player.battleSprite;
        this.opponentImage.sprite = this.opponentProfile.battleSprite;
		this.opponentProfile.baseStats.CopyTo(this.opponent.baseStats);
        this.opponent.baseStats.CopyTo(this.opponent.currentStats);
		this.script.content.Clear();
		this.script.content.Add($"{this.opponentProfile.name} wants to fight!");
		this.script.enabled = true;
    }
	public void Update(){
		this.currentTurnEnded = false;
		var user = this.opponentTurn ? this.opponent : this.player;
		if(this.script.enabled || this.over){return;}
		if(user.currentStats.health <= 0){
			if(!this.opponentTurn && Team.main.members.Any(x=>x.currentStats.health > 0)){
                //Force character change
				return;
			}
			Action End = this.opponentTurn ? this.Victory : this.Defeat;
			End();
            this.over = true;
            return;
		}
		if(this.opponentTurn){
			if(!this.opponent.thinking){
				var thinkMethods = new[]{"BotThinkEasy","BotThinkNormal","BotThinkHard"};
				this.Invoke(thinkMethods[(int)this.opponent.difficulty],this.opponent.thinkTime);
			}
			return;
		}
		if(this.action == ActionType.None){return;}
		if(this.action == ActionType.Attack){
			var classes = new[]{Skills.main.knight,Skills.main.archer,Skills.main.mage};
			var skill = classes[(int)user.classType][this.currentAttack];
			var other = user == this.player ? this.opponent : this.player;
			var target = skill.target == SkillTarget.Self ? user : other;
			if(user.level <= skill.minimumLevel){return;}
            this.script.content.Clear();
            this.script.content.Add($"{user.name} uses {skill.name}!");
            target.currentStats[skill.statTarget] += skill.value;
            user.currentStats[Stat.Mana] = Mathf.Max(0,user.currentStats[Stat.Mana] - skill.cost);
        }
		if(this.action == ActionType.ItemUse){
			if(this.currentItem == ""){return;}
			this.script.content.Clear();
			this.script.content.Add($"{user.name} uses {this.currentItem}!");
			this.script.enabled = true;
			this.currentItem = "";
		}
		if(this.action == ActionType.TeamSwap){
            this.script.content.Clear();
            this.script.content.Add($"{user.name} is taking over!");
			this.playerImage.sprite = this.player.battleSprite;
			this.script.enabled = true;
        }
		this.currentTurnEnded = true;
		this.action = ActionType.None;
		this.opponentTurn = !this.opponentTurn;
	}
	//================================
	// End
	//================================
	public void Victory(){
		this.script.content.Clear();
        this.script.content.Add($"{this.opponentProfile.name} has been defeated!");
		this.script.content.Add($"{this.player} gained {this.opponentProfile.experience} experience!");
		//Check level
		this.script.actions.RemoveAllListeners();
		this.script.actions.AddListener(()=>this.gameObject.SetActive(false));
		this.script.enabled = true;
	}
	public void Defeat(){
		this.script.content.Clear();
		this.script.content.Add("You have been defeated!");
		this.script.actions.RemoveAllListeners();
		this.script.actions.AddListener(()=>this.gameObject.SetActive(false));
        this.script.enabled = true;
    }
    //================================
    // Bot Logic
    //================================
    public void BotThinkEasy(){
		this.opponentTurn = false;
        this.action = ActionType.None;
    }
	public void BotThinkNormal(){
		this.opponentTurn = false;
        this.action = ActionType.None;
    }
	public void BotThinkHard(){
		this.opponentTurn = false;
        this.action = ActionType.None;
    }
}