using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

///Methods for Control changing menu, with integrated InputManager by Ben C. 
public class InputManager : MonoBehaviour {

///List of editable controls
protected KeyCode Forward, Back, Left, Right, Jump, Run, Crouch, Inventory;
public List<KeyCode> controlList;

///Array containing the display names for above keyCodes
public List<string> controlListNames = new List<string> {"Forward", "Back", "Left","Right","Jump","Run", "Crouch", "Inventory"};

///Dynamic path to controls.cfg
public String configPath; 

///Default assigned controls
string[] defaultControls = {"W","S","A","D","Space","LeftShift", "LeftControl", "E"};
string[] axes = {"Vertical","Horizontal"};
protected Event currentEvent;

///Array containing the text displays in controls assign menu
public List<Text> textList = new List<Text> {};
///Text that displays message when in controls assign mode
public Text infoText;


	void Start () {

		configPath = Vars.path + "/controls.cfg";

		try {
			infoText = infoText.GetComponent<Text> (); 
			infoText.enabled = false;
		} catch {
			Debug.LogWarning("InfoText not found for InputManager.");
		}
		

		

		controlList = new List<KeyCode> {Forward, Back, Left, Right, Jump, Run, Crouch, Inventory};

		
		//validate controls file
		if(File.Exists(configPath) && ControlsValid())  
			Debug.Log("Successfully loaded controls file");
		else {
			Debug.Log("Controls file is nonexistent or corrupted. Generating new one...");
			using (var writer = new StreamWriter(File.Create(configPath))) {}
			WriteDefaultControls();
			}	
			
		ReloadControls();

		//find buttons that set controls, and sorts them into an array
		foreach (GameObject txt in GameObject.FindGameObjectsWithTag("SetControlsButton"))
			textList.Add(txt.GetComponent<Text> ());	
		foreach(Text txt in textList) {
			int oldIndex = textList.IndexOf(txt);
			int index = Int32.Parse(txt.name);
			Text buffer = textList[index];
			textList[index] = txt;
			textList[oldIndex] = buffer;
			txt.text = Key(index).ToString();
		}
			
		
	}

	void OnGUI () {
		currentEvent = Event.current;
	}

	///reads key from controls.cfg
	public KeyCode GetKeyInternal (int id) {
		string[] lines = File.ReadAllLines(configPath);
		return (KeyCode)System.Enum.Parse(typeof(KeyCode), lines[id]);
	}
	///Returns boolean- is the key pressed down?
	public bool GetKey (string id) {
		return Input.GetKey(Key(id));
	}

	///Returns true upon downstroke of key
	public bool GetKeyDown (string id) {
		return Input.GetKeyDown(Key(id));
	}
	
	public void WriteDefaultControls () {
		Debug.Log("Writing default controls...");
		File.WriteAllLines(configPath, defaultControls);
		ReloadControls();
	}
	
	private void ReloadControls () {
		for(int i = 0; i < controlList.Count; i++) {
			controlList[i] = GetKeyInternal(i);
		}
	}
	
	protected bool ControlsValid () {
		try {
			ReloadControls();
			return true;
		} catch {
			return false;
		}
	}

	///<summary> Gets the value being outputted by a certain axis </summary>
	public float GetAxis (String axis) {
		if(axis == "Horizontal") {
			if(GetKey("Forward")) return 1;
			else if (GetKey("Back")) return -1;
			else return 0;
		} else if(axis == "Vertical") {
			if(GetKey("Left")) return 1;
			else if (GetKey("Right")) return -1;
			else return 0;
		} else throw new System.ArgumentException("Invalid axis name");
	}

	///<summary> Gets the keycode associated with custom key names </summary>
	public KeyCode Key (String keyName) {
		for(int i = 0; i < controlListNames.Count; i++) {
			if(keyName.Equals(controlListNames[i])) return Key(i);
		}
		throw new System.ArgumentException("Invalid key name");
	}

	///Raw key method that accepts an integer id
	public KeyCode Key (int id) {
		string[] lines = File.ReadAllLines(configPath);
			return (KeyCode)System.Enum.Parse(typeof(KeyCode), lines[id]);
	}

	///Assign this method to buttons in order to change key bindings
	public void SetKey (int id) {
		
			Text buttonText = textList[id];
			Debug.Log("Selecting Key " + id);
			infoText.enabled = true;
			StartCoroutine(WaitForKey(id));
	}

	///While key is being set: Waits for a valid input
	 IEnumerator WaitForKey (int id) {
	
			Text buttonText = textList[id];
			while(true) {
				if(currentEvent != null && (currentEvent.isKey || currentEvent.isMouse)) {
				if (currentEvent.keyCode == KeyCode.Backspace) {
					   buttonText.text = GetKeyInternal(id).ToString();
					   infoText.enabled = false;
					   Debug.Log("Key Selection cancelled");
					  yield break;
				 } else if(currentEvent.keyCode != KeyCode.Backspace && currentEvent.keyCode != KeyCode.None) {
					 buttonText.text = currentEvent.keyCode.ToString();
					 Debug.Log("Key Selection successful");
					 string[] arrLine = File.ReadAllLines(configPath);
     				arrLine[id] = buttonText.text;
     				File.WriteAllLines(configPath, arrLine);
		 			Debug.Log("Set key " + id + " to " + buttonText.text);
					infoText.enabled = false;
					ReloadControls();

					yield break;
				 } else yield return null;
			} else yield return null;
	
			} 
		}
}