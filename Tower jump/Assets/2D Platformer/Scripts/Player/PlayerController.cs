using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;

        public bool canRunFunction = true;

        private bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;

        private bool isGrounded;
        private bool almostGrounded;
        public Transform groundCheck;
        [SerializeField] private float preJumpTime;
        private bool deathJump = true;
        private bool singleJump = false;

        private Rigidbody2D rb;
        private Collider2D coll;
        [HideInInspector]
        public Animator animator;
        [SerializeField] private PlatformSpawner spawner;
        public Transform[] playerSpawn = new Transform[2];
        public GameObject gameOver;

        public GameObject respawn;
        private bool respawnOnce;
        public ScoreManager scoreManager;

        void Start()
        { 
            // Spawn();
            respawnOnce = false;
            // Start
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            coll = GetComponent<BoxCollider2D>();
        }

        void Update()
        {

            if (deathState == false) // if is alive
            {
            
            if (facingRight) 
            {
                Vector3 direction = transform.right;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            } else if (facingRight == false)
            {
                Vector3 direction = transform.right * -1f;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            }

            if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                CheckGround();
                if (isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, 0f);
                    Jump();
                } else if (singleJump == false)
                {
                    StartCoroutine(CheckGroundCoroutine());
                }  
            }

            if (!isGrounded)animator.SetTrigger("IsJumping"); // Turn on jump animation

            if(facingRight == false && moveInput > 0)
            {
                Flip();
            }

            else if(facingRight == true && moveInput < 0)
            {
                Flip();
            }

            animator.SetBool("IsDead", false); // if isAlive

            }
        }

        public void Spawn()
        {
            if (rb == null) {rb = GetComponent<Rigidbody2D>();}
            if (animator == null) {animator = GetComponent<Animator>();}
            if (coll == null) {coll = GetComponent<BoxCollider2D>();}

            // Spawn on opposite side of the starting platform
            if (spawner.startingChunkRight == true)
            {
                transform.position = playerSpawn[0].position;

                // Face right
            } else if (spawner.startingChunkRight == false)
            {
                transform.position = playerSpawn[1].position;
                
                // Face left
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Wall collision
            if (collision.gameObject.tag == "Wall")
            {
            Flip(); // Bounce on contact with wall
            }

            // Spikes collision
            if (collision.gameObject.tag == "Enemy") // Player Die
            {
            if (deathState == false && deathJump == true)
            {
                Jump();
            } 

            if (deathState == false) // if is Alive, Die
            {
            deathState = true;
            animator.SetBool("IsDead", true); // if isDead
            Invoke("Death", 0.35f);   
            }         
            }
        }

        // Flip
        private void Flip()
        {
            if (canRunFunction) // check if knight has flipped in past 0.25 seconds
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;

            canRunFunction = false;
            StartCoroutine(ExecuteFlip(0.25f));

        }
        }

        // Limit one flip per 0.25 seconds
        IEnumerator ExecuteFlip(float time)
        {          
            yield return new WaitForSeconds(time);
            canRunFunction = true;
            yield return null;
        }

        public void CheckGround()
        {
            Vector2 box = new Vector2 (0.5f, 0.2f);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(groundCheck.transform.position, box, 0f);
            isGrounded = colliders.Length > 1;
            // change to make sure that the colliders are platforms
            if (isGrounded)
            {
                singleJump = false;
            }  
        }

        IEnumerator CheckGroundCoroutine()
{
    float elapsedTime = 0f;
    deathJump = false;
    while (elapsedTime < preJumpTime)
    {
        CheckGround();
        if (isGrounded)
        {
            // Perform jump if player touches the ground
            yield return new WaitForSeconds(0.05f);
            Jump();
            yield break;
        }

        elapsedTime += Time.deltaTime;
        yield return null;
    }
    singleJump = true;
    deathJump = true;
    yield break;
}

    // Jump
        public void Jump()
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("IsJumping");
        }

    // Player die
        private void Death()
        {   
            bool respawnBool = false;
            float rand = Random.value;
            // RNG for respawn
            if (scoreManager.score >= scoreManager.highScore/2)
            {
                if (scoreManager.score < scoreManager.highScore/1.25)
                {
                if (rand > 0.5f)
                {
                    respawnBool = true;
                }
                } else if (scoreManager.score > scoreManager.highScore/1.25)
                {
                    if (scoreManager.score > scoreManager.highScore)
                    {
                    if (rand > 0.1f)
                    {
                        respawnBool = true;
                    }
                    } else {
                        respawnBool = true;
                    }
                {
                    respawnBool = true;
                }
                }
            } else 
            {
                if (rand > 0.9f)
                {
                    respawnBool = true;
                }
            }
            if (respawnBool == true && respawnOnce == false) // make chance higher if player is close to highscore
            {
                respawn.SetActive(true);
                respawnOnce = true;
            } else
            {
                gameOver.SetActive(true);
                respawn.SetActive(false);
                respawnOnce = false;
                SaveSystem.SaveData(scoreManager);
            }
        }

    }
}

