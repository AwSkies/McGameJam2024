using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Defaults defaults;

    // Start is called before the first frame update
    void Start()
    {
        // Screen.SetResolution(854, 480, true);
        Cursor.SetCursor(defaults.cursor, PointerReaction.GetCursorHotSpot(defaults.cursor, defaults.hotSpotFraction), CursorMode.Auto);
        DontDestroyOnLoad(gameObject);
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
