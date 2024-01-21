using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PointerReaction))]
public class Interactable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private UnityEvent action;

    public void OnPointerClick(PointerEventData data)
    {
        action.Invoke();
    }
}
