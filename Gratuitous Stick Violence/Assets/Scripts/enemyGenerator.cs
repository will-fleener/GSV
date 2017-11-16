using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGenerator : MonoBehaviour
{

    public GameObject enemy;
    public GameObject destPoint;
    public Transform generationPoint;
    public float distanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private float platformWidth;



    // Use this for initialization
    void Start()
    {
        platformWidth = enemy.GetComponent<BoxCollider2D>().size.x;

    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
