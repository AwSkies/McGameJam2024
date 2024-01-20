using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : Action
{
    [SerializeField]
    private string scene;

    public override void Perform()
    {
        SceneManager.LoadScene(scene);
    }
}
