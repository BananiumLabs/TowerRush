using UnityEngine;
using System.Collections;
using System.IO;

public class Controls : MonoBehaviour {

//List of editable controls
public KeyCode Forward;
public KeyCode Back;
public KeyCode Left;
public KeyCode Right;
public KeyCode Jump;
public KeyCode Run;

	StreamReader controlReader;
	StreamWriter controlWriter;
	// Use this for initialization
	void Start () {
		controlReader = new StreamReader("/Controls.cfg");
		controlWriter = new StreamWriter("/Controls.cfg");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	KeyCode GetKey (int id) {
		string test;
		for(int i = 0; i < id; i++) {
			test = controlReader.ReadLine();	
		}
		return (KeyCode)System.Enum.Parse(typeof(KeyCode), controlReader.ReadLine());
	}
	
	void SetKey (int id) {
		
	}
}
