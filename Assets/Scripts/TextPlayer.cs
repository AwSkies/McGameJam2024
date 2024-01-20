using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextPlayer : MonoBehaviour
{
    private TMP_Text text;

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
            if (current != null && ActionCharacter() == charactersWritten)
            {
                current.PerformAction();
            }
        }
    }
    private int charactersWritten = 0;
    private int time;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
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
                text.text = current.text[..CharactersWritten];
            }
        }
    }

    void OnAdvanceText()
    {
        if (current != null)
        {
            if (CharactersWritten == current.text.Length)
            {
                if (actions.Count != 0)
                {
                    AdvanceText();
                }
                else
                {
                    current = null;
                }
            }
            else
            {
                if (CharactersWritten < ActionCharacter())
                {
                    current.PerformAction();
                }
                CharactersWritten = current.text.Length;
                text.text = current.text;
            }
            time = 0;
        }
    }

    public void Play(TextAction[] textActions)
    {
        actions = new Queue<TextAction>(textActions);
        AdvanceText();
    }

    public void Play(TextAction textAction)
    {
        Play(new TextAction[] { textAction });
    }

    private void AdvanceText()
    {
        current = actions.Dequeue();
        text.text = "";
        CharactersWritten = 0;
        text.font = current.font;
        text.color = current.color;
    }

    private int ActionCharacter()
    {
        return (int)(current.fraction * current.text.Length);
    }
}
