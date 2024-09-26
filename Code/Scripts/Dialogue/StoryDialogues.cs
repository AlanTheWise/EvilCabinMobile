using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryDialogues : MonoBehaviour
{
    [SerializeField] private DialogueBlock dialogueBlock, doctor1, luke1, ciervo1, doctor2, ciervo2, doctor3, luke2;
    [SerializeField] private Animator interactAnimator;
    //bool zoomAnim = true;

    void Start()
    {
        DialogueHandler.sharedInstance.StartDialogue(dialogueBlock, "LUKE");
        //interactAnimator.SetBool("ZoomAnim", zoomAnim);
    }

    private void Update() {
        /*if (SimpleInput.GetKeyDown(KeyCode.E) && zoomAnim){
            zoomAnim = false;
            interactAnimator.SetBool("ZoomAnim", zoomAnim);
        }*/
    }


    // que pereza hacerlo bien... sobretodo siendo el ultimo dia antes de la entrega xd

    public void Doctor1Dialogue(){
        DialogueHandler.sharedInstance.StartInteractDialogue(doctor1, "DR.WALKER");
    }

    public void Luke1Dialogue(){
        DialogueHandler.sharedInstance.StartInteractDialogue(luke1, "LUKE");
    }

    public void Ciervo1Dialogue(){
        DialogueHandler.sharedInstance.StartInteractDialogue(ciervo1, "CIERVO");
    }

    public void Doctor2Dialogue(){
        DialogueHandler.sharedInstance.StartInteractDialogue(doctor2, "DR.WALKER");
    }

    public void Ciervo2Dialogue(){
        DialogueHandler.sharedInstance.StartInteractDialogue(ciervo2, "CIERVO");
    }

    public void Doctor3Dialogue(){
        DialogueHandler.sharedInstance.StartInteractDialogue(doctor3, "DR.WALKER");
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void Luke2Dialogue(){
        DialogueHandler.sharedInstance.StartInteractDialogue(luke2, "LUKE");
    }
}
