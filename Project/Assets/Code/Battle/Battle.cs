using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityRandom = UnityEngine.Random;
public enum ActionType{
	None,
	Attack,
	ItemUse,
	TeamSwap,
}
public class Battle : MonoBehaviour{
	public static Battle main;
	public static float[,] weaknessMatrix = {
		//Knight Archer Mage
		{1.0f,   2.0f,  0.5f}, //Knight
		{0.5f,   1.0f,  2.0f}, //Archer
		{2.0f,   0.5f,  1.0f}  //Mage
	};
	public Script script;
	public Image playerImage;
	public Image opponentImage;
    public string opponentName{
        set{
			var bossFound = Enemies.main.bosses.FirstOrDefault(boss => boss.name == value);
            var mobFound = Enemies.main.mobs.FirstOrDefault(mob => mob.name == value);
            this.opponentProfile = bossFound ?? mobFound ?? this.opponentProfile;
        }
	}
    /*[HideInInspector]*/ public Bot opponentProfile{get;set;}
    /*[HideInInspector]*/ public Bot opponent = new();
    /*[HideInInspector]*/ public Entity player{get;set;}
    /*[HideInInspector]*/ public ActionType action;
	/*[HideInInspector]*/ public int currentAttack;
	/*[HideInInspector]*/ public string currentItem;
    /*[HideInInspector]*/ public bool opponentTurn;
    /*[HideInInspector]*/ public bool over;
	/*[HideInInspector]*/ public bool currentTurnEnded;
    public void Awake(){
		Battle.main = this;
		this.enabled = false;
    }
    public void OnEnable(){
        this.over = false;
		Team.main.members.ToList().ForEach(member => member.baseStats.CopyTo(member.currentStats,false));
		this.player = Team.main.members.First(x=>x.currentStats.health > 0);
		this.LoadProfile(this.player,this.player,true);
		this.LoadProfile(this.opponentProfile,this.opponent,false);
		this.script.Set($"{this.opponentProfile.name} wants to fight!");
		this.action = ActionType.None;
		this.currentAttack = 0;
		this.currentItem = "";
    }
	public void LoadProfile(Entity from,Entity to,bool isPlayer){
		var image = isPlayer ? this.playerImage : this.opponentImage;
		image.sprite = isPlayer ? this.player.battleSprite : this.opponentProfile.battleSprite;
		to.name = from.name;
		from.baseStats.CopyTo(to.baseStats).CopyTo(to.currentStats);
	}
	public void Update(){
		var user = this.opponentTurn ? this.opponent : this.player;
		var opponentThinking = this.opponentTurn && this.opponent.thinking;
		if(this.script.enabled || this.over || opponentThinking){return;}
		if(user.currentStats.health <= 0){
			if(!this.opponentTurn){
				var firstAlive = Team.main.members.FirstOrDefault(x=>x.currentStats.health > 0);
				Team.main.Swap(Array.IndexOf(Team.main.members,firstAlive));
				this.script.Set($"{this.player.name} has been defeated!");
				if(firstAlive != null){
					this.player = firstAlive;
					this.LoadProfile(this.player,this.player,true);
					this.script.content.Add($"{this.player.name} is taking over!");
					return;
				}
			}
			Action End = this.opponentTurn ? this.Victory : this.Defeat;
			End();
            this.over = true;
            return;
		}
		if(this.opponentTurn && !this.opponent.thinking){
			var thinkMethods = new Action[]{this.BotThinkEasy,this.BotThinkNormal,this.BotThinkHard};
			thinkMethods[(int)this.opponent.difficulty]();
		}
		if(this.action == ActionType.None){return;}
		if(this.action == ActionType.Attack){
			var skill = Skills.main[user.classType][this.currentAttack];
			var other = user == this.player ? this.opponent : this.player;
			var target = skill.target == SkillTarget.Self ? user : other;
			if(user.level < skill.minimumLevel){
				this.EndTurn();
				return;
			}
			this.script.Set($"{user.name} uses {skill.name}!");
			var damage = skill.value * Battle.weaknessMatrix[(int)user.classType,(int)other.classType];
            target.currentStats[skill.statTarget] = Mathf.Clamp(target.currentStats[skill.statTarget] + skill.value,0,target.baseStats[skill.statTarget]);
			user.currentStats[Stat.Mana] = Mathf.Max(0,user.currentStats[Stat.Mana] - skill.cost);
        }
		if(this.action == ActionType.ItemUse){
			if(this.currentItem == ""){
				this.EndTurn();
				return;
			}
			this.script.Set($"{user.name} uses {this.currentItem}!");
			this.currentItem = "";
		}
		if(this.action == ActionType.TeamSwap){
			this.script.Set($"{user.name} is taking over!");
			this.LoadProfile(this.player,this.player,true);
        }
		this.EndTurn();
	}
	public void EndTurn(){
		this.action = ActionType.None;
		this.opponentTurn = !this.opponentTurn;
		this.opponent.thinking = this.opponentTurn;
	}
	//================================
	// End
	//================================
	public void Victory(){
		var actions = new UnityAction(()=>this.gameObject.SetActive(false));
		actions += ()=>this.enabled = false;
		actions += ()=>ViewController.main.ToggleCombat();
		var text = new List<string>{$"{this.opponentProfile.name} has been defeated!",$"{this.player.name} gained {this.opponentProfile.experience} experience!"};
		var currentLevel = this.player.level;
		this.player.experience += this.opponentProfile.experience;
		this.player.level = this.player.experience == 0 ? 1 : this.player.experience % (50 * this.player.level + 1);
		this.player.level = Mathf.Max(1,this.player.level);
		if(this.player.level != currentLevel){
			text.Add($"{this.player.name} reached level {this.player.level}!");
		}
		this.script.Set(text.ToArray(),actions);
	}
	public void Defeat(){
		var actions = new UnityAction(()=>this.gameObject.SetActive(false));
		actions += ()=>this.enabled = false;
		actions += ()=>ViewController.main.ToggleCombat();
		this.script.Set("Your team has been defeated!",actions);
    }
    //================================
    // Bot Logic
    //================================
    public void BotThinkEasy(){
		this.currentAttack = 0;
		this.action = ActionType.Attack;
    }
	public void BotThinkNormal(){
		var maxSkill = 1;
		var skills = Skills.main[this.opponent.classType];
		this.currentAttack = UnityRandom.Range(0,maxSkill);
		this.currentAttack = this.opponent.currentStats.mana < skills[this.currentAttack].cost ? 0 : this.currentAttack;  
		this.action = ActionType.Attack;
    }
	public void BotThinkHard(){
		var range = 10.0f;
		var random = UnityRandom.Range(1.0f,range);
		var changingClass = random > range * 0.75f;
		var useItem = random > range * 0.9f;
		if(changingClass){
			this.opponent.classType = (ClassType)UnityRandom.Range(0,2);
			this.script.Set($"{this.opponent.name} changed to {this.opponent.classType}");
			this.EndTurn();
			return;
		}
		if(useItem){
			var item = UnityRandom.Range(0,1) > 0 ? ItemType.HealthPotion : ItemType.ManaPotion;
			this.action = ActionType.ItemUse;
			this.currentItem = item.ToString();
			return;
		}
		var maxSkill = 2;
		var skills = Skills.main[this.opponent.classType];
		this.currentAttack = UnityRandom.Range(0,maxSkill);
		this.currentAttack = this.opponent.currentStats.mana < skills[this.currentAttack].cost ? 0 : this.currentAttack;
		this.action = ActionType.Attack;
    }
}