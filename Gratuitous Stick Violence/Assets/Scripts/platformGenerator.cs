using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private float platformWidth;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;
	
	public GameObject[] thePlatforms;
	private int selectedPlatform;
 

	// Use this for initialization
	void Start () {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
		
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x){
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
			heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            
			if(heightChange > maxHeight){
				heightChange = maxHeight;
			}else if(heightChange < minHeight){
				heightChange = minHeight;
			}
			
			selectedPlatform = Random.Range(0, thePlatforms.Length);
		
			transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, heightChange, transform.position.z);
            Instantiate(thePlatforms[selectedPlatform], transform.position, transform.rotation);
        }
	}
}
