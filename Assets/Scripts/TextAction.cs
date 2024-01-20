using UnityEngine;

[CreateAssetMenu(fileName = "TextAction", menuName = "TextAction", order = 0)]
public class TextAction : ScriptableObject
{
    public string text = "...";
    [Min(1)]
    public int speed = 2;
    public Action action;
    [Range(0f, 1f)]
    public float fraction = 0;
}
