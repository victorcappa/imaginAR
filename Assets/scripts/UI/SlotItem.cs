using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotItem : MonoBehaviour
{
   public bool isFull;

   public bool isSelected;

    public GameObject iconeItemSlot;

    public InstanciaItensManager ItensManager;

    // public GameObject menu;

    public SlotItem[] otherSlots;

   public UIManager UIManager;







   private void Update() {


    }

private void Awake() {

   UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        ItensManager = GameObject.Find("InstanciaItensManager").GetComponent<InstanciaItensManager>();
}



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


