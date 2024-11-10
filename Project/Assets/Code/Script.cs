using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Script : MonoBehaviour
{
    public GameObject textBox;
    public TMP_Text text;
    public float speed = 30f;
    public bool repeatable;
    public List<string> content;
    public UnityEvent actions;  
    public bool done;
    public int lineIndex;
    public int characterIndex;
    public float lastTick;
    public bool lineDone;

    public void OnEnable()
    {
        textBox.SetActive(true);
        lineIndex = 0;
        characterIndex = 0;
        text.text = "";
        done = false;
        lineDone = false;

        if (content.Count < 1 || (content.Count == 1 && content[0].Length < 1))
        {
            textBox.SetActive(false);
            enabled = false;
        }
    }

    public void Update()
    {
        var delay = 1 / speed;
        var keyPressed = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0);

        if (!lineDone && keyPressed)
        {
            characterIndex = content[lineIndex].Length;
            text.text = content[lineIndex];
        }

        if (Time.time < lastTick + delay) return;

        if (lineIndex >= content.Count - 1 && lineDone)
        {
            done = true;
            if (keyPressed)
            {
                textBox.SetActive(false);
                actions.Invoke();  
                enabled = false;
            }
            return;
        }

        if (characterIndex >= content[lineIndex].Length)
        {
            lineDone = true;
            if (keyPressed && lineIndex < content.Count)
            {
                lineIndex += 1;
                characterIndex = 0;
                text.text = "";
                lineDone = false;
            }
            return;
        }

        text.text += content[lineIndex][characterIndex];
        characterIndex += 1;
        lastTick = Time.time;
    }
}
