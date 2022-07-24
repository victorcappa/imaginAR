using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

using Niantic.ARDK.AR;
using Niantic.ARDK.Utilities;
using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.AR.HitTest;
using Niantic.ARDK.Utilities.Input.Legacy;

namespace Niantic.ARDK.Templates 
{
    public class InteractionController : MonoBehaviour
    {
        [HideInInspector]
        public ObjectHolderController OHcontroller;
        
        public bool MultipleInstances;
        public float TriggerDistance = 1.5f;

        void Update() 
        {
            if (PlatformAgnosticInput.touchCount <= 0) return;

            var touch = PlatformAgnosticInput.GetTouch(0);
            if (touch.phase == TouchPhase.Began) 
            {
                TouchBegan(touch);
            }
        }  

        private void TouchBegan(Touch touch) 
        {
            var currentFrame = OHcontroller.Session.CurrentFrame;
            if (currentFrame == null) return;

            if (OHcontroller.Camera == null) return;

            if (CheckHit(touch)) return; 

            var hitTestResults = currentFrame.HitTest (
                OHcontroller.Camera.pixelWidth, 
                OHcontroller.Camera.pixelHeight, 
                touch.position, 
                ARHitTestResultType.EstimatedHorizontalPlane
            );

            if (hitTestResults.Count <= 0) return;

            var position = hitTestResults[0].WorldTransform.ToPosition();

            GameObject obj;
            if (MultipleInstances) 
            {
                obj = Instantiate(OHcontroller.ObjectHolder, this.transform);
                obj.SetActive(true);
            } 
            else 
            {
                obj = OHcontroller.ObjectHolder;
            }

            obj.SetActive(true);
            obj.transform.position = position;
            obj.transform.Rotate(0.0f, UnityEngine.Random.Range(0.0f, 360.0f), 0.0f);
        }

        bool CheckHit(Touch touch) 
        {
            var worldRay = OHcontroller.Camera.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(worldRay, out hit, 1000f)) 
            {
                ObjectAnimation objAnimation =  hit.transform.parent.GetComponent<ObjectAnimation>();
                if (objAnimation != null) 
                {
                    return true;
                }
            }
            return false;
        }
    } 
} 
