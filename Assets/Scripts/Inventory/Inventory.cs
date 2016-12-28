using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour {

public List<Button> InvSlots;
public List<Item> items;
public Item selectedItem;
public bool itemSelected = false;

	// Use this for initialization
	void Start () {
		//find inventory slot buttons, and sorts them into a List
		foreach (GameObject slot in GameObject.FindGameObjectsWithTag("InventorySlot"))
			InvSlots.Add(slot.GetComponent<Button> ());	
		foreach(Button slot in InvSlots) {
			int oldIndex = InvSlots.IndexOf(slot);
			int index = Int32.Parse(slot.name);
			Button buffer = InvSlots[index];
			InvSlots[index] = slot;
			InvSlots[oldIndex] = buffer;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
