using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if (UNITY_EDITOR)
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

using Niantic.ARDK.AR;
using Niantic.ARDK.Utilities;
using Niantic.ARDK.Extensions.Meshing;
using Niantic.ARDK.Utilities.Input.Legacy;
using Niantic.ARDK.Templates;
public class InstanciaItensManager : MonoBehaviour
{
    [HideInInspector]
        public ObjectHolderController OHcontroller;
        public GameObject ARCamera;

        GameObject obj;
        RaycastHit hit;
        Ray ray ;

        public GameObject itemSlotSelecionado;

        public SlotItem slotSelecionado;

    UIManager UIManager;

    private void Awake()
    {
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {

        if (UIManager.objUI == true)
        {

            if (PlatformAgnosticInput.touchCount <= 0) { return; }
            var touch = PlatformAgnosticInput.GetTouch(0);

            if (slotSelecionado != null)
            {
                ray = ARCamera.GetComponent<Camera>().ScreenPointToRay(touch.position);

                if (touch.phase == TouchPhase.Began && !touch.IsTouchOverUIObject())
                {


                    if (Physics.Raycast(ray, out hit))
                    {

                        Debug.Log(hit.collider.gameObject.layer);



                        if (slotSelecionado.isFull == true && slotSelecionado.isSelected == true)

                        {

                            if (hit.collider.gameObject.GetComponent<Rigidbody>() != null)
                            {
                                return;
                            }
                            else if (hit.collider.gameObject.GetComponent<Rigidbody>() == null)
                            {

                                itemSlotSelecionado = slotSelecionado.iconeItemSlot.GetComponent<ItemMenu>().objPrefab;


                                StartCoroutine(routine: SaiDaCamera());




                            }




                        }







                    }
                }


                if (slotSelecionado.isSelected == true && slotSelecionado.isFull == false && !touch.IsTouchOverUIObject())
                {
                    UIManager.menuObj.SetActive(false);
                    slotSelecionado.isSelected = false;

                }

            }
        }






    }

    IEnumerator SaiDaCamera()
    {
        Vector3 posicaoFinal = new Vector3(ray.direction.x, ray.direction.y, ray.direction.z);
        float force = 50.0f;



        obj = Instantiate(itemSlotSelecionado, ARCamera.transform);
        obj.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.velocity = posicaoFinal; //new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, 0f, 0f);

        obj.SetActive(true);

        rb.AddForce(posicaoFinal * force);

        yield return new WaitForSeconds(.5f);
        ARCamera.transform.DetachChildren();


    }



}
