using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerReaction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Defaults defaults;
    [SerializeField]
    private Texture2D hoverCursor;

    // Start is called before the first frame update
    void Start()
    {
        if (hoverCursor == null)
        {
            hoverCursor = defaults.hoverCursor;
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        Cursor.SetCursor(hoverCursor, GetCursorHotSpot(hoverCursor, defaults.hotSpotFraction), CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData data)
    {
        Cursor.SetCursor(defaults.cursor, GetCursorHotSpot(defaults.cursor, defaults.hotSpotFraction), CursorMode.Auto);
    }

    public static Vector2 GetCursorHotSpot(Texture2D texture, Vector2 hotSpotFraction)
    {
        return Vector2.Scale(new Vector2(texture.width, texture.height), hotSpotFraction);
    }
}
