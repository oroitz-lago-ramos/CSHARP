using UnityEngine;
public class Team : MonoBehaviour{
    public static Team main;
    public Entity[] members;
    public void Start() => Team.main = this;
}
