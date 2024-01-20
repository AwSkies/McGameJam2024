using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Texture2D hoverCursor;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (hoverCursor == null)
        {
            hoverCursor = gameManager.hoverCursor;
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        Cursor.SetCursor(hoverCursor, gameManager.GetCursorHotSpot(hoverCursor), CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData data)
    {
        Cursor.SetCursor(gameManager.defaultCursor, gameManager.GetCursorHotSpot(gameManager.defaultCursor), CursorMode.Auto);
    }
}
