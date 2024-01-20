using UnityEngine;

[CreateAssetMenu(fileName = "TextAction", menuName = "Text Action", order = 0)]
public class TextAction : ScriptableObject
{
    [TextArea(5, 20)]
    public string text = "...";
    [Min(1)]
    public int speed = 2;
    public Action action;
    [Range(0f, 1f)]
    public float fraction = 0;
}
