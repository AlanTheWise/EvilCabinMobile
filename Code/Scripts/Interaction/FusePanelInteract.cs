using System.Collections;
using System.Collections.Generic;
using EPOOutline;
using UnityEngine;

public class FusePanelInteract : MonoBehaviour, IInteractableDialogue
{
    [SerializeField] private Item fuse;
    [SerializeField] private GameObject trap, vfx, interact, fusible;
    [SerializeField] private DialogueBlock interactDialogue;
    [SerializeField] Outlinable outline;
    public AudioSource electricitySound;
    public DialogueBlock InteractDialogue => interactDialogue;

    public void Put(){
        if (PlayerInventoryManager.Singleton.HasItem(fuse)){
            PlayerInventoryManager.Singleton.Remove(fuse);
            Destroy(trap);
            fusible.SetActive(true);
            electricitySound.Stop();
            outline.enabled = false;
            Destroy(vfx);
            Destroy(interact); // para que ya no puedas interactuar con el panel
        } else{
            ShowInteractDialogue();
        }
    }

    public void ShowInteractDialogue()
    {
        DialogueHandler.sharedInstance.StartInteractDialogue(interactDialogue, "LUKE");
    }
}
