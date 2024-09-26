using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoTalarInteract : MonoBehaviour
{
    [SerializeField] private Item itemNeeded;
    [SerializeField] private GameObject interact, trigger, troncoCaidoColliders;
    [SerializeField] private Animator troncoAnim;

    public AudioSource fallSound;

    public void Talar(){
        if (PlayerInventoryManager.Singleton.HasItem(itemNeeded)){
            PlayerInventoryManager.Singleton.Remove(itemNeeded);
            Destroy(interact);
            trigger.SetActive(false);
            troncoCaidoColliders.SetActive(true);
            troncoAnim.SetBool("Talar", true);
            Invoke("PlaySound", 1.5f);
        } 
    }

    public void PlaySound(){
        fallSound.Play();
    }
}
