using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhotonConnection : MonoBehaviour {
    [Header("Photon")]
    public string versionNumber = "v1.1";
    public int port = 5055;

    [Header("Connection State")]
    public Text connectionText;

    [Header("Player Info")]
    public Text playerfield;
    public GameObject playerPanel;
    private string plname;

    [Header("Menu UI")]
    public GameObject roomPanel;

    private string connectionState = "";
	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings(versionNumber);
 
    }
	
	// Update is called once per frame
	void Update () {
        connectionText.text = PhotonNetwork.connectionState.ToString();
    }

    public void createRoom()
    {
        Debug.Log("Creating Room");
        PhotonNetwork.CreateRoom("Room 1");
        PhotonNetwork.JoinRoom("Room 1");
        
    }

    public void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.playerName);
		Application.LoadLevel ("TestNetLVL");
    }

    public void playerFieldname()
    {
        PhotonNetwork.playerName = playerfield.text;
        playerPanel.SetActive(false);
        roomPanel.SetActive(true);

    }
}
