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

    public GameObject decisionLevel0;
    public GameObject[] bearSpeech;
    public GameObject cherry;

    public Camera secondCamera;
    public Camera defaultCamera;

    private int speechIndex = 0;
    private bool continueSpeech = false;

    private float oldfieldofview;
    private Vector3 oldposition;
    public float panSteps = 0.5f;
    private float currentStep;

    public Level1 scriptL1;

    public Collision coll;

    public bool canMove = false;
    public bool wallGrab = false;

    public float speed = 10f;
    public float wallLerp = 10f;
    public bool ladderCollision = false;
    public bool ladder2Collision = false;

    private bool side = true;
    private bool infoSign = false;
    private int cameraCount = 0;
   // public Timer levelTimer;

    public bool isLeft = false;

    private Vector3 respawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        oldposition = defaultCamera.transform.position;
        oldfieldofview = defaultCamera.fieldOfView;
        canMove = false;
        //rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;
        coll = GetComponentInParent<Collision>();
    }

    // Update is called once per frame
    void Update()
    {
        // TIMER TIMINGS
       // if (levelTimer != null) levelTimer.isTimerWorking = ove;


        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        /*if(x != 0){
            rigidbody.kinematic = false;
        }else{
            rigidbody.kinematic = true;
        }*/

        if(transform.position.x > 28f){
            try { level.LoadNextLevel(); }
            catch { //Debug.Log("No Level");
                    }
        }

        if(transform.position.y < - 26){
           // Debug.Log("Here");
            this.transform.position = respawnPosition;
        }

        // Adding bool to check which way the player is facing.

        Vector2 direction =  new Vector2(x, y);
        if (x > 0 )
        {
            isLeft = false;

        }
        else if (x < 0)
        {
            isLeft = true;
        }

        Walk(direction);

        if (canMove)
            anim.SetHorizontalMovement(x, y, rb.velocity.y);

        if(ladder2Collision){
            rb.gravityScale = 3;
            platform.SetActive(true);
            //animator.SetBool("isWalking", false);
            //animator.SetBool("Climb", false);
        }
        // Ghita: Commented this to fix bug.

        if(platform.activeSelf && Input.GetButton("Down") && ladderCollision){
            rb.gravityScale = 0;
            platform.SetActive(false);
            // Ghita: Commented this to fix bug.
            //ladderCollision = true;
        }


        if (ladderCollision && Input.GetButton("Up")){
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(rb.velocity.x, direction.y * speed)), wallLerp * Time.deltaTime);
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.gravityScale = 1;
            animator.SetBool("isWalking", true);
            animator.SetBool("Climb", false);
        }

        if(ladderCollision && Input.GetButton("Down") && !coll.onGround && canMove){
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(rb.velocity.x, direction.y * speed)), wallLerp * Time.deltaTime);
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.gravityScale = 0;
            animator.SetBool("isWalking", true);
            animator.SetBool("Climb", false);
        }

        /*if(ladderCollision && (!Input.GetButton("Down") && !Input.GetButton("Up"))){
            animator.SetBool("isWalking", false);
            if(coll.onGround) animator.SetBool("Climb", false);
           //Debug.Log("AICI");
        }*/


        if(infoSign && Input.GetButtonDown("Info")){
            if(SceneManager.GetActiveScene().name == "Level0"){
                if(speechIndex == 1 && !continueSpeech){
                    return;
                }
                if(firstBear.activeSelf == true){
                    firstBear.SetActive(false);
                    speechIndex = 0;
                    bearSpeech[0].SetActive(true);
                }else{
                    if(speechIndex == bearSpeech.Length -1){
                        return;
                        //speechIndex = -1;
                        //bearSpeech[bearSpeech.Length-1].SetActive(false);
                    }else{
                        if(speechIndex >= 0)
                            bearSpeech[speechIndex].SetActive(false);
                    }
                    speechIndex ++;
                    if(speechIndex == 1 && !continueSpeech){
                        decisionLevel0.SetActive(true);
                        info.SetActive(false);
                    }
                    bearSpeech[speechIndex].SetActive(true);
                }
            }
           //Debug.Log("AICI");
        }
        if (decisionLevel0 != null) {
            if (decisionLevel0.activeSelf)
            {
                if (infoSign && Input.GetButtonDown("Yes"))
                {
                    continueSpeech = true;
                    cherry.SetActive(true);
                    speechIndex++;
                    bearSpeech[speechIndex - 1].SetActive(false);
                    bearSpeech[speechIndex].SetActive(true);
                    decisionLevel0.SetActive(false);
                    info.SetActive(true);
                }

                if (Input.GetButtonDown("No"))
                {
                    decisionLevel0.SetActive(false);
                    info.SetActive(true);
                }
            }
        }

        /*if(!ladderCollision && (Input.GetButton("Down") || Input.GetButton("Up"))){
            animator.SetBool("isWalking", false);
            animator.SetBool("Climb", false);
        }*/

        if(!Input.GetButton("Down") && !Input.GetButton("Up")){

                if (!coll.onGround)
                {
                    rb.velocity = new Vector2(0, rb.velocity.y);
                    animator.SetBool("Climb", true);
                    animator.SetBool("isWalking", false);
                }
                else
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("Climb", false);
                }

           // animator.Stop("idle-green");
        }else{
            if(coll.onGround && !Input.GetButton("Up")){
                animator.SetBool("isWalking", false);
                animator.SetBool("Climb", false);
            }

            if(coll.onGround && Input.GetButton("Up") && ladder2Collision){
                animator.SetBool("isWalking", false);
                animator.SetBool("Climb", false);
            }

            if(coll.onGround && Input.GetButton("Down") && ladderCollision){
                animator.SetBool("isWalking", false);
                animator.SetBool("Climb", false);
            }
        }

        if ((x < 0 || x > 0) && canMove)
        {
            if(x > 0)   side = true;
            if(x < 0)   side = false;
           // Debug.Log("Aici");
            anim.Flip(side);
        }

    }

    void Walk(Vector2 dir){
        if(!canMove || (this.gameObject.transform.position.x < -25f && dir.x < 0))
            return;
        rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallLerp * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            //Debug.Log("aici");
            ladderCollision = true;
            //defaultCamera.transform.position = Vector3.Lerp(secondCamera.transform.position, oldposition, panSteps);
            //defaultCamera.GetComponent<Camera>().fieldOfView = Mathf.Lerp(secondCamera.fieldOfView, oldfieldofview,  panSteps);
            if (!continueSpeech)
                firstBear.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Ladder2"))
        {
            ladder2Collision = true;
            //Debug.Log("Hit");
            //defaultCamera.transform.position = Vector3.Lerp(oldposition, secondCamera.transform.position, panSteps);
            //defaultCamera.GetComponent<Camera>().fieldOfView = Mathf.Lerp(oldfieldofview, secondCamera.fieldOfView,  panSteps);
        }
        else if (collision.gameObject.CompareTag("INFO"))
        {
            info.SetActive(true);
            infoSign = true;
        }
        else if (collision.gameObject.CompareTag("Camera"))
        {
            if (cameraCount == 0)
            {
                cameraCount++;
                currentStep += Time.deltaTime;
                defaultCamera.transform.position = Vector3.Lerp(oldposition, secondCamera.transform.position, currentStep / panSteps);
                defaultCamera.fieldOfView = Mathf.Lerp(oldfieldofview, secondCamera.fieldOfView, currentStep / panSteps);
            }
            else if (cameraCount == 1)
            {
                cameraCount = 0;
                currentStep += Time.deltaTime;
                defaultCamera.transform.position = Vector3.Lerp(defaultCamera.transform.position, oldposition, currentStep / panSteps);
                defaultCamera.fieldOfView = Mathf.Lerp(defaultCamera.fieldOfView, oldfieldofview, currentStep / panSteps);
            }
        }
        else if (collision.gameObject.CompareTag("Collect"))
        {

        }else if(collision.gameObject.CompareTag("Enemy")){
            //Debug.Log("Attack");
            if(!collision.gameObject.GetComponent<Animator>().GetBool("Stop")){
                collision.gameObject.GetComponent<Animator>().SetTrigger("Attack");
                this.transform.position = respawnPosition;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision) {

        if (SceneManager.GetActiveScene().name == "Level1-2G" || SceneManager.GetActiveScene().name == "Level1-2L&N")
        { // Trigger for level 1.2.
            canMove = true;
        }
        if (SceneManager.GetActiveScene().name == "Level1-3G" || SceneManager.GetActiveScene().name == "Level1-3L&N")
        { // Trigger for level 1.3
            canMove = true;
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
        }else if(collision.gameObject.CompareTag("Stop")){
                if (SceneManager.GetActiveScene().name == "Level1-1"){
                scriptL1.endRunRed = false;
                scriptL1.animatorGreen.SetFloat("HorizontalAxis", Mathf.Abs(0));
                canMove = true;
            }

            respawnPosition = this.transform.position;
        }
    }
}
