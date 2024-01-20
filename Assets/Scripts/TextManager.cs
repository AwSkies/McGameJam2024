using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class TextManager : MonoBehaviour
{
    private TMP_Text textObject;

    private Queue<TextAction> actions;
    private TextAction current;
    private int charactersWritten;
    private int time;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GetComponent<TMP_Text>();
    }

    void FixedUpdate()
    {
        time++;
        if (time >= current.speed && charactersWritten <= current.text.Length)
        {
            time = 0;
            if (CalculateFraction(charactersWritten, current) < current.fraction && CalculateFraction(charactersWritten + 1, current) >= current.fraction)
            {
                current.action.Perform();
            }
            charactersWritten++;
            textObject.text = current.text[..charactersWritten];
        }
    }

    void OnAdvance()
    {
        current = actions.Dequeue();
    }
    
    public void Play(TextAction[] textActions)
    {
        actions = new Queue<TextAction>(textActions);
        OnAdvance();
    }

    public void Play(TextAction textAction)
    {
        Play(new TextAction[] { textAction });
    }

    private float CalculateFraction(int characters, TextAction textAction)
    {
        return characters / (float) textAction.text.Length;
    }
}