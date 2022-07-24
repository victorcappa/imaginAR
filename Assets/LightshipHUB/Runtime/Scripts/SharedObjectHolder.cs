using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Niantic.ARDK.Templates 
{
	public class SharedObjectHolder : MonoBehaviour 
	{	
		[HideInInspector]
		public GameObject Cursor;
		[HideInInspector]
		public MessagingManager _messagingManager;
		[HideInInspector]
		public SharedObjectInteraction ObjectInteraction;
		private Vector3 originalPosition;

		private void Awake() 
		{
			originalPosition = this.transform.position;
			if (Cursor != null) Cursor.SetActive(false);
			this.gameObject.SetActive(false);
		}

		internal void MoveObject(Vector3 position) 
		{
			this.transform.position = position;
			this.transform.Rotate(0.0f, UnityEngine.Random.Range(0.0f, 360.0f), 0.0f);
		}

		private void Update() 
		{
			if (_messagingManager == null) return;

			_messagingManager.BroadcastObjectPosition(this.transform.position);
			_messagingManager.BroadcastObjectScale(this.transform.localScale);
			_messagingManager.BroadcastObjectRotation(this.transform.rotation);
		}
	}
}
