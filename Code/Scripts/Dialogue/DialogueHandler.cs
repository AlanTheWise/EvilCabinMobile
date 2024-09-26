using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Febucci.UI;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    public static DialogueHandler sharedInstance;
    [SerializeField] private TMP_Text dialogueBox, speakerBox;
    [SerializeField] private TypewriterByCharacter typewriter;
    [SerializeField] private Image dialogueImage;
    public AudioSource interactSound;

    bool storyDialogueActive, interactDialogueActive;

    private bool textLineEnded;

    private void Awake() {
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }

    private void Start() {
        typewriter.onTextShowed.AddListener(HandleTextLineEndedEvent);
    }

    private IEnumerator ShowDialogue(DialogueBlock dialogueBlock, string speaker){
        storyDialogueActive = true;

        while (interactDialogueActive){
            yield return new WaitForSeconds(0.01f);
        }

        dialogueBox.text = "";
        speakerBox.text = "";

        dialogueBox.enabled = true;
        speakerBox.enabled = true;
        dialogueImage.enabled = true;

        speakerBox.text = speaker;

        PlayerController.sharedInstance.movementBlocked = true;
        DogController.sharedInstance.movementBlocked = true;
        CharacterChange.sharedInstance.changeBlocked = true;

        for (int i = 0; i < dialogueBlock.textLine.Length; i++)
        {
            dialogueBox.text = dialogueBlock.textLine[i];
            while (true)
            {
                if(textLineEnded) {
                    yield return new WaitForSeconds(1.5f);
                    break;
                }
                yield return null;
            }

            textLineEnded = false;

            yield return null;
        }
        dialogueBox.enabled = false;
        speakerBox.enabled = false;
        dialogueImage.enabled = false;

        dialogueBox.text = "";
        speakerBox.text = "";

        PlayerController.sharedInstance.movementBlocked = false;
        DogController.sharedInstance.movementBlocked = false;
        CharacterChange.sharedInstance.changeBlocked = false;

        storyDialogueActive = false;
    }

    private IEnumerator ShowInteractDialogue(DialogueBlock dialogueBlock, string speaker){
        if (dialogueBox.enabled) yield break;

        interactDialogueActive = true;
        
        dialogueBox.enabled = true;
        speakerBox.enabled = true;
        dialogueImage.enabled = true;

        speakerBox.text = speaker;

        for (int i = 0; i < dialogueBlock.textLine.Length; i++)
        {
            dialogueBox.text = dialogueBlock.textLine[i];
            while (true)
            {
                if(textLineEnded || storyDialogueActive) {
                    break;
                } 
                yield return null;
            }

            textLineEnded = false;

            yield return new WaitForSeconds(0.5f);
        }
        dialogueBox.enabled = false;
        speakerBox.enabled = false;
        dialogueImage.enabled = false;

        dialogueBox.text = "";
        speakerBox.text = "";
        
        interactDialogueActive = false;
    }

    public void StartInteractDialogue(DialogueBlock dialogueBlock, string speaker){
        StartCoroutine(ShowInteractDialogue(dialogueBlock, speaker));
    }

    public void StartDialogue(DialogueBlock dialogueBlock, string speaker){
        StartCoroutine(ShowDialogue(dialogueBlock, speaker));
    }

    private void HandleTextLineEndedEvent()
    {
        textLineEnded = true;
    }
    
}
