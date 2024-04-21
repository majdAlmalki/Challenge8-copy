using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CorrectKeyworld : MonoBehaviour
{
    public List<char> correctKey = new List<char>();
    private List<char> inputKeyList = new List<char>();

    [SerializeField] private TMP_InputField codeDisplay;
    [SerializeField] private float resetTime = 2f;
    [SerializeField] private string successText;

    [Header("Keypad Entry Events")]
    public UnityEvent onCorrectKey;
    public UnityEvent onIncorrectKey;

    public bool allowMultipleActivations = false;
    private bool hasUsedCorrectCode = false;

    public bool HasUsedCorrectCode { get { return hasUsedCorrectCode; } }


    public void UserNumberEntry(char selectedChar)
    {
        if (inputKeyList.Count >= 8) return;

        inputKeyList.Add(selectedChar);

        UpdateDispay();

        if (inputKeyList.Count >= 8) CheckKey();
    }

    private void CheckKey()
    {
        for (int i = 0; i < correctKey.Count; i++)
        {
            if (inputKeyList[i] != correctKey[i])
            {
                IncorrectKey();
                return;
            }
        }
        CorrectKeyGiven();
    }

    private void CorrectKeyGiven()
    {
        if (allowMultipleActivations)
        {

            onCorrectKey.Invoke();
            codeDisplay.text = successText;
           
            StartCoroutine(RestKeyCode());
        }
        else if (!allowMultipleActivations && !hasUsedCorrectCode)
        {
            
            onCorrectKey.Invoke();
            hasUsedCorrectCode = true;
            codeDisplay.text = successText;
            
        }
    }
    private void IncorrectKey()
    {
        onIncorrectKey.Invoke();
        StartCoroutine(RestKeyCode());
    }
    private void UpdateDispay()
    {
        codeDisplay.text = null;
        for (int i = 0; i < inputKeyList.Count; i++)
        {
            codeDisplay.text += inputKeyList[i];
        }
    }
    IEnumerator RestKeyCode()
    {
        yield return new WaitForSeconds(resetTime);

        inputKeyList.Clear();
        codeDisplay.text = "Enter Code...";
    }
}
