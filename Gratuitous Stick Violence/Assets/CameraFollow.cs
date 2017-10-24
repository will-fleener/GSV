using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    Transform playerCharacter;
    private Vector3 offset;
 
    void Start () {
		playerCharacter = GameObject.FindGameObjectWithTag("Player").transform;

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - playerCharacter.transform.position;
    }
	
	void LateUpdate () {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = playerCharacter.transform.position + offset;
    }
}
