using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreClimb : MonoBehaviour
{
private ScoreCounter scoreCounter;

void Start()
{
    scoreCounter = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>(); // add script
    Setup();
}

public void Setup()
{
    // Set starting position
    transform.position = new Vector2(0f, scoreCounter.scoreSize);
}

public void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Player")
    {
        scoreCounter.score++; // add 1 to the score
        transform.position = new Vector2(transform.position.x, transform.position.y + scoreCounter.scoreSize);
    }
}
}
