using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Cursor")]
    public Texture2D defaultCursor;
    public Texture2D hoverCursor;
    public Vector2 cursorHotSpotFraction;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(defaultCursor, GetCursorHotSpot(defaultCursor), CursorMode.Auto);
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetCursorHotSpot(Texture2D texture)
    {
        return Vector2.Scale(texture.Size(), cursorHotSpotFraction);
    }
}