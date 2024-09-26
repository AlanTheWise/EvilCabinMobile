using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityDoorInteract : MonoBehaviour, IInteractableDialogue
{
    [SerializeField] private Item itemNeeded;
    [SerializeField] private DialogueBlock interactDialogue;
    [SerializeField] private GameObject interact;
    [SerializeField] private Animator doorAnim;
    public AudioSource doorSound;
    public DialogueBlock InteractDialogue => interactDialogue;

    public void Open(){
        if (PlayerInventoryManager.Singleton.HasItem(itemNeeded)){
            PlayerInventoryManager.Singleton.Remove(itemNeeded);
            Destroy(interact);
            doorAnim.SetBool("Open", true);
            Invoke("DoorSound", 0.6f);
        } else{
            ShowInteractDialogue();
        }
    }

    public void ShowInteractDialogue()
    {
        DialogueHandler.sharedInstance.StartInteractDialogue(interactDialogue, "LUKE");
    }

    public void DoorSound(){
        doorSound.Play();
    }
}
