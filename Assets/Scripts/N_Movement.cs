using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkRift;


public class N_Movement : MonoBehaviour {

    public ushort networkID;
    public bool isMine;

    
    //public GameObject playerObject;

	// Use this for initialization
	void Start () {
        if (isMine)
        {

            gameObject.GetComponent<MouseLock>().enabled = true;
            gameObject.GetComponent<MouseLook>().enabled = true;
            gameObject.GetComponent<Pl_Controller>().enabled = true;
            gameObject.GetComponent<InputManager>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
