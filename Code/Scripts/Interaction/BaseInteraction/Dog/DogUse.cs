using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DogUse : Interact
{
    [SerializeField] UnityEvent action;
    AudioSource useSound;

    private void Start() {
        useSound = GameObject.Find("ItemUseSound").GetComponent<AudioSource>();
    }

    protected override void Init(){
        triggerTag = "Dog";
    }

    protected override void Action()
    {
        useSound.Play();
        action.Invoke();
    }

    protected override bool IsControllingActive(){
        return DogController.sharedInstance.controllingActive;
    }
}
