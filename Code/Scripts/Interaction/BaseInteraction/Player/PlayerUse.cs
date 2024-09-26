using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUse : Interact
{ 
    [SerializeField] UnityEvent action;
    AudioSource useSound;

    private void Start() {
        useSound = GameObject.Find("ItemUseSound").GetComponent<AudioSource>();
    }

    protected override void Init(){
        triggerTag = "Player";
    }

    protected override void Action(){
        useSound.Play();
        action.Invoke();
        PlayerController.sharedInstance.anim.SetTrigger("use");
    }

    protected override bool IsControllingActive(){
        return PlayerController.sharedInstance.controllingActive;
    }
}
