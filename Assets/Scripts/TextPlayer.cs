using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextPlayer : MonoBehaviour
{
    private TMP_Text textObject;

    private Queue<TextAction> actions;
    private TextAction current;
    private int CharactersWritten 
    {
        get
        {
            return charactersWritten;
        }
        set
        {
            charactersWritten = value;
            if ((int) (current.fraction * current.text.Length) == charactersWritten)
            {
                current.action.Perform();
            }
        }
    }
    private int charactersWritten = 0;
    private int time;

    // Start is called before the first frame update
    void Start()
    {
        textObject = GetComponent<TMP_Text>();
    }

    void FixedUpdate()
    {
        if (current != null)
        {
            time++;
            if (time >= current.speed && CharactersWritten < current.text.Length)
            {
                time = 0;
                CharactersWritten++;
                textObject.text = current.text[..CharactersWritten];
            }
        }
    }

    void OnAdvance()
    {
        if (actions.Count != 0)
        {
            current = actions.Dequeue();
            time = 0;
            CharactersWritten = 0;
        }
        else
        {
            current = null;
        }
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
}
