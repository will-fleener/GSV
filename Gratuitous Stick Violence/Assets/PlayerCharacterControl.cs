using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterControl : MonoBehaviour {
    public float moveForce = 300f;
    public float maxSpeed = 1f;
    public float jumpForce = 100f;

    private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = Vector3.right * maxSpeed;

        float v = Input.GetAxis("Vertical");
        if (v * rb.velocity.y < maxSpeed)
        {
            rb.AddForce(Vector2.up *v * jumpForce);
        }
        
	}
}
