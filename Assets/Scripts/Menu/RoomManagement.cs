using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DarkRift;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManagement : MonoBehaviour {

public Text usernameText, ipText, errorText;
public Canvas error;
protected string autofillPath;
protected string user, ip;

	// Use this for initialization
	void Start () {

		autofillPath = Vars.path + "/autofill.cfg";
		error.enabled = false;

		try {
			ipText.GetComponentInParent<InputField>().text = File.ReadAllLines(autofillPath)[0];
			usernameText.GetComponentInParent<InputField>().text = File.ReadAllLines(autofillPath)[1];
		} catch {
			Debug.LogWarning("autofill.cfg missing or corrupt.");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//When the "Join" button is pressed
	public void LoadLevel() {
		string ip = ipText.text;
		string user = usernameText.text;
		if(ip.Equals("")) ip = "localhost";
		if(user.Equals("")) user = "Player";

		PlayerPrefs.SetString("Username", user);
		using (var writer = new StreamWriter(File.Create(autofillPath))) {
			writer.WriteLine(ip);
			writer.WriteLine(user);
			Debug.Log("Successfully wrote autofill.cfg");
		};

        Debug.Log("Attempting to connect to " + ip + " as " + user);
		try {
			DarkRiftAPI.Connect(ip);

            SceneManager.LoadScene("TestMap");
		} catch {
			
			errorText.text = "Could not connect to " + ip + ". Please verify that the ip is correct.";
			Debug.LogError(errorText.text);
			error.enabled = true;
		}
	}

	public void CloseError() {
		error.enabled = false;
	}
}
