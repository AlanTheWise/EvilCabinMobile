using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BonePuzzleInteract : MonoBehaviour
{
    [SerializeField] private GameObject throwableBonePrefab;
    [SerializeField] private Vector3 throwableBoneSpawnPos;
    [SerializeField] private Item itemNeeded;

    public void SpawnThrowableBone(){
        if(PlayerInventoryManager.Singleton.HasItem(itemNeeded)){
            PlayerInventoryManager.Singleton.Remove(itemNeeded);
            GameObject boneInstance = Instantiate(throwableBonePrefab, throwableBoneSpawnPos, Quaternion.identity);
            boneInstance.transform.parent = GameObject.Find("DynamicObjects").transform;
            boneInstance.GetComponent<ThrowableBone>().Throw();
            BonePuzzleEvent.sharedInstance.bonesThrowed++;
        }
    }
}
