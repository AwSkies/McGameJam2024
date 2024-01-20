using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextPlayer : MonoBehaviour
{
    private GameManager gameManager;
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
            if (current != null && charactersWritten < ActionCharacter() && ActionCharacter() <= value)
            {
                current.PerformAction();
            }
            charactersWritten = value;
        }
    }
    private int charactersWritten = 0;
    private int time;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        text = GetComponent<TMP_Text>();
    }

    void FixedUpdate()
    {
        if (current != null)
        {
            time++;
            CharactersWritten = Math.Clamp((int) (current.speed * time), 0, current.text.Length);
            text.text = current.text[..CharactersWritten];
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
                CharactersWritten = current.text.Length;
                time = (int) (current.text.Length / current.speed) + 1;
            }
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
        time = 0;
        charactersWritten = -1;
        CharactersWritten = 0;
        text.font = current.font != null ? current.font : gameManager.defaultFont;
        text.color = current.color;
    }

    private int ActionCharacter()
    {
        return (int)(current.fraction * current.text.Length);
    }
}
