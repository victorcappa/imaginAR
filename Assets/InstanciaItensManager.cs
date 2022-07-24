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

   void Update() 
        {
         
         // verifica se tocou e onde
         // verifica se o slot está cheio ou apenas selecionado
         // instancia o objeto do slot

            
             if (PlatformAgnosticInput.touchCount <= 0) { return; }

if (slotSelecionado != null)
{

 var touch = PlatformAgnosticInput.GetTouch(0);
            ray = ARCamera.GetComponent<Camera>().ScreenPointToRay(touch.position);

            if (touch.phase == TouchPhase.Began && !touch.IsTouchOverUIObject()) 
            {
              
        
             if(Physics.Raycast(ray,out hit))
             { 
                
                Vector3 posicaoFinal = new Vector3 (ray.direction.x, ray.direction.y ,ray.direction.z);
                Vector3 posicaoInicial = new Vector3 (ray.direction.x, ARCamera.transform.position.y, ARCamera.transform.position.z);


                if (slotSelecionado.isFull == true && slotSelecionado.isSelected == true)
                {
                    Debug.Log(slotSelecionado.itemSlotObj.name);
                // obj = Instantiate(OHcontroller.ObjectHolder,posicaoFinal, transform.rotation);
               Quaternion objRot = new Quaternion(0f,0f,0f,0f);
               obj = Instantiate(itemSlotSelecionado);

               obj.transform.localScale = new Vector3(0.3f,0.3f,0.3f);

                obj.SetActive(true);
       
                     
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.angularVelocity = new Vector3(0f, 0f, 0f);


    
                float force = 200.0f;

                rb.AddForce(posicaoFinal * force);
                Debug.Log("LOG INSTANCIA" + slotSelecionado.name + slotSelecionado.isFull + slotSelecionado.isSelected );
                }

                
               

                               
    


       
            }
            }
}
    
           
        }

}
