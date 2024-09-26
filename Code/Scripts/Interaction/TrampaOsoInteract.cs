using System.Collections;
using System.Collections.Generic;
using EPOOutline;
using UnityEngine;

public class TrampaOsoInteract : MonoBehaviour, IInteractableDialogue
{
    [SerializeField] private Item itemNeeded;
    [SerializeField] private DialogueBlock interactDialogue;
    [SerializeField] private GameObject palo, interact;
    [SerializeField] private Outlinable outline;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private Animator doorAnim;
    [SerializeField] private AudioSource closeSound;
    public DialogueBlock InteractDialogue => interactDialogue;

    public void Open(){
        if (PlayerInventoryManager.Singleton.HasItem(itemNeeded)){
            PlayerInventoryManager.Singleton.Remove(itemNeeded);
            outline.enabled = false;
            boxCollider.enabled = false;
            palo.SetActive(true);
            Destroy(interact);
            doorAnim.SetBool("Open", true);
            Invoke("PlaySound", 0.75f);
        } else{
            ShowInteractDialogue();
        }
    }

    public void ShowInteractDialogue()
    {
        DialogueHandler.sharedInstance.StartInteractDialogue(interactDialogue, "LUKE");
    }

    void PlaySound(){
        closeSound.Play();
    }
}
