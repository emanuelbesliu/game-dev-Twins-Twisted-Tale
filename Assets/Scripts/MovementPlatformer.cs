using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MovementPlatformer : MonoBehaviour
{
    public Animations anim;
    public Animator animator;
    public Rigidbody2D rb;
    public SpriteRenderer sp;
    public GameObject platform;
    public Sprite climb;
    public GameObject info;
    public GameObject firstBear;
    public LoadLevel level;

    private Collision coll;

    public bool canMove = false;
    public bool wallGrab = false;

    public float speed = 10f;
    public float wallLerp = 10f;
    public bool ladderCollision = false;
    public bool ladder2Collision = false;

    private bool side = true;
    private bool infoSign = false;
    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        //rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;
        coll = GetComponentInParent<Collision>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        /*if(x != 0){
            rigidbody.kinematic = false;
        }else{
            rigidbody.kinematic = true;
        }*/

        if(transform.position.x > 28f){
            level.LoadNextLevel();
        }

        Vector2 direction =  new Vector2(x, y);

        Walk(direction);

        if (canMove)
            anim.SetHorizontalMovement(x, y, rb.velocity.y);

        if(ladder2Collision){
            rb.gravityScale = 3;
            platform.SetActive(true);
        }

        if(platform.activeSelf && Input.GetButton("Down")){
            rb.gravityScale = 0;
            platform.SetActive(false);
            ladderCollision = true;
        }

        if(ladderCollision && Input.GetButton("Up")){
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(rb.velocity.x, direction.y * speed)), wallLerp * Time.deltaTime);
            animator.SetBool("isWalking", true);
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.gravityScale = 0;
        }

        if(ladderCollision && Input.GetButton("Down")){
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(rb.velocity.x, direction.y * speed)), wallLerp * Time.deltaTime);
            animator.SetBool("isWalking", true);
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.gravityScale = 0;
        }

        if(ladderCollision && (!Input.GetButton("Down") && !Input.GetButton("Up"))){
            animator.SetBool("isWalking", false);
            if(coll.onGround) animator.SetBool("Climb", false);
           //Debug.Log("AICI");
        }


        if(infoSign && Input.GetButton("Info")){
            if(SceneManager.GetActiveScene().name == "Level0"){
                Debug.Log("Level0");
            }
           //Debug.Log("AICI");
        }

        if(!ladderCollision && (Input.GetButton("Down") || Input.GetButton("Up"))){
            animator.SetBool("isWalking", false);
        }

        if(!coll.onGround){
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Climb", true);
           // animator.Stop("idle-green");
        }else{
            animator.SetBool("isWalking", false);
            animator.SetBool("Climb", false);
        }

        if ((x < 0 || x > 0) && canMove)
        {
            if(x > 0)   side = true;
            if(x < 0)   side = false;

            anim.Flip(side);
        }

    }

    void Walk(Vector2 dir){
        if(!canMove)
            return;
        rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallLerp * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            //Debug.Log("aici");
            ladderCollision = true;
            firstBear.SetActive(true);
        }else if (collision.gameObject.CompareTag("Ladder2"))
        {
            ladder2Collision = true;
        }else if(collision.gameObject.CompareTag("INFO")){
            info.SetActive(true);
            infoSign = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            ladderCollision = false;
        }else if (collision.gameObject.CompareTag("Ladder2"))
        {
            ladder2Collision = false;
        }else if(collision.gameObject.CompareTag("INFO")){
            info.SetActive(false);
            infoSign = false;
        }
    }
}
