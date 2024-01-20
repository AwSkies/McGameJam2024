using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : Action
{
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    Vector2 source = Vector2.zero;
    [SerializeField]
    float volume = 1;
    public override void Perform()
    {
        AudioSource.PlayClipAtPoint(clip, source, volume);
    }
}
