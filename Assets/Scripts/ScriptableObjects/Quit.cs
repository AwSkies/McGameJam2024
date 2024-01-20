using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuitAction", menuName = "Action/Quit", order = 5)]
public class Quit : Action
{
    [SerializeField]
    private int exitCode;

    public override void Perform()
    {
        Application.Quit(exitCode);
    }
}
