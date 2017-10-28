using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float movespeed;
    public float distanceBeforeAttack = 8;

    private Transform _player;
    private bool attacking = false;
    private Animator _archibaldAnim;
    private Collider2D _archibaldCol;
    private Rigidbody2D _archibaldRB;

    // Use this for initialization
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _archibaldAnim = this.GetComponent<Animator>();
        _archibaldCol = this.GetComponent<Collider2D>();
        _archibaldRB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) <= distanceBeforeAttack && !attacking)
        {
            //TODO kick off attack animation
            print("enemy attack animation");
            _archibaldAnim.SetTrigger("Attack");
        }

    }

    public void Die()
    {
        //death animation
        print("enemy die animation");
        //Physics2D.IgnoreCollision(_archibaldCol, _player.GetComponent<Collider2D>());
        _archibaldCol.enabled = false;
        _archibaldRB.isKinematic = true; ;
        _archibaldRB.velocity = Vector2.zero;

        //_archibaldAnim.SetTrigger("Get Shanked");
        _archibaldAnim.Play("archibald_ded");
        StartCoroutine(DoubleDie());
    }

    private IEnumerator DoubleDie()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}