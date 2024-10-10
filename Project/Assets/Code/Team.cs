using System.Linq;
using UnityEngine;
public class Team : MonoBehaviour{
    public static Team main;
    public Entity[] members;
    public void Awake(){
        Team.main = this;
        this.members.ToList().ForEach(x=>x.baseStats.CopyTo(x.currentStats));
    }
    public void Swap(int index){
        if(index >= members.Length){return;}
        (this.members[index],this.members[0]) = (this.members[0],this.members[index]);
    }
}
