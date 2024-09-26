using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interact : MonoBehaviour
{
    // El tag del game object que va a detectar el trigger
    protected string triggerTag;
    // El modelo de la exlamación que se mostrará cuando el go con dicho tag esté en el trigger
    [SerializeField] protected GameObject exclamationModel;
    // true si el go está en el trigger
    private bool onTrigger;

    // Valores a inicializar para la clase hija
    abstract protected void Init();
    // Acción que se va a realizar cuando el go con dicho tag presione la tecla de interacción
    protected abstract void Action();
    // Devuelve true si el jugador concreto está activo y se está controlando
    protected abstract bool IsControllingActive();

    private void Awake() {
        Init();
    }
    
    protected virtual void Update() {
        if (onTrigger){
            // Si el jugador está en el trigger y pulsa la tecla de interacción, realizar evento
            if (SimpleInput.GetKeyDown(KeyCode.E)){
                Action();
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag(triggerTag)){
            if (!IsControllingActive()){
                // No mostrar modelo de exlamción si no se está controlando dicho jugador y desactivar trigger
                exclamationModel.SetActive(false);
                onTrigger = false;
                return;
            } 
            
            // El jugador se está controlando
            onTrigger = true;

            exclamationModel.SetActive(true);
        }
    }

    // El jugador ha dejado el trigger, desactivar variable onTrigger y modelo de exlamación
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag(triggerTag)){
            onTrigger = false;
            exclamationModel.SetActive(false);
        }
    }
}
