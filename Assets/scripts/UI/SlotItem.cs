using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
   public bool isFull;

   public bool isSelected;

    public GameObject iconeItemSlot;

    public InstanciaItensManager ItensManager;

    // public GameObject menu;

    public SlotItem[] otherSlots;

   public UIManager UIManager;

    Color corSeleciona, corSelecionado, corBase;









    private void Update()
    {


    }

private void Awake() {

   UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        ItensManager = GameObject.Find("InstanciaItensManager").GetComponent<InstanciaItensManager>();

        corSeleciona = new Color(161, 0, 255, 0.2f);
        corSelecionado = new Color(255, 0, 225, 0.4f);
        corBase = new Color(1, 1, 1, 0.2f);

    }



    public void SelectDeselectSlot()
    {


        if (otherSlots[0].isSelected || otherSlots[1].isSelected)
        {
            Deselect();
            StartCoroutine(Select());

            // this.gameObject.GetComponent<Image>().color = Color.Lerp(corBase, corSeleciona, 1f);
            StartCoroutine(MudaCor(this.gameObject, duration: 1f, corSeleciona));

        }

        else
        {

            StartCoroutine(Select());
            // this.gameObject.GetComponent<Image>().color = Color.Lerp(corSeleciona, corSelecionado, 1f);


        }





    }


    void Deselect()
   {


        StartCoroutine(MudaCor(otherSlots[1].gameObject, 1f, corBase));
        StartCoroutine(MudaCor(otherSlots[0].gameObject, 1f, corBase));




    }

    void Select()
    {
        if (!isSelected && UIManager.menuAberto == true) //&& UIManager.menuObj == isActiveAndEnabled)
        {

            StartCoroutine(routine: MudaCor(this.gameObject, duration: 1f, corSelecionado));
            Debug.Log(2);


        }
        yield return new WaitForSeconds(.1f);

        Debug.Log(UIManager.menuAberto);

        if (isSelected && UIManager.menuAberto == true) //&& UIManager.menuObj == isActiveAndEnabled)
        {

            StartCoroutine(routine: MudaCor(this.gameObject, duration: 1f, corSelecionado));
            Debug.Log(1);


        }


        if (!isSelected && UIManager.menuAberto == false)
        {
            StartCoroutine(MudaCor(this.gameObject, 1f, corSeleciona));
            Debug.Log(3);


        }
        yield return new WaitForSeconds(.1f);
        isSelected = true;
        UIManager.slotUI = this.gameObject.GetComponent<SlotItem>();
        ItensManager.slotSelecionado = this.gameObject.GetComponent<SlotItem>();




    }

    IEnumerator MudaCor(GameObject slotObj, float duration, Color corFinal)
    {
        yield return new WaitForSeconds(0.1f);

        otherSlots[0].isSelected = false;
        otherSlots[1].isSelected = false;

        float lerpT = 0f;
        while (slotObj.gameObject.GetComponent<Image>().color != corFinal)
        {
            slotObj.GetComponent<Image>().color = Color.Lerp(slotObj.gameObject.GetComponent<Image>().color, corFinal, lerpT);

            lerpT += 0.1f;


            yield return new WaitForSeconds(duration / 10);




        }
    }




}


