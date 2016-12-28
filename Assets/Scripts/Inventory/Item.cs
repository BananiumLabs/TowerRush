using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

public int id, slot;
public bool selected = false;
protected Vector3 mousePosition;

[SerializeField]
protected Inventory inv;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
		if(selected) {
			mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = mousePosition;
		}
	}
}
