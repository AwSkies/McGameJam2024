using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlaySoundAction", menuName = "Action/Play Sound", order = 0)]
public class PlaySound : Action
{
    [SerializeField]
    AudioClip clip;
    [SerializeField]
    Vector2 source = Vector2.zero;
    [SerializeField]
    [Range(0f, 1f)]
    float volume = 1;
    public override void Perform()
    {
        AudioSource.PlayClipAtPoint(clip, source, volume);
    }
}
