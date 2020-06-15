using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float minY, maxY;
    public float distance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            float randomY = Random.Range(minY, maxY);
            Vector2 newPos = new Vector2(transform.position.x + distance, randomY);
            collision.transform.position = newPos;
        }
       
    }
}
