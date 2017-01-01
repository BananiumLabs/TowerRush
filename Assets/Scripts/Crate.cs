using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Logic attached to every crate object
public class Crate : MonoBehaviour {

	public Vars.Team team;
	public List<Item> items;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		
			if(col.gameObject.tag == "BluePlayer" || col.gameObject.tag == "GoldPlayer") {
				GiveItems(col.gameObject);
				Object.Destroy(gameObject);
				Debug.Log(gameObject.name + "Received by" + col.gameObject.name);
			}
			
	}

	void GiveItems(GameObject player) {

	}
}
