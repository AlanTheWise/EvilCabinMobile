using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChange : MonoBehaviour
{
    public static CharacterChange sharedInstance;
    public bool changeBlocked;

    void Awake() {
        if (sharedInstance == null){
            sharedInstance = this;
        }
    }

    void Update() {
        if (changeBlocked) return;

        if (SimpleInput.GetKeyDown(KeyCode.F)){
            if (PlayerController.sharedInstance.controllingActive){
                PlayerController.sharedInstance.controllingActive = false;
                DogController.sharedInstance.controllingActive = true;
            } else {
                PlayerController.sharedInstance.controllingActive = true;
                DogController.sharedInstance.controllingActive = false;
            }
            UpdateCamTarget();
            UIController.sharedInstance.UpdateButtonUI();
            UIController.sharedInstance.UpdateVFX();
        }
    }

    void UpdateCamTarget(){
        if (PlayerController.sharedInstance.controllingActive) {
            CameraFollow.sharedInstance.ChangeTarget(PlayerController.sharedInstance.transform);
        } else { 
            CameraFollow.sharedInstance.ChangeTarget(DogController.sharedInstance.transform);
        }
    }
}
