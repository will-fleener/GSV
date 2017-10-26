using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterControl : MonoBehaviour {
    public float moveForce = 300f;
    public float speed = 1f;
    public float jumpForce = 100f;

    private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0) ;
        float v = Input.GetAxis("Vertical");
        if (v > 0){
            rb.velocity = new Vector3(rb.velocity.x, 1 * jumpForce, 0);
        }
        
        
        
	}
}
