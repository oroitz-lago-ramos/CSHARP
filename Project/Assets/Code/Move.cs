using UnityEngine;
public class Move : MonoBehaviour{
    public Rigidbody2D rigidBody;
    public float speed = 10f;
    public void FixedUpdate(){
        var movement = new Vector3();
        if(Input.GetKey(KeyCode.W)){movement += Vector3.up;}
        if(Input.GetKey(KeyCode.S)){movement += -Vector3.up;}
        if(Input.GetKey(KeyCode.A)){movement += -Vector3.right;}
        if(Input.GetKey(KeyCode.D)){movement += Vector3.right;}
        this.rigidBody.linearVelocity = movement.normalized * this.speed * Time.fixedDeltaTime;
    }
}