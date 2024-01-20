using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Button : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textBox;
    
    public abstract void Activate();
}
