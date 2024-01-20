using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderButton : Button
{
    [SerializeField]
    private string scene;

    public override void Activate()
    {
        SceneManager.LoadScene(scene);
    }
}
