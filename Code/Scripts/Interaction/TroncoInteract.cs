using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoInteract: MonoBehaviour, IInteractableDialogue
{
    [SerializeField] private Item itemNeeded;
    [SerializeField] private GameObject tronco, troncoPartido, interact;
    [SerializeField] private DialogueBlock interactDialogue;
    public DialogueBlock InteractDialogue => interactDialogue;

    public void Open(){
        if (PlayerInventoryManager.Singleton.HasItem(itemNeeded)){
            tronco.SetActive(false);
            troncoPartido.SetActive(true);
            Destroy(interact);
        } else{
            ShowInteractDialogue();
        }
    }

    public void ShowInteractDialogue()
    {
        DialogueHandler.sharedInstance.StartInteractDialogue(interactDialogue, "LUKE");
    }
}
