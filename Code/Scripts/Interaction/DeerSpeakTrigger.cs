using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerSpeakTrigger : MonoBehaviour
{
    [SerializeField] private DialogueBlock interactDialogue;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            ShowInteractDialogue();
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void ShowInteractDialogue()
    {
        DialogueHandler.sharedInstance.StartDialogue(interactDialogue, "CIERVO");
    }
}
