using UnityEngine;
public class Move : MonoBehaviour{
    public Rigidbody2D rigidBody;
    public float speed = 10f;
    public void FixedUpdate(){
        var movement = new Vector3();
        if(ViewController.currentMenu != ViewType.None || Script.active.Count > 0){return;}
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !ViewController.onCombat){movement += Vector3.up;}
        if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !ViewController.onCombat) {movement += -Vector3.up;}
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !ViewController.onCombat) {movement += -Vector3.right;}
        if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !ViewController.onCombat) {movement += Vector3.right;}
        this.rigidBody.linearVelocity = movement.normalized * this.speed * Time.fixedDeltaTime;
    }
}