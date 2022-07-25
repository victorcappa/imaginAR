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

        // if (otherSlots[0].isSelected || otherSlots[1].isSelected)
        // {
        //    if (isSelected)
        //    {
        //    StartCoroutine(Deselect());

        //    }
        // }

        if (isFull)
        {
            itemSlotObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }

    }

private void Awake() {

   UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
}


    // ele está definindo o itemSlotObj cedo demais. Precisa ir para o ItemMenu
    // public void SelectSlot()
    // {
    //      StartCoroutine(Select());




    //  }

    public void SelectDeselectSlot()
    {


        if (otherSlots[0].isSelected || otherSlots[1].isSelected)
        {
            StartCoroutine(Deselect());
            StartCoroutine(Select());

        }

        else
        {

            StartCoroutine(Select());
        }



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
        yield return new WaitForSeconds(.001f);
        otherSlots[0].isSelected = false;
        otherSlots[1].isSelected = false;


    }

    IEnumerator Select()
    {
        yield return new WaitForSeconds(.1f);
        isSelected = true;
        UIManager.slotUI = this.gameObject.GetComponent<SlotItem>();
        ItensManager.slotSelecionado = this.gameObject.GetComponent<SlotItem>();
    }



}


