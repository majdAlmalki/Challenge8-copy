using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class RandomNumber : MonoBehaviour
{
    [SerializeField] int randomNumber;
    [SerializeField] TMP_Text displayNumber;
    [SerializeField] int correctNumber = 3;

    [Header("Panel Entry Events")]
    public UnityEvent onCorrectNum;
    public UnityEvent onIncorrectNum;

    public void CreateRandomNumber()
    {
        randomNumber = Random.Range(0, 5);
        displayNumber.text = randomNumber.ToString();

        if (randomNumber == correctNumber)
        {
            CorrectNumGiven();

        }
        else
        {
            IncorrectNum();
        }
    }

    private void CorrectNumGiven()
    {
        onCorrectNum.Invoke();

    }


    private void IncorrectNum()
    {
        onIncorrectNum.Invoke();
    }

    }
