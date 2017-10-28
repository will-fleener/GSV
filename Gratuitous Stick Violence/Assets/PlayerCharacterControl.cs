using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterControl : MonoBehaviour {
    public float speed = 1f;
    public float jumpForce = 100f;
    public float attackSpeed = 3f;
    public float distanceOfAttack = 3;

    private Transform _groundCheck;
    private bool _grounded;
    private bool _notAttacking = true;
    private bool _attack = false;
    private Rigidbody2D rb;
    private bool _jump = false;
    private Vector2 _touchOrigin = -Vector2.one;
    private float initialXPos;
    private Vector2 touchOrigin = -Vector2.one;
    private Animator _playerAnim;


    void Start () {
        rb = GetComponent<Rigidbody2D>();
        _playerAnim = this.GetComponent<Animator>();
        _groundCheck = transform.Find("groundCheck");
    }

    private void Update()
    {
        _grounded = Physics2D.Linecast(transform.position, _groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

    #if UNITY_STANDALONE || UNITY_EDITOR

        if (Input.GetAxis("Vertical") > 0 && _grounded && _notAttacking)
        {
            _jump = true;
        }

        //if ((Input.GetButtonDown("Dash") || Input.GetAxis("Horizontal") > 0) && _notAttacking){
        if ((Input.GetButtonDown("Dash")) && _notAttacking)
            {
                //_playerAnim.SetTrigger("attack");
                _playerAnim.Play("player_attack");
            _attack = true;
            _notAttacking = false;
           
        }

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        
            if (Input.touchCount > 0)
            {
                Touch myTouch = Input.touches[0];
                
                if (myTouch.phase == TouchPhase.Began)
                {
                    touchOrigin = myTouch.position;
                }
                
                else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
                {
                    Vector2 touchEnd = myTouch.position;
                    float x = touchEnd.x - touchOrigin.x;
                    float y = touchEnd.y - touchOrigin.y;
                    touchOrigin.x = -1;

                    if (Mathf.Abs(x) > Mathf.Abs(y) && x > 0 && _notAttacking)
                    {
                        _attack = true;
                        _notAttacking = false;
                    }
                    else if(Mathf.Abs(x) < Mathf.Abs(y) && _grounded && _notAttacking)
                    {
                        _jump = true;
                    }
                }
            }
        
#endif


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

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Enemy")
        {
            
            if (!_notAttacking)
            {
                print("murdering");
                //col.gameObject.SendMessage("Die");
                enemy archibald = col.gameObject.GetComponent<enemy>();
                archibald.Die();
                updateScore(50);//TODO
            } else
            {
                gameOver(); //TODO
            }
        }
    }


    public IEnumerator Dash()
    {
        initialXPos = transform.position.x;
        //yield return new WaitUntil(() => transform.position.x - initialXPos >= distanceOfAttack);
        yield return new WaitForSeconds(1f);
        _notAttacking = true;
    }

    public void gameOver()
    {
        //TODO
        print("player die animation");
    }

    void updateScore(int score)
    {

    }
}
