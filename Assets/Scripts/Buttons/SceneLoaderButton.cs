using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderButton : Action
{
    [SerializeField]
    private Scene scene;

    public override void Perform()
    {
        SceneManager.LoadScene(scene.buildIndex);
    }
}
