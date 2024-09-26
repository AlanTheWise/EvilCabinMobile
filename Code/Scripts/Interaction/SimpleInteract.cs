using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteract : MonoBehaviour, IInteractableDialogue
{
    [SerializeField] private DialogueBlock interactDialogue;
    public DialogueBlock InteractDialogue => interactDialogue;

    public void ShowInteractDialogue()
    {
        DialogueHandler.sharedInstance.StartInteractDialogue(interactDialogue, "LUKE");
    }
}

