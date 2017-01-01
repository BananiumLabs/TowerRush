using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Fixes bug where player drifts from camera
public class Pl_PositionStabilizer : MonoBehaviour {

Vector3 correctPosition;
Quaternion correctRotation;

	// Sets position to optimal position of player
	void Start () {
		correctPosition = transform.localPosition;
		correctRotation = transform.localRotation;
	}
	
	// If player has drifted, reset its position relative to container prefab
	void Update () {
		if(!transform.localPosition.Equals(correctPosition)) {
			transform.localPosition = correctPosition;
			transform.localRotation = correctRotation;
		}
			
	}
}
