using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayTextAction", menuName = "Actions/Play Text", order = 0)]
public class PlayText : Action
{
    [SerializeField]
    private TextAction[] textActions;
    
    public override void Perform()
    {
        FindObjectOfType<TextPlayer>().Play(textActions);
    }
}
