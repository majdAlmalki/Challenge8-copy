using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System;
using UnityEngine.Events;

public class ShowKeyboard : MonoBehaviour
{
    private TMP_InputField inputfield;

    public float distance = 0.5f;
    public float verticalOffset = -0.5f;

    public Transform positionSource;

    [Header("Keypad Entry Events")]
    public UnityEvent onCorrectKey;
    //public UnityEvent onIncorrectKey;

    // Start is called before the first frame update
    void Start()
    {
        inputfield = GetComponent<TMP_InputField>();
        inputfield.onSelect.AddListener(x => OpenKeyboard() );
    }

    public void OpenKeyboard()
    {
        NonNativeKeyboard.Instance.InputField = inputfield;
        NonNativeKeyboard.Instance.PresentKeyboard(inputfield.text);

        Vector3 direction = positionSource.forward;
        direction.y = 0;
        direction.Normalize();

        Vector3 targetPostion = positionSource.position + direction * distance + Vector3.up * verticalOffset;

        NonNativeKeyboard.Instance.RepositionKeyboard(targetPostion);

        SetCaretColorAlpha(1);

        

        NonNativeKeyboard.Instance.OnClosed += Instance_OnClosed;
        
    }

    private void Instance_OnClosed(object sender, EventArgs e)
    {
        SetCaretColorAlpha(0);
        NonNativeKeyboard.Instance.OnClosed -= Instance_OnClosed;
        if (inputfield.text == "console") { inputfield.text = "Correct!"; }
    }

    public void SetCaretColorAlpha(float value)
    {
        inputfield.customCaretColor = true;
        Color caretColor = inputfield.caretColor;
        caretColor.a = value;
        inputfield.caretColor = caretColor;
    }


}
