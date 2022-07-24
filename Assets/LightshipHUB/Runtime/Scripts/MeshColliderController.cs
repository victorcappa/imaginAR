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

using Lean.Touch;

using Lean;

namespace Niantic.ARDK.Templates 
{
    public class MeshColliderController : MonoBehaviour 
    {
        [HideInInspector]
        public ObjectHolderController OHcontroller;
        public GameObject ARCamera;

        GameObject obj;
        RaycastHit hit;
        Ray ray ;

        GameObject sphereManager;

        private void Awake() {
            //sphereManager = Instantiate(this.gameObject, this.gameObject.transform);
        }

    
        void Update() 
        {
         

            
             if (PlatformAgnosticInput.touchCount <= 0) { return; }

    
            var touch = PlatformAgnosticInput.GetTouch(0);
            ray = ARCamera.GetComponent<Camera>().ScreenPointToRay(touch.position);
            // Debug.Log(ray.ToString());

            if (touch.phase == TouchPhase.Began && !touch.IsTouchOverUIObject()) // && PlayerPrefs.GetString("start") == "true") 
            {
                //GameObject obj = Instantiate(OHcontroller.ObjectHolder, this.transform);
                //obj.SetActive(true);
          


             if(Physics.Raycast(ray,out hit))
             { 
                
                // Vector3 posicaoFinal = new Vector3 (ray.direction.x, ray.direction.y ,ray.direction.z);
                Vector3 posicaoFinal = new Vector3 (ray.direction.x, ray.direction.y ,ray.direction.z);
                //Vector3 posicaoInicial = new Vector3 (ray.direction.x, ARCamera.transform.position.y, ARCamera.transform.position.z);



               // obj = Instantiate(OHcontroller.ObjectHolder,posicaoFinal, transform.rotation);
               Quaternion objRot = new Quaternion(0f,0f,0f,0f);
               obj = Instantiate(OHcontroller.ObjectHolder, ARCamera.transform);

                obj.SetActive(true);
                //Vector3 entrancePoint = OHcontroller.Camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, OHcontroller.Camera.nearClipPlane));

    
               // obj.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, this.transform.position.z));
                //obj.transform.position = (entrancePoint );
                     
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.angularVelocity = new Vector3(0f, 0f, 0f);
    
                float force = 500.0f;

                rb.AddForce(posicaoFinal * force);
                
                //           Debug.Log("POSICAO DE TOQUE" + touch.position);
                //                           Debug.Log("HIT POINT" + hit.point);

                // Debug.Log("POSICAO OBJ" + obj.transform.position);

                // Debug.Log("POSICAO FINAL" + posicaoFinal);
                //  //Debug.Log("ENTRANCE POINT" + entrancePoint);

          //  }
               
                               
    


       
            }
            }
        }


            // if (PlatformAgnosticInput.touchCount <= 0) { return; }
    
            // var touch = PlatformAgnosticInput.GetTouch(0);

            // if (touch.phase == TouchPhase.Began && !touch.IsTouchOverUIObject() ) 
            // {              
      
               
    
               
               
            //            Vector3 entrancePoint = ARCamera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, OHcontroller.Camera.nearClipPlane)) ;
                
            //                     GameObject obj = Instantiate(original: OHcontroller.ObjectHolder, entrancePoint, this.transform.rotation);

            //     obj.SetActive(true);
                
            //     Rigidbody rb = obj.GetComponent<Rigidbody>();
            //     rb.velocity = new Vector3(0f, 0f, 0f);
            //     rb.angularVelocity = new Vector3(0f, 0f, 0f);
    
            //     obj.transform.rotation = Quaternion.Euler(new Vector3(0f, 0.0f, 0.0f));
            //     obj.transform.position = entrancePoint;
    
            //     float force = 500.0f;
            //     rb.AddForce(OHcontroller.Camera.transform.forward * force);

            //     Debug.Log("POSICAO DE TOQUE" + touch.position);
            //     Debug.Log("POSICAO OBJ" + obj.transform.position);
            //      Debug.Log("ENTRANCE POINT" + entrancePoint);

            // }
        

        // public void MachineGun()
        // {                        var touch = PlatformAgnosticInput.GetTouch(0);

        //     if(touch.phase == TouchPhase.Began && !touch.IsTouchOverUIObject() )
        //     {

        //                 if (touch.phase == TouchPhase.Ended) return;
                        

        //         GameObject obj = Instantiate(OHcontroller.ObjectHolder, this.transform);
        //         obj.SetActive(true);
    

        //         Vector3 entrancePoint = OHcontroller.Camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, OHcontroller.Camera.nearClipPlane));
        //         Rigidbody rb = obj.GetComponent<Rigidbody>();
        //         rb.velocity = new Vector3(0f, 0f, 0f);
        //         rb.angularVelocity = new Vector3(0f, 0f, 0f);
    
        //         obj.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
        //         obj.transform.position = entrancePoint;
    
        //         float force = 400.0f;
        //         rb.AddForce(OHcontroller.Camera.transform.forward * force);

        //     }
               
                        

            
        // }

    }
}
