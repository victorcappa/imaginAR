using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    

    public GameObject maisMenosObj, canvasObj;
    bool maisAbriu;

    public AudioClip minusPlus, plusMinus, apertaBtn;

    public SlotItem[] slotsUI;
    public GameObject[] itemMenu;


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
    if (slotsUI[0].isSelected)
    {
      slotsUI[1].isSelected = false;
      slotsUI[2].isSelected = false;

    }

    if (slotsUI[1].isSelected)
    {
      slotsUI[0].isSelected = false;
      slotsUI[2].isSelected = false;
    }

    if (slotsUI[2].isSelected)
    {
      slotsUI[0].isSelected = false;
      slotsUI[1].isSelected = false;
    }
    for (int i = 0; i < slotsUI.Length - 1; i++)
    {
      Debug.Log("VERIFICA SLOT" + i + slotsUI[i].isSelected);
       if (slotsUI[i].isFull == true || slotsUI[i].isSelected == false ) return;

      if (slotsUI[i].isFull == false && slotsUI[i].isSelected == true )
      {

        slotsUI[i].itemSlotObj = Instantiate(itemMenu, slotsUI[i].gameObject.transform.position, itemMenu.gameObject.transform.rotation);
        slotsUI[i].itemSlotObj.transform.parent = slotsUI[i].gameObject.transform;
        slotsUI[i].itemSlotObj.transform.localScale = new Vector3 (80,80,80);
        slotsUI[i].isFull = true;
      }
    }
  }

    
}
