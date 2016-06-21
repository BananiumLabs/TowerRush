using UnityEngine;
using System.Collections;

public class NetworkProp : Photon.MonoBehaviour {

    public MouseLook mousex;
    public MouseLook mousey;

    public Camera camplayer;
    public PlayerController controllerScript;

    // Use this for initialization
    void Awake () {
        mousex = GetComponentInChildren<MouseLook>();
        camplayer = GetComponentInChildren<Camera>();
        controllerScript = GetComponentInChildren<PlayerController>();

        if (photonView.isMine)
        {
            //MINE: local player, simply enable the local scripts
            mousex.enabled = true;
            mousey.enabled = true;
            camplayer.enabled = true;
            controllerScript.enabled = true;
            gameObject.name = PhotonNetwork.playerName;
        }
        else
        {
            mousex.enabled = false;
            mousey.enabled = false;
            camplayer.enabled = false;
            controllerScript.enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
