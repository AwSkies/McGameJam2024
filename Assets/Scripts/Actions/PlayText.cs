using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayText : Action
{
    [SerializeField]
    private TextAction[] textActions;

    private TextPlayer textPlayer;

    // Start is called before the first frame update
    void Start()
    {
        textPlayer = FindObjectOfType<TextPlayer>();
    }
    
    public override void Perform()
    {
        textPlayer.Play(textActions);
    }
}
