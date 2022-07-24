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

   public SlotItem[] otherSlots;

   public UIManager UIManager;







   private void Update() {

      if (otherSlots[0].isSelected || otherSlots[1].isSelected)
      {
         if (isSelected)
         {
         StartCoroutine(Deselect());

         }
      }
    
   }

private void Awake() {

   UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
}

   
// ele está definindo o itemSlotObj cedo demais. Precisa ir para o ItemMenu
   public void SelectSlot()
   {
    isSelected = true;
    UIManager.slotUI = this.gameObject.GetComponent<SlotItem>();
    ItensManager.slotSelecionado = this.gameObject.GetComponent<SlotItem>();


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

   IEnumerator Deselect()
   {
      yield return new WaitForSeconds(.1f);
       isSelected = false;
   }



}


