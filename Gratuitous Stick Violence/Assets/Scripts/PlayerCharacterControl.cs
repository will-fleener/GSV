using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacterControl : MonoBehaviour
{
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
    private float initialXPos;
    private Vector2 touchOrigin = -Vector2.one;
    public int _score;
    private Animator _playerAnim;

    private AudioSource jumpSound;
    private AudioSource attackSound;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        _playerAnim = this.GetComponent<Animator>();
        _groundCheck = transform.Find("groundCheck");

        var audioSources = GetComponents<AudioSource>();
        jumpSound = audioSources[1];
        attackSound = audioSources[0]; ;
    }

    private void Update()
    {
        _grounded = Physics2D.Linecast(transform.position, _groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        _score = (int)transform.position.x;

        if (transform.position.y <= -10)
        {
            gameOver();
        }
#if UNITY_STANDALONE || UNITY_EDITOR

        if (Input.GetAxis("Vertical") > 0 && _grounded && _notAttacking)
        {
            _jump = true;
            jumpSound.Play();
        }

        //if ((Input.GetButtonDown("Dash") || Input.GetAxis("Horizontal") > 0) && _notAttacking){
        if ((Input.GetButtonDown("Dash")) && _notAttacking)
        {
            //_playerAnim.SetTrigger("attack");
            _playerAnim.Play("player_attack");
            _attack = true;
            _notAttacking = false;
            attackSound.Play();

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
        //Swipe up detection to jump
                    //else if(Mathf.Abs(x) < Mathf.Abs(y) && _grounded && _notAttacking)
                    //{
                    //    _jump = true;
                    //}
                    else if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0 && _grounded && _notAttacking)
                    {
                        _jump = true;
                    }
                } 
            }
        
#endif


    }


    void FixedUpdate()
    {

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

        if (_jump)
        {
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
                _score += 50;
                updateScore(_score);
            }
            else
            {
                gameOver();
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
        print("Score: " + _score);
        updateScore(_score);
        setHighScore(_score);
        SceneManager.LoadScene("Scoreboard", LoadSceneMode.Single);
        print("player die animation");
    }

    void updateScore(int score)
    {

    }

    private void setHighScore(int score)
    {
        print(PlayerPrefs.HasKey("highScore"));
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (PlayerPrefs.GetInt("highScore") < _score)
            {
                print("Current Highscore " + (PlayerPrefs.GetInt("highScore")));
                PlayerPrefs.SetInt("highScore", _score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", _score);
            PlayerPrefs.Save();
        }
    }
}
