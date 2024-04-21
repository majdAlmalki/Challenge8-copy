using Meta.WitAi.Json;
using Oculus.Voice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVoice : MonoBehaviour
{
    public AppVoiceExperience AiVoice;
    public InputActionProperty xInput;
    
    //public Animator animatorController;
    //public string animationName;
    //public float timelineSpeed;
    public GameObject canvaui;



    private void Start()
    {
        AiVoice.VoiceEvents.OnPartialResponse.AddListener(SetSaidResponse);
    }
    private void Update()
    {
        if (xInput.action.WasPressedThisFrame())
        {
            ActivatLeasiner();
        }
        else if (xInput.action.WasReleasedThisFrame())
        {
            DeactivatLeasiner();
        }
    }

    public void SetSaidResponse(WitResponseNode response)
    {
        string myintent = response["intents"][0]["name"].Value;

        if (myintent == "student" || myintent == "answer")
        {
            //animatorController.Play(animationName, -1, timelineSpeed);
            canvaui.SetActive(true);
            Debug.Log("d");
        }
    }

    void ActivatLeasiner()
    {
        AiVoice.Activate();
    }
    void DeactivatLeasiner()
    {
        AiVoice.Deactivate();
    }
}
