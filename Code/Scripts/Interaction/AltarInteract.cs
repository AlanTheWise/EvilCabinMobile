using System.Collections;
using System.Collections.Generic;
using EPOOutline;
using UnityEngine;
using UnityEngine.Playables;

public class AltarInteract : MonoBehaviour, IInteractableDialogue
{
    [SerializeField] private Item itemNeeded1, itemNeeded2;
    [SerializeField] private DialogueBlock interactDialogue;
    [SerializeField] private GameObject interact;
    [SerializeField] private Outlinable outline1, outline2;
    [SerializeField] private PlayableDirector cutscene_1;
    public DialogueBlock InteractDialogue => interactDialogue;


    public void Place(){
        if (PlayerInventoryManager.Singleton.HasItem(itemNeeded1) && PlayerInventoryManager.Singleton.HasItem(itemNeeded2)){
            PlayerInventoryManager.Singleton.Remove(itemNeeded1);
            PlayerInventoryManager.Singleton.Remove(itemNeeded2);
            Destroy(interact);
            outline1.enabled = false;
            outline2.enabled = false;
            CutsceneHandler.sharedInstance.StartCutscene(cutscene_1);
        } else{
            ShowInteractDialogue();
        }
    }

    public void ShowInteractDialogue()
    {
        DialogueHandler.sharedInstance.StartInteractDialogue(interactDialogue, "LUKE");
    }
}
