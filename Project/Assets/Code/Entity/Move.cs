using UnityEngine;
public class Move : MonoBehaviour{
    public Rigidbody2D rigidBody;
    public new AudioSource audio;
    public AudioClip footstepSound;
    public float speed = 10f;
    public void Start(){
        if(this.audio == null){return;}
        this.audio.clip = this.footstepSound;
    }
    public void FixedUpdate(){
        var movement = new Vector3();
        if(ViewController.currentMenu != ViewType.None || Script.active.Count > 0){
            this.rigidBody.linearVelocity = Vector2.zero;
            this.audio.Stop();
            return;
        }
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !ViewController.onCombat){movement += Vector3.up;}
        if((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !ViewController.onCombat) {movement += -Vector3.up;}
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !ViewController.onCombat) {movement += -Vector3.right;}
        if((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !ViewController.onCombat) {movement += Vector3.right;}
        this.rigidBody.linearVelocity = movement.normalized * this.speed * Time.fixedDeltaTime;
        if(this.audio == null){return;}
        if(this.rigidBody.linearVelocity == Vector2.zero){
            this.audio.Stop();
            return;
        }
        if(!this.audio.isPlaying){this.audio.Play();}
    }
}