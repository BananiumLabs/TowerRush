using UnityEngine;
using System;
using System.IO;
public class Pl_InputManager : MonoBehaviour {

//List of editable controls
public KeyCode Forward; //1
public KeyCode Back; //2
public KeyCode Left; //3
public KeyCode Right; //4
public KeyCode Jump; //5
public KeyCode Run; //6

private KeyCode[] controlList;

private String configPath = "Assets/Main Menu/Scripts/controls.cfg";
string[] defaultControls = {"W","S","A","D","Space","LeftShift"};

Event currentEvent;
	// Use this for initialization
	void Start () {
		controlList = new KeyCode[] {Forward, Back, Left, Right, Jump, Run};
		
			if(File.Exists(configPath) && ControlsValid())  {
				ReloadControls();
			} else {
			Debug.Log("Controls file is nonexistent or corrupted. Generating new one...");
			using (var writer = new StreamWriter(File.Create(configPath))) {}
			WriteDefaultControls();
			ReloadControls();
		}	
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {
        
	}
	
	public KeyCode GetKey (int id) {
		string[] lines = File.ReadAllLines(configPath);
		return (KeyCode)System.Enum.Parse(typeof(KeyCode), lines[id-1]);
	}
	
	public void WriteDefaultControls () {
		Debug.Log("Writing default controls...");
		File.WriteAllLines(configPath, defaultControls);
		ReloadControls();
	}
	
	public void ReloadControls () {
		for(int i = 0; i < controlList.Length; i++) {
			controlList[i] = GetKey(i+1);
		}
		
		Debug.Log("Successfully reloaded controls");
	}
	
	private bool ControlsValid () {
		try {
			ReloadControls();
			return true;
		} catch {
			return false;
		}
	}
}
