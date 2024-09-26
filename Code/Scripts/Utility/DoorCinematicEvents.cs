using System.Collections;
using System.Collections.Generic;
using EPOOutline;
using UnityEngine;

public class DoorCinematicEvents : MonoBehaviour
{
    [SerializeField] private Outlinable outlinable; 
    [SerializeField] private BoxCollider bc;

    public void TurnOffOutline(){
        outlinable.enabled = false;
    } 

    public void TurnOffCollider(){
        bc.enabled = false;
    }
}
