using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomLogic : MonoBehaviour {

    public GameObject[] rspawn;
    public GameObject[] bspawn;
	private string playerTeam;
    private Button gold;
    private Button blue;
    //private Transform playerTransform;
    private ButtonActions buttons;
    public Vars.Team team;
    void Start () {
        PhotonView photonView = PhotonView.Get(this);
        gold = GameObject.Find("Gold").GetComponent<Button>();
        blue = GameObject.Find("Blue").GetComponent<Button>();
        //playerTransform = GetComponentInParent<Transform> ();
        buttons = GameObject.Find("RoomGui").GetComponent<ButtonActions>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void joinBlue()
    {
        Debug.Log("JOINING BLUE");
        PhotonView photonView = PhotonView.Get(this);
        //playerTransform.position = Vars.testMapBlue;
        team = Vars.Team.blue;
        buttons.CloseTeamSelect();
        photonView.RPC("SpawnPlayerB", PhotonTargets.AllBuffered);
       
    }

    public void joinGold()
    {
        Debug.Log("JOINING GOLD");
        PhotonView photonView = PhotonView.Get(this);
        //playerTransform.position = Vars.testMapGold;
        team = Vars.Team.gold;
        buttons.CloseTeamSelect();
        photonView.RPC("SpawnPlayerG", PhotonTargets.AllBuffered);
        
    }

    [PunRPC]
    public void SpawnPlayerG() {
        Debug.Log("Player Connected Gold");

		GameObject player = PhotonNetwork.Instantiate("testPlayer", Vars.testMapGold, Quaternion.identity, 0);
    }

    [PunRPC]
    public void SpawnPlayerB()
    {
        Debug.Log("Player Connected Blue");

        GameObject player = PhotonNetwork.Instantiate("testPlayer", Vars.testMapBlue, Quaternion.identity, 0);
    }

}
