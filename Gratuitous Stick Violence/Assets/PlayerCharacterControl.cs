using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterControl : MonoBehaviour {
    public float moveForce = 300f;
    public float speed = 1f;
    public float jumpForce = 100f;

    private Transform groundCheck;
    private bool _grounded;
    private Rigidbody2D rb;
    private bool jump = false;


	void Start () {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("groundCheck");
    }

    private void Update()
    {
        _grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetAxis("Vertical") > 0 && _grounded)
        {
            jump = true;
        }
    }


    void FixedUpdate () {
        rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0) ;
        float v = Input.GetAxis("Vertical");
        if (jump){
            rb.velocity = new Vector3(rb.velocity.x, 1 * jumpForce, 0);
            jump = false;
        }
        
        
        
	}
}
