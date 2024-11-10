using UnityEngine;
public class Interact : MonoBehaviour{
	public new Collider2D collider;
	public LayerMask interactsWith;
	[HideInInspector] public bool pressed;
	public void FixedUpdate(){
		if(!this.pressed){return;}
		this.pressed = false;
		var bounds = this.collider.bounds;
		Physics2D.OverlapArea(bounds.min,bounds.max,this.interactsWith);
		if(CheckAxis(Vector3.right * bounds.extents.x)){return;}
		CheckAxis(Vector3.up * bounds.extents.y * 2);
	}
	public bool CheckAxis(Vector3 directionalExtent){
		var bounds = this.collider.bounds;
		bounds.min -= directionalExtent;
		bounds.max += directionalExtent;
		var results = Physics2D.OverlapArea(bounds.min,bounds.max,this.interactsWith);
		if(results == null){return false;}
		var script = results.gameObject.GetComponent<Script>();
		if(script == null || !script.repeatable && script.done){return false;}
		script.enabled = true;
		return true;
	}
	public void Update(){
		if(ViewController.currentMenu != ViewType.None){return;}
		if (!Input.GetKeyDown(KeyCode.E)){return;}
		this.pressed = true;
	}
}
