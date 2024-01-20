using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextPlayer : MonoBehaviour
{
    private TMP_Text textObject;

    private Queue<TextAction> actions = new();
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
            if (current != null && current.action != null && ActionCharacter() == charactersWritten)
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

    void OnAdvanceText()
    {
        if (current != null){
            if (CharactersWritten == current.text.Length)
            {
                if (actions.Count != 0)
                {
                    current = actions.Dequeue();
                    CharactersWritten = 0;
                }
                else
                {
                    current = null;
                }
            }
            else
            {
                if (CharactersWritten < ActionCharacter() && current.action != null)
                {
                    current.action.Perform();
                }
                CharactersWritten = current.text.Length;
                textObject.text = current.text;
            }
            time = 0;
        }
    }
    
    public void Play(TextAction[] textActions)
    {
        actions = new Queue<TextAction>(textActions);
        current = actions.Dequeue();
        CharactersWritten = 0;
    }

    public void Play(TextAction textAction)
    {
        Play(new TextAction[] { textAction });
    }

    private int ActionCharacter()
    {
        return (int) (current.fraction * current.text.Length);
    }
}
