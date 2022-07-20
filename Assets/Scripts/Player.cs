using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // SerializedField will allow private variable to be accessed in Unity Inspector
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 15f;

    private float movementX;
    private Rigidbody2D playerBody;
    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    public void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    // FixedUpdate is called upon every fixed framerate frame
    // Edit > Project Settings > Time > Fixed Timestep
    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal"); // return -1, 0 & 1 for movement along x cartesian
        
        // movement calculation along x-axis
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        /**
        * Note: 
        * We can change direction of player sprite in accordance with movement
        * to do so, we have 2 method
        * 1. In game object transform scale of x to -1 to face left and 1 to face right
        * 2. In sprite renderer - flipX (bool)
        **/

        if (movementX > 0) {
            // player is moving to the right
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } else if (movementX < 0) {
            // player is moving to the left
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } else {
            // player is not moving
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump() 
    {
        /**
        * - GetButton(): Will return on press of a button (while pressed)
        * - GetButtonUp(): returns on release of a button (once)
        * - GetButtonDown(): returns on press of a button (once) 
        **/
        if(Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            // ForceMode2D.Impulse will push the player upwards
            playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Build in function in Monobehaviour to detect collision between objects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }

        if(collision.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag(ENEMY_TAG)) {
            Destroy(gameObject);
        }
    }
}
