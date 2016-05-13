using UnityEngine;
using System.Collections;

//SUMMARY: Manages the Test Map
public class MapEvents : MonoBehaviour {

	public Transform player;

	public Transform leftDoor;
	public Transform rightDoor;
	public Transform fallDetector;
	public Vector3 spawn;
	public bool playerdebug;

	void Start () {
		player = player.GetComponent<Transform> ();
		leftDoor = leftDoor.GetComponent<Transform> ();
		rightDoor = rightDoor.GetComponent<Transform> ();
		fallDetector = fallDetector.GetComponent<Transform> ();
		spawn.Set (0, 1, 139);
	}

	void Update () {
		
		//fall detection
		if (!Physics.Raycast (player.transform.position, Vector3.down, 2000f)) {
			player.transform.position = spawn;
		}
	}
		
}