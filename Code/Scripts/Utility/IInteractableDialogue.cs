using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableDialogue
{
    DialogueBlock InteractDialogue { get; }
    void ShowInteractDialogue();
}
