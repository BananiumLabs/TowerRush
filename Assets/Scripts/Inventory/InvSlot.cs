using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

///Button action for inventory slot
public class InvSlot : MonoBehaviour {

	public int id;
	public Item currentItem;
	public Inventory inv;
	public bool hasItem;

	// Use this for initialization
	void Start () {
		id = Int32.Parse(GetComponent<GameObject>().name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	///Selects a method from below to run 
	public void ClickAction () {
		if(inv.itemSelected && !hasItem) PutDownItem();
		else if(inv.itemSelected && hasItem) SwapItem();
		else if(!inv.itemSelected && hasItem) SelectItem();
	}


	///When no items are selected and there is an item in the slot
	void SelectItem () {
		inv.itemSelected = true;
		currentItem = inv.selectedItem;
		currentItem.selected = true;
		hasItem = false;
	}

	///When an item is selected and there are no items in the slot
	void PutDownItem() {
		inv.itemSelected = false;
		currentItem = inv.selectedItem;
		inv.selectedItem.transform.position = transform.position;
		currentItem.selected = false;
		hasItem = true;
	}

	///When item is selected and there is an item in the slot
	void SwapItem() {
		Item buffer = inv.selectedItem;
		SelectItem();
		currentItem = buffer;
		buffer.transform.position = transform.position;
	}
}
