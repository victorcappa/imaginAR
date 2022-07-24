using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.AR;
using Niantic.ARDK.AR.Awareness;
using Niantic.ARDK.AR.Awareness.Depth;
using Niantic.ARDK.AR.Configuration;
using Niantic.ARDK.Extensions;

namespace Niantic.ARDK.Templates 
{
    public class DepthTextureController : MonoBehaviour 
    {
        [HideInInspector]
        public ARDepthManager DepthManager;
        public bool ShowDepthTexture;

        void Update() 
        {
            DepthManager.ToggleDebugVisualization(ShowDepthTexture);
        }
    }
}
