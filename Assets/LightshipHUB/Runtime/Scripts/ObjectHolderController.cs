using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Niantic.ARDK.AR;
using Niantic.ARDK.AR.ARSessionEventArgs;

namespace Niantic.ARDK.Templates 
{
    public class ObjectHolderController : MonoBehaviour
    {
        [HideInInspector]
        public GameObject ObjectHolder;
        [HideInInspector]
        public GameObject Cursor;
        [HideInInspector]
        public Camera Camera;

        private IARSession _session;
        public IARSession Session {
            get {return _session;}
        }

        void Start() 
        {
            ARSessionFactory.SessionInitialized += OnSessionInitialized;
            if (Cursor != null) Cursor.SetActive(false);
            ObjectHolder.SetActive(false);
        }

        private void OnSessionInitialized(AnyARSessionInitializedArgs args) 
        {
            ARSessionFactory.SessionInitialized -= OnSessionInitialized;
            _session = args.Session;
        }
    } 
}  
