using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BonePuzzleEvent : MonoBehaviour
{
    public static BonePuzzleEvent sharedInstance;

    [SerializeField] private GameObject bonePuzzle;
    [SerializeField] private Item boneItem;
    [HideInInspector] public bool bonePuzzleInProgress;

    [HideInInspector] public int bonesThrowed;
    [SerializeField] private int bonesThrowedToEnd;

    [SerializeField] private PlayableDirector cutscene_0;
    [SerializeField] private Animator changeButtonAnim;
    private bool cutscenePlayed;
    private bool tutorialActivated;

    public DialogueBlock dialogue;

    private void Awake() {
        if(sharedInstance == null){
            sharedInstance = this;
        }

        cutscene_0.RebuildGraph();
    }

    private void Update() {
        // Si coges el hueso que hay en el suelo comienza el evento
        if (PlayerInventoryManager.Singleton.HasItem(boneItem) && !bonePuzzleInProgress){
            bonePuzzleInProgress = true;
            bonePuzzle.SetActive(true);
        }

        if (!bonePuzzleInProgress) return;

        if(bonesThrowed == 1 && !tutorialActivated){
            changeButtonAnim.SetBool("ZoomAnimation", true);
            tutorialActivated = true;
        } else if(bonesThrowed == 1 && DogController.sharedInstance.controllingActive){
            changeButtonAnim.SetBool("ZoomAnimation", false);
        }

        if(bonesThrowed == 2 && !cutscenePlayed){
            cutscenePlayed = true;
            Invoke("PlayCutscene", 1.5f);
        }

        // Bone Puzzle ended
        if(bonesThrowed == bonesThrowedToEnd && bonePuzzleInProgress){
            bonePuzzleInProgress = false;
            Invoke("DestroyBone", 6f);
            Invoke("ShowDialogue", 13f);
        }

        // Player cannot move while doing the puzzle
        if (bonePuzzleInProgress && BonePuzzleEvent.sharedInstance.bonesThrowed > 0){
            PlayerController.sharedInstance.movementBlocked = true;
        } 
    }

    void DestroyBone(){
        Destroy(GameObject.Find("DynamicObjects").transform.GetChild(0).gameObject);
    }

    void ShowDialogue(){
        DialogueHandler.sharedInstance.StartDialogue(dialogue, "LUKE");
        Destroy(gameObject);
    }

    void PlayCutscene(){
        bonePuzzle.SetActive(false);
        CutsceneHandler.sharedInstance.StartCutscene(cutscene_0);
    }
}
