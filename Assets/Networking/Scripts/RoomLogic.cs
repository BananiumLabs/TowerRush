using UnityEngine;
using System.Collections;

public class RoomLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject player = PhotonNetwork.Instantiate("testPlayer", Vector3.zero, Quaternion.identity, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPhotonPlayerConnected() {
        Debug.Log("Player Connected");
        //GameObject player = PhotonNetwork.Instantiate("testPlayer", Vector3.zero, Quaternion.identity, 0);
    }

}
