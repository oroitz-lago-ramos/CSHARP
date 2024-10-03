using UnityEngine;
public class Interact : MonoBehaviour{
    public new Collider2D collider;
    public LayerMask interactsWith;
    [HideInInspector] public bool pressed;
    public void FixedUpdate(){
        if(!this.pressed){return;}
        this.pressed = false;
        var bounds = this.collider.bounds;
        bounds.min -= Vector3.up * bounds.min.y * 2;
        bounds.max += Vector3.up * bounds.max.y * 2;
        var results = Physics2D.OverlapArea(bounds.min,bounds.max,this.interactsWith);
        if(results != null){
            var script = results.gameObject.GetComponent<Script>();
            if(script != null){script.enabled = true;}
            return;
        }
        bounds = this.collider.bounds;
        bounds.min -= Vector3.right * bounds.min.x * 2;
        bounds.max += Vector3.right * bounds.max.x * 2;
        results = Physics2D.OverlapArea(bounds.min,bounds.max,this.interactsWith);
        if(results != null){
            var script = results.gameObject.GetComponent<Script>();
            if(script != null){script.enabled = true;}
        }
    }
    public void Update(){
        if(!Input.GetKeyDown(KeyCode.E)){return;}
        this.pressed = true;
    }
}
