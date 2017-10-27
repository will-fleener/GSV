using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterControl : MonoBehaviour {
    public float speed = 1f;
    public float jumpForce = 100f;
    public float attackSpeed = 3f;
    public float distanceOfAttack = 2;

    private Transform _groundCheck;
    private bool _grounded;
    private bool _notAttacking = true;
    private bool _attack = false;
    private Rigidbody2D rb;
    private bool _jump = false;
    private Vector2 _touchOrigin = -Vector2.one;
    private float initialXPos;



    void Start () {
        rb = GetComponent<Rigidbody2D>();
        _groundCheck = transform.Find("groundCheck");
    }

    private void Update()
    {
        _grounded = Physics2D.Linecast(transform.position, _groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        

        if (Input.GetAxis("Vertical") > 0 && _grounded && _notAttacking)
        {
            _jump = true;
        }

        if (Input.GetAxis("Horizontal") > 0 && _notAttacking){
            _attack = true;
            _notAttacking = false;
           
        }
       

    }


    void FixedUpdate () {

        if (_notAttacking)
        {
            rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(attackSpeed, rb.velocity.y, 0);
            if (_attack)
            {
                StartCoroutine(Dash());
                _attack = false;
            }
        }

        if (_jump){
            rb.velocity = new Vector3(rb.velocity.x, 1 * jumpForce, 0);
            _jump = false;
        }
        
        
        
	}

    public IEnumerator Dash()
    {
        initialXPos = rb.position.x;
        yield return new WaitUntil(() => rb.position.x - initialXPos >= distanceOfAttack);
        _notAttacking = true;
    }
}
