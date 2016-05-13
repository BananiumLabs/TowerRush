using UnityEngine;
using System.Collections;

public class MapEvents : MonoBehaviour {

	public Transform player;

	public Transform leftDoor;
	public Transform rightDoor;
	public Transform fallDetector;
	public Vector3 spawn;
	public bool playerdebug;
	// Use this for initialization
	void Start () {
		player = player.GetComponent<Transform> ();
		leftDoor = leftDoor.GetComponent<Transform> ();
		rightDoor = rightDoor.GetComponent<Transform> ();
		fallDetector = fallDetector.GetComponent<Transform> ();
		spawn.Set (0, 1, 139);
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerDetected (fallDetector, 20f)) {
			player.transform.position = spawn;
		}

		playerdebug = PlayerDetected (fallDetector, 20f);
	}	

	bool PlayerDetected (Transform transform, float distance) {
		return Vector3.Distance (transform.position, player.position) < distance;
	}
}
