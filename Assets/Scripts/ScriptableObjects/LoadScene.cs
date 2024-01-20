using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadSceneAction", menuName = "Actions/Load Scene", order = 0)]
public class LoadScene : Action
{
    [SerializeField]
    private string scene;

    public override void Perform()
    {
        SceneManager.LoadScene(scene);
    }
}
