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

	void OnTriggerEnter(Collision col) {
		Debug.Log("COLLIDE");
			if(col.gameObject.tag == "BluePlayer" || col.gameObject.tag == "GoldPlayer") {
				GiveItems(col.gameObject);
				Object.Destroy(gameObject);
			}
			
	}

	void GiveItems(GameObject player) {

	}
}
