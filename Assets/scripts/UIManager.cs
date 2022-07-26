using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    

    public GameObject maisMenosObj, canvasObj;

    bool maisBtnAbriu; // verifica se o btn + foi pressionado, mostrando os slots

    public AudioClip minusPlus, plusMinus, apertaBtn;

    public SlotItem[] slotsUI; // slot onde se guarda os itens
    //public GameObject[] itemMenu; // itens do meu, para escolher e guardar nos slots

    public SlotItem slotUI;

    public GameObject menuObj;

    public bool ferramentaUI, objUI;

    public bool menuAberto;



    private void Awake()
    {
        ferramentaUI = true;
    }

    public void MaisMenosAnim()
  {
        if (maisBtnAbriu == false)
    {
      maisMenosObj.GetComponent<Animator>().Play("plusMinus");
      canvasObj.GetComponent<Animator>().Play("abreMenu");
            maisMenosObj.GetComponent<Animator>().Play(stateName: "clica.apertaMais");
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(clip: plusMinus);

            ferramentaUI = false;
            objUI = true;

            MostraSlots();

            if (slotUI != null && slotUI.iconeItemSlot != null)
            {
                slotUI.iconeItemSlot.SetActive(value: true);

            }







            StartCoroutine(EsperaAbreMenu());
    }
        if (maisBtnAbriu == true)
    {
      maisMenosObj.GetComponent<Animator>().Play("minusPlus");
            canvasObj.GetComponent<Animator>().Play("fechaMenu");
          maisMenosObj.GetComponent<Animator>().Play(stateName: "clica.apertaMenos");
          this.gameObject.GetComponent<AudioSource>().PlayOneShot(clip: minusPlus);

            ferramentaUI = true;
            objUI = false;

            EscondeSlots();

            if (slotUI != null && slotUI.iconeItemSlot != null)
            {
                slotUI.iconeItemSlot.SetActive(value: false);

            }

            StartCoroutine(EsperaFechaMenu());
    }
  }

  public void ApertaBtn()
  {
              this.gameObject.GetComponent<AudioSource>().PlayOneShot(clip: apertaBtn);

  }

  IEnumerator EsperaAbreMenu()
  {
    yield return new WaitForSeconds(.1f);
        maisBtnAbriu = true;
  }

   IEnumerator EsperaFechaMenu()
  {
    yield return new WaitForSeconds(.1f);
        maisBtnAbriu = false;
  }


  public void VerificaSlots(GameObject itemMenu)
  {



    if (slotUI.isFull == true || slotUI.isSelected == false ) 
       
       return;

      if (slotUI.isFull == false && slotUI.isSelected == true )
      {

            slotUI.iconeItemSlot = Instantiate(itemMenu, slotUI.gameObject.transform.position, itemMenu.gameObject.transform.rotation);
            slotUI.ItensManager.itemSlotSelecionado = slotUI.iconeItemSlot.GetComponent<ItemMenu>().objPrefab;
            slotUI.iconeItemSlot.transform.parent = slotUI.gameObject.transform;
            slotUI.iconeItemSlot.transform.localScale = new Vector3(80, 80, 80);
            slotUI.isFull = true;
        slotUI.isSelected = true;
            //slotUI.iconeItemSlot.GetComponent<Rigidbody>().detectCollisions = false;
        }

    }

    public void AbreMenu()
    {
        StartCoroutine(MenuAguardaNovoItem());

    }

    IEnumerator MenuAguardaNovoItem()
    {
        yield return new WaitForSeconds(.07f);

        if (slotUI != null)
        {

            if (slotUI.isSelected == true && slotUI.isFull == false)
            {
                menuObj.SetActive(true);
                menuAberto = true;


            }

            if (slotUI.isFull == true && slotUI.isSelected == true)
            {
                menuObj.SetActive(true);
                menuAberto = true;



            }
        }

    }

    public void FechaMenu()
    {
        menuObj.SetActive(false);
        menuAberto = false;

    }


    public void MostraSlots()
    {

        Color fadeOut = new Color(255, 255, 255, 0f);
        Color fadeIn = new Color(255, 255, 255, .2f);


        for (int i = 0; i <= slotsUI.Length - 1; i++)
        {
            StartCoroutine(FadeIn(slotsUI[i], 1f, .2f));


        }



    }

    public void EscondeSlots()
    {

        Color fadeOut = new Color(255, 255, 255, 0f);
        Color fadeIn = new Color(255, 255, 255, .4f);




        for (int i = 0; i <= slotsUI.Length - 1; i++)
        {
            // slotsUI[i].GetComponent<Image>().color = Color.Lerp(fadeIn, fadeOut, time / duration);
            // time += Time.deltaTime;

            StartCoroutine(FadeOut(slotsUI[i], .7f, 0f));


        }





    }

    IEnumerator FadeOut(SlotItem slotItem, float duration, float alphaFinal)
    {
        float alpha = slotItem.GetComponent<Image>().color.a;

        while (slotItem.GetComponent<Image>().color.a > alphaFinal)
        {
            slotItem.GetComponent<Image>().color = new Color(255, 255, 255, a: alpha);

            alpha -= 0.1f;



            yield return new WaitForSeconds(duration / 10);




        }
    }
    IEnumerator FadeIn(SlotItem slotItem, float duration, float alphaFinal)
    {
        float alpha = slotItem.GetComponent<Image>().color.a;

        while (slotItem.GetComponent<Image>().color.a < alphaFinal)
        {
            slotItem.GetComponent<Image>().color = new Color(255, 255, 255, a: alpha);

            alpha += 0.1f;


            yield return new WaitForSeconds(duration / 10);




        }
    }



}
