using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneHandler : MonoBehaviour
{
    public static CutsceneHandler sharedInstance;
    [SerializeField] private CameraFollow camFollow;
    [SerializeField] private GameObject cinematicBars;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private PlayableDirector test;

    private void Awake() {
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }

    private void Start() {
        //StartCutscene(test);
    }

    public void StartCutscene(PlayableDirector director){
        StartCoroutine(CutscenePlay(director));
    }

    private IEnumerator CutscenePlay(PlayableDirector director){
        PlayerController.sharedInstance.movementBlocked = true;
        DogController.sharedInstance.movementBlocked = true;
        CharacterChange.sharedInstance.changeBlocked = true;
        camFollow.enabled = false;
        cinematicBars.SetActive(true);
        playerUI.SetActive(false);

        director.Play();

        while (director.state == PlayState.Playing) {
            yield return null;
        }

        PlayerController.sharedInstance.movementBlocked = false;
        DogController.sharedInstance.movementBlocked = false;
        CharacterChange.sharedInstance.changeBlocked = false;
        camFollow.enabled = true;
        cinematicBars.SetActive(false);
        playerUI.SetActive(true);
    }
}
