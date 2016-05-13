using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhotonConnection : MonoBehaviour {
    [Header("Photon")]
    public string versionNumber = "v1.1";
    public int port = 5055;

    [Header("Connection State")]
    public Text connectionText;

    private string connectionState = "";
	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings(versionNumber);
 
    }
	
	// Update is called once per frame
	void Update () {
        connectionText.text = PhotonNetwork.connectionState.ToString();
    }
}
