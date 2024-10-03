using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class Script : MonoBehaviour{
    public GameObject textBox;
    public TMP_Text text;
    public string[] content;
    public UnityEvent actions;
    public float speed = 10f;
    [HideInInspector] public int lineIndex;
    [HideInInspector] public int characterIndex;
    [HideInInspector] public float lastTick;
    public void OnEnable(){
        this.textBox.SetActive(true);
        this.characterIndex = 0;
        this.lineIndex = 0;
        this.text.text = "";
    }
    public void Update(){
        var delay = 1 / this.speed;
        if(Time.time < this.lastTick + delay){return;}
        if(this.lineIndex >= this.content.Length - 1){
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E)){
                this.actions.Invoke();
                this.enabled = false;
            }
            return;
        }
        this.characterIndex += 1;
        if(this.characterIndex >= this.content[this.lineIndex].Length - 1) {
            this.lineIndex += 1;
            this.characterIndex = 0;
        }
        else{
            this.characterIndex += 1;
        }
        this.text.text += this.content[this.lineIndex][this.characterIndex];
        this.lastTick = Time.time;
    }
}
