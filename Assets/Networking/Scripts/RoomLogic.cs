using UnityEngine;
using System.Collections;

public class RoomLogic : MonoBehaviour {

    public GameObject[] rspawn;
    public GameObject[] bspawn;
	private string playerTeam;


	void Start () {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("SpawnPlayer", PhotonTargets.AllBuffered, playerTeam);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    [PunRPC]
    public void SpawnPlayer(string team) {
        Debug.Log("Player Connected");
		//GameObject player = PhotonNetwork.Instantiate("test2", Vars.testMapBlue, Quaternion.identity, 0);
		//For testing purposes
		GameObject player = PhotonNetwork.Instantiate("testPlayer", Vars.testMapBlue, Quaternion.identity, 0);
    }

}
