using UnityEngine;
using System.Collections;

public class RoomLogic : MonoBehaviour {

	public GameObject netprefab;
	// Use this for initialization
	void Start () {
		GameObject monster = PhotonNetwork.Instantiate("netPlayer", Vector3.zero, Quaternion.identity, 0);

	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
