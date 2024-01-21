using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Defaults", menuName = "Default Values", order = 2)]
public class Defaults : ScriptableObject
{
    public TMP_FontAsset font;
    [Header("Cursor")]
    public Texture2D cursor;
    public Texture2D hoverCursor;
    public Vector2 hotSpotFraction;
}
