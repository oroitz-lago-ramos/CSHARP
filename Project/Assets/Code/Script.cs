using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class Script : MonoBehaviour{
    public GameObject textBox;
    public TMP_Text text;
    public float speed = 30f;
    public bool repeatable;
    public string[] content;
    public UnityEvent actions;
    [HideInInspector] public bool done;
    [HideInInspector] public int lineIndex;
    [HideInInspector] public int characterIndex;
    [HideInInspector] public float lastTick;
    [HideInInspector] public bool lineDone;
    public void OnEnable(){
        this.textBox.SetActive(true);
        this.lineIndex = 0;
        this.characterIndex = 0;
        this.text.text = "";
        this.done = false;
        this.lineDone = false;
        if(this.content.Length < 1 || this.content.Length == 1 && this.content[0].Length < 1){
            this.textBox.SetActive(false);
            this.enabled = false;
        }
    }
    public void Update(){
        var delay = 1 / this.speed;
        var keyPressed = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0);
        if(!this.lineDone && keyPressed){
            this.characterIndex = this.content[this.lineIndex].Length;
            this.text.text = this.content[this.lineIndex];
        }
        if(Time.time < this.lastTick + delay){return;}
        if(this.lineIndex >= this.content.Length - 1 && this.lineDone){
            this.done = true;
            if(keyPressed){
                this.textBox.SetActive(false);
                this.actions.Invoke();
                this.enabled = false;
            }
            return;
        }
        if(this.characterIndex >= this.content[this.lineIndex].Length){
            this.lineDone = true;
            if(keyPressed && this.lineIndex < this.content.Length){
                this.lineIndex += 1;
                this.characterIndex = 0;
                this.text.text = "";
                this.lineDone = false;
            }
            return;
        }
        this.text.text += this.content[this.lineIndex][this.characterIndex];
        this.characterIndex += 1;
        this.lastTick = Time.time;
    }
}
