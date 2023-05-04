using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

public class EdgeCollider : MonoBehaviour
 {
    public float colDepth = 4f;
    public float zPosition = 0f;
    private Vector2 screenSize;
    private Transform topCollider;
    private Transform bottomCollider;
    private Transform leftCollider;
    private Transform rightCollider;
    private Vector3 cameraPos;
    public GameObject player;
    public Transform camStart;
    public PlayerController playerController;
    public float camPanSpeed;
    
    // Use this for initialization
    void Start () {
    //Generate our empty objects
        rightCollider = new GameObject().transform;
        leftCollider = new GameObject().transform;
 
    //Name our objects 
        rightCollider.name = "RightCollider";
        leftCollider.name = "LeftCollider";

    //Tag our objects

        rightCollider.tag = "Wall";
        leftCollider.tag = "Wall";  
       
    //Add the colliders
        rightCollider.gameObject.AddComponent<BoxCollider2D>();
        leftCollider.gameObject.AddComponent<BoxCollider2D>();

    //Make them triggers

        //rightCollider.GetComponent<BoxCollider2D>().isTrigger = true;
        //leftCollider.GetComponent<BoxCollider2D>().isTrigger = true;
       
    //Make them the child of whatever object this script is on, preferably on the Camera so the objects move with the camera without extra scripting
        rightCollider.parent = transform;
        leftCollider.parent = transform;
           
    //Generate world space point information for position and scale calculations
        cameraPos = Camera.main.transform.position;
        screenSize.x = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)),Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)),Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height*10))) * 0.5f;
       
    //Change our scale and positions to match the edges of the screen...   
        rightCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
        rightCollider.position = new Vector3(cameraPos.x + screenSize.x + (rightCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
        leftCollider.localScale = new Vector3(colDepth, screenSize.y * 2, colDepth);
        leftCollider.position = new Vector3(cameraPos.x - screenSize.x - (leftCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
    }

    // Camera follow player
    void LateUpdate()
    {
        if (playerController.deathState == false && player.transform.position.y <= camStart.position.y) // Camera in start position
        {
            transform.position = camStart.position;
        }
    if (playerController.deathState == false && player.transform.position.y > camStart.position.y) // camera follow player
        {
            transform.position = new Vector3 (transform.position.x, player.transform.position.y, transform.position.z);
        } else if (playerController.deathState == true && transform.position.y > camStart.position.y) // camera pan down
        {   
            transform.position -= new Vector3 (0, camPanSpeed * Time.deltaTime, 0);
        }

    }
 }
