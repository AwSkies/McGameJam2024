using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextButton : Action
{
    [SerializeField]
    private TextAction[] textActions;

    private TextManager textManager;

    // Start is called before the first frame update
    void Start()
    {
        textManager = FindObjectOfType<TextManager>();
    }
    
    public override void Perform()
    {
        textManager.Play(textActions);
    }
}
