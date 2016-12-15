using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float projectileSpeed;
	private Vector3 translation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		translation = transform.position + new Vector3(0,0,projectileSpeed);
		transform.Translate(translation);
	}
}
