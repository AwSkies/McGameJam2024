using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Room : MonoBehaviour
{
    [SerializeField]
    [Min(0)]
    private float panAreaWidth;
    [SerializeField]
    [Range(0f, 0.01f)]
    private float panSpeed;

    [SerializeField]
    private Transform room;
    private Transform room1;
    private Transform room2;
    private Transform[] rooms;

    private float width;

    // Start is called before the first frame update
    void Start()
    {
        width = room.GetComponent<SpriteRenderer>().sprite.rect.size.x / room.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        room1 = room;
        room2 = Instantiate(room.gameObject, room.position + width * Vector3.right, Quaternion.identity, transform).transform;
        rooms = new Transform[] { room1, room2 };
    }

    void FixedUpdate()
    {
        float mousePosition = Mouse.current.position.ReadValue().x;
        float difference = panAreaWidth;
        if (mousePosition <= panAreaWidth)
        {
            difference = mousePosition;
        }
        else if (Screen.width - mousePosition <= panAreaWidth)
        {
            difference = Screen.width - mousePosition;
        }
        difference = difference < 0 ? 0 : difference;
        transform.position += Math.Sign(mousePosition - Screen.width / 2) * (difference - panAreaWidth) * panSpeed * Vector3.right;

        foreach (Transform room in rooms)
        {
            Vector3 offset = 2 * width * Vector3.right;
            if (room.position.x > width)
            {
                room.position -= offset;
            }
            else if (room.position.x < -width)
            {
                room.position += offset;
            }
        }
    }
}
