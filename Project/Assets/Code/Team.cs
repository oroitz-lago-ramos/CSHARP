using System.Collections.Generic;
using UnityEngine;
public class Team : MonoBehaviour{
    public static Team main;
    public List<Entity> members;
    public void Awake() => Team.main = this;
    public void Update(){
        if(Input.GetKeyDown(KeyCode.C)){

        }
    }
}
