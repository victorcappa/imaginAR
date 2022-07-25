using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Niantic.ARDK.Utilities.Input.Legacy;

     [RequireComponent(typeof(Collider))] //A collider is needed to receive clicks

public class ItemMenu : MonoBehaviour
{  
    
   public UIManager UIManager;
   public InstanciaItensManager itensManager;
    public UnityEvent interactEvent;

    public GameObject objPrefab;

    GameObject objSlot;



    private void Awake() {
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        itensManager = GameObject.Find("InstanciaItensManager").GetComponent<InstanciaItensManager>();

    }


     private void OnMouseDown() {

        interactEvent.Invoke();

        objSlot = Instantiate(objPrefab);
        //objSlot.SetActive(value: false);


        UIManager.VerificaSlots(objSlot);
    }
 



}
