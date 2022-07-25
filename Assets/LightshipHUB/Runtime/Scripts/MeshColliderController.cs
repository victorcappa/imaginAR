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

        UIManager UIManager;

        private void Awake()
        {

            UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        }



        void Update() 
        {


            if (UIManager.ferramentaUI == true)
            {
                if (PlatformAgnosticInput.touchCount <= 0) { return; }

                var touch = PlatformAgnosticInput.GetTouch(0);
                ray = ARCamera.GetComponent<Camera>().ScreenPointToRay(touch.position);

                if (touch.phase == TouchPhase.Began && !touch.IsTouchOverUIObject()) // && PlayerPrefs.GetString("start") == "true") 
                {

                    if (Physics.Raycast(ray, out hit))
                    {

                        Vector3 posicaoFinal = new Vector3(ray.direction.x, ray.direction.y, ray.direction.z);

                        // Quaternion objRot = new Quaternion(0f, 0f, 0f, 0f);
                        obj = Instantiate(OHcontroller.ObjectHolder, ARCamera.transform);

                        obj.SetActive(true);


                        Rigidbody rb = obj.GetComponent<Rigidbody>();
                        rb.velocity = new Vector3(0f, 0f, 0f);
                        rb.angularVelocity = new Vector3(0f, 0f, 0f);

                        float force = 500.0f;

                        rb.AddForce(posicaoFinal * force);

                    }
                }
            }

        }




    }
}
