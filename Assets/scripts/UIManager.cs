using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    

    public GameObject maisMenosObj, canvasObj;
    bool maisAbriu;

    public AudioClip minusPlus, plusMinus, apertaBtn;

    public SlotItem[] slotsUI; // slot onde se guarda os itens
    //public GameObject[] itemMenu; // itens do meu, para escolher e guardar nos slots

    public SlotItem slotUI;

    public GameObject menuObj;


    public void MaisMenosAnim()
  {
    if (maisAbriu == false)
    {
      maisMenosObj.GetComponent<Animator>().Play("plusMinus");
      canvasObj.GetComponent<Animator>().Play("abreMenu");
          maisMenosObj.GetComponent<Animator>().Play(stateName: "clica.apertaMais");
                    this.gameObject.GetComponent<AudioSource>().PlayOneShot(clip: plusMinus);



      StartCoroutine(EsperaAbreMenu());
    }
    if (maisAbriu == true)
    {
      maisMenosObj.GetComponent<Animator>().Play("minusPlus");
            canvasObj.GetComponent<Animator>().Play("fechaMenu");
          maisMenosObj.GetComponent<Animator>().Play(stateName: "clica.apertaMenos");
          this.gameObject.GetComponent<AudioSource>().PlayOneShot(clip: minusPlus);

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
    maisAbriu = true;
  }

   IEnumerator EsperaFechaMenu()
  {
    yield return new WaitForSeconds(.1f);
    maisAbriu = false;
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
            slotUI.iconeItemSlot.GetComponent<Rigidbody>().detectCollisions = false;
      }

    }

    public void AbreMenu()
    {
        if (slotUI != null)
        {

            if (slotUI.isSelected == true && slotUI.isFull == false)
            {
                menuObj.SetActive(true);

            }

            if (slotUI.isFull == true && slotUI.isSelected == true)
            {
                menuObj.SetActive(true);

            }
        }

    }

    public void FechaMenu()
    {
        menuObj.SetActive(false);
    }


}
