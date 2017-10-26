using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public float movespeed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-Vector2.right * movespeed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Player") {
			Destroy (col.gameObject);
		}
	}
}
