using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class Script : MonoBehaviour{
    public Text textBox;
    public string[] text;
    public UnityEvent actions;
    public float speed = 10f;
    [HideInInspector] public int lineIndex;
    [HideInInspector] public int characterIndex;
    [HideInInspector] public float lastTick;
    public void OnEnable(){
        this.characterIndex = 0;
        this.lineIndex = 0;
        this.textBox.text = "";
    }
    public void Update(){
        var delay = 1 / this.speed;
        if(Time.time < this.lastTick + delay){return;}
        if(this.lineIndex >= this.text.Length){
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E)){
                this.actions.Invoke();
                this.enabled = false;
            }
            return;
        }
        this.characterIndex += 1;
        if(this.characterIndex >= this.text[this.lineIndex].Length) {
            this.lineIndex += 1;
            this.characterIndex = 0;
        }
        else{
            this.characterIndex += 1;
        }
        this.textBox.text += this.text[this.lineIndex][this.characterIndex];
        this.lastTick = Time.time;
    }
}
