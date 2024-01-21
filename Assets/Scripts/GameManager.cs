using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_FontAsset defaultFont;
    [Header("Cursor")]
    public Texture2D defaultCursor;
    public Texture2D hoverCursor;
    public Vector2 cursorHotSpotFraction;

    // Start is called before the first frame update
    void Start()
    {
        // Screen.SetResolution(854, 480, true);
        Cursor.SetCursor(defaultCursor, GetCursorHotSpot(defaultCursor), CursorMode.Auto);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetCursorHotSpot(Texture2D texture)
    {
        return Vector2.Scale(new Vector2(texture.width, texture.height), cursorHotSpotFraction);
    }
}
