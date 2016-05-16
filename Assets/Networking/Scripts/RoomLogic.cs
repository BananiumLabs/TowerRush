using UnityEngine;
using System.Collections;

public class RoomLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("SpawnPlayer", PhotonTargets.AllBuffered);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    [PunRPC]
    public void SpawnPlayer() {
        Debug.Log("Player Connected");
        GameObject player = PhotonNetwork.Instantiate("testPlayer", Vector3.zero, Quaternion.identity, 0);
        //GameObject player = PhotonNetwork.Instantiate("testPlayer", Vector3.zero, Quaternion.identity, 0);
    }

}
