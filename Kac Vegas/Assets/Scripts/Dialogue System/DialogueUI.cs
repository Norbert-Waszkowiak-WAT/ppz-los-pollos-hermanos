using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using System;
public class DialogueUI : MonoBehaviour
{
    
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    
    private TypeWrittingEffect typeWrittingEffect;
    private ResponseHandler responseHandler;
    public PlayerController player;
    private void Start()
    {
        
        typeWrittingEffect = GetComponent<TypeWrittingEffect>();
        responseHandler = GetComponent<ResponseHandler>();
        CloseDialogueBox();
        responseHandler.CloseResponse();
        
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));

    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {


        for( int i =0; i< dialogueObject.Dialogue.Length;i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typeWrittingEffect.Run(dialogue, textLabel);
            if( i==dialogueObject.Dialogue.Length -1 && dialogueObject.HasResponses) break; 


            yield return new WaitUntil(()=>Input.GetKeyDown(KeyCode.Space));

        }
        if(dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
             CloseDialogueBox();
             player.canControl = true;

        }


       
    }
    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = String.Empty;
    }
    
}
