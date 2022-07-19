using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotItem : MonoBehaviour
{
   public bool isFull;

   public bool isSelected;

   public GameObject itemSlotObj;

   public InstanciaItensManager ItensManager;

   public GameObject menu;







   private void Update() {
    
   }

private void Awake() {
}
   

   public void SelectSlot()
   {
    isSelected = true;
    ItensManager.itemSlotSelecionado = itemSlotObj;
    ItensManager.slotSelecionado = this.gameObject.GetComponent<SlotItem>();

Debug.Log(this.gameObject.name + isSelected);

   }

   public void AbreMenu()
   {
   
        if (isSelected == true && isFull == false)
        {
             menu.SetActive(true);

        }

        if (isFull == true && isSelected == true)
        {
              menu.SetActive(true);

        }
     
    
   }



}


