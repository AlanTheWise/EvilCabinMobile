using System.Collections;
using System.Collections.Generic;
using EPOOutline;
using UnityEngine;

public class ColorPanelManager : MonoBehaviour
{
    public static ColorPanelManager sharedInstance;
    [SerializeField] public AxeDoorInteract axeDoor;
    [SerializeField] private ColorPanelInteract panel1, panel2, panel3;
    [SerializeField] private GameObject panel1Interact, panel2Interact, panel3Interact;
    [SerializeField] private string[] correctColorCode;
    [SerializeField] private GameObject blackCube;
    [SerializeField] private Animator doorAnim;
    [SerializeField] private Outlinable outline;

    private void Awake() {
        if(sharedInstance == null){
            sharedInstance = this;
        }
    }
    
    public void CheckAnswer(){
        if(panel1.CurrentColor() == correctColorCode[0] && panel2.CurrentColor() == correctColorCode[1] 
        && panel3.CurrentColor() == correctColorCode[2]){
            outline.enabled = false;
            axeDoor.Open();
            doorAnim.SetBool("Open", true);
            Destroy(blackCube);
            Destroy(panel1Interact);
            Destroy(panel2Interact);    
            Destroy(panel3Interact);
        }  
    }
}
