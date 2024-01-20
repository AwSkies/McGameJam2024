using UnityEngine;

[CreateAssetMenu(fileName = "TextAction", menuName = "TextAction", order = 1)]
public class TextAction : ScriptableObject
{
    public string text = "...";
    public int speed = 2;
    public Action action;
    public float fraction = 0;
}