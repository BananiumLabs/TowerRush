using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DarkRift;

public class RoomManagement : MonoBehaviour {

public Text usernameText, ipText, errorText;
public Canvas error;

	// Use this for initialization
	void Start () {
		error.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//When the "Join" button is pressed
	public void LoadLevel() {
		string ip = ipText.text;
		string user = usernameText.text;
        Debug.Log("Attempting to connect to " + ip + " as " + user);
		try {
			DarkRiftAPI.Connect(ip);
		} catch {
			
			errorText.text = "Could not connect to " + ip + ". Please verify that the ip is correct.";
			Debug.LogError(errorText);
			error.enabled = true;
		}
	}

	public void CloseError() {
		error.enabled = false;
	}
}
