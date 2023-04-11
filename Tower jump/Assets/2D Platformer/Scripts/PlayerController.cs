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
        private Animator animator;
        [SerializeField] private PlatformSpawner spawner;
        public Transform[] playerSpawn = new Transform[2];
        public GameObject gameOver;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            coll = GetComponent<BoxCollider2D>();

            // Spawn on opposite side of the starting platform
            if (spawner.chunkRight == true)
            {
                transform.position = playerSpawn[0].position;
            } else if (spawner.chunkRight == false)
            {
                transform.position = playerSpawn[1].position;
                Flip();
            }
        }

        void Update()
        {

            if (deathState == false) // if is alive
            {
            
            if (facingRight) 
            {
                Vector3 direction = transform.right;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetFloat("Speed", Mathf.Abs(moveInput)); // Turn on run animation
            } else if (facingRight == false)
            {
                Vector3 direction = transform.right * -1f;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetFloat("Speed", Mathf.Abs(moveInput)); // Turn on run animation   
            }

            if(Input.GetMouseButtonDown(0))
            {
                CheckGround();
                if (isGrounded)
                {
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

            deathState = true;
            animator.SetBool("IsDead", true); // if isDead
            Invoke("Death", 0.35f);            
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
    while (elapsedTime < 0.25f)
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
        }

        private void Death()
        {
            gameOver.SetActive(true);
        }

    }
}

