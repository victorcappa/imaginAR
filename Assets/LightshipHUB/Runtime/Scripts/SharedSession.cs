using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.AR.HitTest;
using Niantic.ARDK.AR.Networking;
using Niantic.ARDK.AR.Networking.ARNetworkingEventArgs;
using Niantic.ARDK.Extensions;
using Niantic.ARDK.Networking;
using Niantic.ARDK.Networking.MultipeerNetworkingEventArgs;
using Niantic.ARDK.Utilities;

using UnityEngine;
using UnityEngine.UI;

namespace Niantic.ARDK.Templates 
{
    public class SharedSession : MonoBehaviour 
    {
        [HideInInspector]
        public Camera _camera = null;
        [HideInInspector]
        public FeaturePreloadManager preloadManager = null;
        [HideInInspector]
        public Button joinButton = null;
        [HideInInspector]
        public InputField InputID;
        [HideInInspector]
        public Text SessionIDText;
        [HideInInspector]
        public IARNetworking _arNetworking;
        [HideInInspector]
        public MessagingManager _messagingManager;
        [HideInInspector]
        public SharedObjectHolder SharedObjectHolder;
        [HideInInspector]
        public ARNetworkingManager _arManager;
        [HideInInspector]
        public IPeer _host;
        [HideInInspector]
        public IPeer _self;
        [HideInInspector]
        public bool _isHost;
        [HideInInspector]
        public bool _isStable;

        private void Start() 
        {
            ARNetworkingFactory.ARNetworkingInitialized += OnAnyARNetworkingSessionInitialized;
            preloadManager.ProgressUpdated += PreloadProgressUpdated;
        }

        private void PreloadProgressUpdated(FeaturePreloadManager.PreloadProgressUpdatedArgs args) 
        {
            if (args.PreloadAttemptFinished) 
            {
                if (args.FailedPreloads.Count > 0) 
                {
                    Debug.LogError("Failed to download resources needed to run AR Multiplayer");
                    return;
                }

                joinButton.interactable = true;
                preloadManager.ProgressUpdated -= PreloadProgressUpdated;
            }
        }

        private void OnPeerStateReceived(PeerStateReceivedArgs args) 
        {
            if (_self.Identifier == args.Peer.Identifier)
                UpdateOwnState(args);
            else
                UpdatePeerState(args);
        }

        private void UpdatePeerState(PeerStateReceivedArgs args) {}

        private void UpdateOwnState(PeerStateReceivedArgs args) 
        {
            Debug.Log(args.State.ToString());
            if (args.State == PeerState.Stable || Application.isEditor) _isStable = true;
        }

        private void OnDidConnect(ConnectedArgs args) 
        {
            _self = args.Self;
            _host = args.Host;
            _isHost = args.IsHost;

            if (_isHost) 
            {
                SharedObjectHolder._messagingManager = _messagingManager;
                SessionIDText.gameObject.SetActive(true);
                SessionIDText.text = "SESSION ID: " + InputID.text;
            }
        }

        private void OnAnyARNetworkingSessionInitialized(AnyARNetworkingInitializedArgs args) 
        {
            _arNetworking = args.ARNetworking;
            _arNetworking.PeerStateReceived += OnPeerStateReceived;
            _arNetworking.Networking.Connected += OnDidConnect;

            _messagingManager = new MessagingManager();
            _messagingManager.InitializeMessagingManager(args.ARNetworking.Networking, this);
        }

        public void Join() {
            _arManager.enabled = true;
        }

        internal void SetObjectPosition(Vector3 position) 
        {
            if (!SharedObjectHolder.gameObject.activeSelf && _isStable) SharedObjectHolder.gameObject.SetActive(true);
            SharedObjectHolder.gameObject.transform.position = position;
        }

        internal void SetObjectScale(Vector3 scale) 
        {
            SharedObjectHolder.gameObject.transform.localScale = scale;
        }
        
        internal void SetObjectRotation(Quaternion quat)
        {
            SharedObjectHolder.gameObject.transform.rotation = quat;
        }

        private void OnDestroy() 
        {
            ARNetworkingFactory.ARNetworkingInitialized -= OnAnyARNetworkingSessionInitialized;

            if (_arNetworking != null) 
            {
                _arNetworking.PeerStateReceived -= OnPeerStateReceived;
                _arNetworking.Networking.Connected -= OnDidConnect;
            }

            if (_messagingManager != null) 
            {
                _messagingManager.Destroy();
                _messagingManager = null;
            }
        }
    }
}
