using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "TextAction", menuName = "Text Action", order = 0)]
public class TextAction : ScriptableObject
{
    [Header("Text")]
    [TextArea(5, 20)]
    public string text = "...";
    public Color color = Color.white;
    public TMP_FontAsset font;
    [Min(0)]
    public float speed = 1f;
    [Header("Action")]
    public Action action;
    [Range(0f, 1f)]
    public float fraction = 0;

    public void PerformAction()
    {
        if (action != null)
        {
            action.Perform();
        }
    }
}
