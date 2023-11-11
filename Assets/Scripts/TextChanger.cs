using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text textToChange;

    [SerializeField] private string textToUse;

    [ContextMenu("Modify text")]
    private void ChangeText()
    {
        textToChange.text = textToUse;
    }
}
