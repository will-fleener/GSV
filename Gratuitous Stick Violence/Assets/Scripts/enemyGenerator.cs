using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{

    public GameObject enemy;
	public GameObject enemy2;
    public GameObject destPoint;
    public Transform generationPoint;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    public float platformWidth;



    // Use this for initialization
    void Start()
    {
        platformWidth = enemy.GetComponent<BoxCollider2D>().size.x;

    }

    // Update is called once per frame
    void Update()
    {
		int num = Random.Range(1,3);
		if (num == 1) {
			if (transform.position.x < generationPoint.position.x)
			{
				distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
				RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + platformWidth + distanceBetween, 10), Vector2.down, 20);
				if (hit)
				{
					transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
					GameObject archibald = Instantiate(enemy, transform.position, transform.rotation);
					PlatformDestroyer platDest = archibald.GetComponent<PlatformDestroyer>();
					platDest.platformDestructionPoint = destPoint;
				}	
			}
		}else{
			if (transform.position.x < generationPoint.position.x)
			{
				print ("enemy2");
				distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
				RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + platformWidth + distanceBetween, 10), Vector2.down, 20);
				if (hit)
				{
					transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
					GameObject archibald = Instantiate(enemy2, transform.position, transform.rotation);
					PlatformDestroyer platDest = archibald.GetComponent<PlatformDestroyer>();
					platDest.platformDestructionPoint = destPoint;
				}	
			}
		}
    }
}
