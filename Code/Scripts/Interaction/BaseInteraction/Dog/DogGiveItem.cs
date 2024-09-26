using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script permite al perro dar un objeto al jugador
public class DogGiveItem : Interact
{
    [SerializeField] Item item;
    AudioSource useSound;

    private void Start() {
        useSound = GameObject.Find("ItemUseSound").GetComponent<AudioSource>();
    }

    protected override void Init(){
        triggerTag = "Player";
    }

    protected override void Update() {
        if (!DogInventoryManager.sharedInstance.IsCarryingItem()){
            exclamationModel.SetActive(false);
        }
        base.Update();
    }

    protected override void Action()
    {
        if (!DogInventoryManager.sharedInstance.IsCarryingItem()) return;
        useSound.Play();
        GiveToPlayer();
    }

    protected override bool IsControllingActive(){
        return DogController.sharedInstance.controllingActive;
    }

    public void GiveToPlayer(){
        PlayerInventoryManager.Singleton.Add(item);
        DogInventoryManager.sharedInstance.RemoveItem();
        Destroy(gameObject.transform.parent);
    }
}
