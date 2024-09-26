using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPickItem : Interact
{
    [SerializeField] Item item;
    AudioSource grabSound;

    private void Start() {
        grabSound = GameObject.Find("ItemPickSound").GetComponent<AudioSource>();
    }

    protected override void Init(){
        triggerTag = "Dog";
    }

    protected override void Update()
    {
        if (DogInventoryManager.sharedInstance.IsCarryingItem()){
            exclamationModel.SetActive(false);
        }
        base.Update();
    }

    protected override void Action()
    {
        if (DogInventoryManager.sharedInstance.IsCarryingItem()) return;
        Pick();
    }

    protected override bool IsControllingActive(){
        return DogController.sharedInstance.controllingActive;
    }

    public void Pick(){
        grabSound.Play();
        DogInventoryManager.sharedInstance.dogItem = item;
        PlaceInMouth();
    }

    private void PlaceInMouth(){
        transform.parent.position = DogController.sharedInstance.transform.position;
        transform.parent.SetParent(DogInventoryManager.sharedInstance.itemCarryParent, true);
        transform.parent.localPosition = new Vector3(0, 0.15f, 0.35f);
        transform.parent.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
