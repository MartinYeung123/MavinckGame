using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {		
		public Transform playTransform;  
		private Vector3 offset;     
	
	void Start () {
		
			offset = transform.position - playTransform.position;
	}
	
	void Update () {
		 
		transform.position = playTransform.position + offset;
	}
}
