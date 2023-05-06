using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public float scoreSize;
    public float score; // player score

    private Transform scoreColl;
    [SerializeField] private ScoreManager scoreManager;

    void Awake()
    {
        // create score collider
        scoreColl = new GameObject().transform;

        // name score collider
        scoreColl.name = "ScoreCollider";

        // add collider
        scoreColl.gameObject.AddComponent<EdgeCollider2D>();

        // Size the collider
        scoreColl.GetComponent<EdgeCollider2D>().transform.localScale = new Vector2(Screen.width/100, 0f);

        // make collider a trigger
        scoreColl.GetComponent<EdgeCollider2D>().isTrigger = true;

        scoreColl.gameObject.AddComponent<ScoreClimb>();

    }

    void Update()
    {
      scoreManager.score = score;       
    }
}
