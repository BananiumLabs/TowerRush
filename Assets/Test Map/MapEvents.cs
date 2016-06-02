using UnityEngine;
using System.Collections;

//SUMMARY: Manages the Test Map
public class MapEvents : MonoBehaviour {

	public Transform leftDoorGold;
	public Transform rightDoorGold;
	public Transform leftDoorBlue;
	public Transform rightDoorBlue;


	void Start () {
		
		leftDoorGold = leftDoorGold.GetComponent<Transform> ();
		rightDoorGold = rightDoorGold.GetComponent<Transform> ();
		leftDoorBlue = leftDoorBlue.GetComponent<Transform> ();
		rightDoorBlue = rightDoorBlue.GetComponent<Transform> ();
	}

	void Update () {
		
	}
		
}