using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public float movespeed;
    public float distanceBeforeAttack = 1;

    private Transform _player;
    private bool attacking = false;

	// Use this for initialization
	void Awake () {
        _player = GameObject.FindGameObjectWithTag("Player").transform;

    }
	
	// Update is called once per frame
	void Update () {
        if(Vector3.Distance(transform.position, _player.position) <= distanceBeforeAttack && !attacking)
        {
            //TODO kick off attack animation
            print("enemy attack animation");
        }

	}

    void Die()
    {
        //death animation
        print("enemy die animation");
        Destroy(gameObject);
    }
}
