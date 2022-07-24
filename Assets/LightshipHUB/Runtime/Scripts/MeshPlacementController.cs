using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if (UNITY_EDITOR)
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

using Niantic.ARDK.AR;
using Niantic.ARDK.Utilities;
using Niantic.ARDK.AR.HitTest;
using Niantic.ARDK.Extensions.Meshing;
using Niantic.ARDK.Utilities.Input.Legacy;

namespace Niantic.ARDK.Templates 
{
    public class MeshPlacementController : MonoBehaviour 
    {
        [HideInInspector]
        public ObjectHolderController OHcontroller;

        void Update() 
        {
            if (PlatformAgnosticInput.touchCount <= 0) { return; }
    
            var touch = PlatformAgnosticInput.GetTouch(0);
            if (touch.phase == TouchPhase.Began) 
            {
                var currentFrame = OHcontroller.Session.CurrentFrame;
                if (currentFrame == null) return;

                if (OHcontroller.Camera == null) return;

                var worldRay = OHcontroller.Camera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(worldRay, out hit, 1000f)) 
                {
                    if (hit.transform.gameObject.name.Contains("MeshCollider") || 
                        hit.transform.gameObject.name.Contains("ROOM_") ||
                        hit.transform.gameObject.name.Contains("EXTERIOR_"))
                    {
                        GameObject obj = Instantiate(OHcontroller.ObjectHolder, this.transform);
                        obj.SetActive(true);
                        obj.transform.position = hit.point;
                        obj.GetComponent<ObjectAnimation>().Scale();
                        Vector3 plane = Vector3.ProjectOnPlane(Vector3.forward+Vector3.right,hit.normal);
                        Quaternion rotation = Quaternion.LookRotation(plane,hit.normal);
                        obj.transform.rotation = rotation;
                        obj.transform.Rotate(0.0f, Random.Range(0.0f, 360.0f), 0.0f, Space.Self);
                    }
                }
            }
        }    
    }
}
