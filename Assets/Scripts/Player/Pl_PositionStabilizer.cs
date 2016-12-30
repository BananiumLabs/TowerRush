using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Fixes bug where player drifts from camera
public class Pl_PositionStabilizer : MonoBehaviour {

Vector3 position;

	// Sets position to optimal position of player
	void Start () {
		position = transform.localPosition;
	}
	
	// If player has drifted, reset its position relative to container prefab
	void Update () {
		if(!transform.localPosition.Equals(position))
			transform.localPosition = position;
	}
}
