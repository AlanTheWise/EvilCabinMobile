using System.Collections;
using System.Collections.Generic;
using EPOOutline;
using UnityEngine;

public class AxeDoorInteract : MonoBehaviour, IInteractableDialogue
{
    [SerializeField] private DialogueBlock interactDialogue;
    [SerializeField] private GameObject interact;
    [SerializeField] private Outlinable outline;
    public AudioSource doorOpenSound;
    public DialogueBlock InteractDialogue => interactDialogue;


    public void Open(){
        outline.enabled = false;
        doorOpenSound.Play();
        Destroy(interact);
    }

    public void ShowInteractDialogue()
    {
        DialogueHandler.sharedInstance.StartInteractDialogue(interactDialogue, "LUKE");
    }
}
