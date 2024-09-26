using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickItem : Interact
{ 
    [SerializeField] Item item;
    AudioSource grabSound;

    private void Start() {
        grabSound = GameObject.Find("ItemPickSound").GetComponent<AudioSource>();
    }
    protected override void Init(){
        triggerTag = "Player";
    }

    protected override void Action(){
        Pick();
        PlayerController.sharedInstance.anim.SetTrigger("interact");
    }

    protected override bool IsControllingActive(){
        return PlayerController.sharedInstance.controllingActive;
    }

    public void Pick(){
        grabSound.Play();
        PlayerInventoryManager.Singleton.Add(item);
        if (DogInventoryManager.sharedInstance.HasItem(item)){
            DogInventoryManager.sharedInstance.RemoveItem();
        }
        Destroy(transform.parent.gameObject);
    }
}
