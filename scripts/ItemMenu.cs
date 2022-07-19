using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Niantic.ARDK.Utilities.Input.Legacy;

     [RequireComponent(typeof(Collider))] //A collider is needed to receive clicks

public class ItemMenu : MonoBehaviour
{  
    
   public UIManager UIManager;
        public UnityEvent interactEvent;

    private void Awake() {
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }


     private void OnMouseDown() {
         interactEvent.Invoke();

         UIManager.VerificaSlots(this.gameObject);
     }
 



}
