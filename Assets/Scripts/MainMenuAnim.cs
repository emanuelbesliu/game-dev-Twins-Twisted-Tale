using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAnim : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sp;
    public Button button;
    public LoadLevel load;

    public float Speed = 3f;
    public bool red;
    public bool play;
    public bool walking;
    //private bool sleeping = false;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);

        if(red){
            StartCoroutine(SleepingAnimation());
        }else{
            StartCoroutine(SleepingAnimationGreen());
        }
        //animator.SetBool("Sleep", true);
        //sleeping = true;
    }


    void TaskOnClick(){
        play = true;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        //Debug.Log(h);

        if(play){
            StartCoroutine(WalkingAnimation());
        }

        if(walking){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * Speed;
            transform.position += Vector3.right * Time.deltaTime * Speed ;
            animator.SetFloat("Speed", Mathf.Abs(1));
        }


        if(this.transform.position.x > 30){
            load.LoadNextLevel();
        }
    }


    IEnumerator WalkingAnimation()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("isSleeping", false);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("isSleeping", true);
        play = false;
        yield return new WaitForSeconds(1f);
        if(!red){
            sp.flipX = false;
        }
        walking = true;
    }

    IEnumerator SleepingAnimation()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Sleep", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Sleep", false);
        animator.SetBool("isSleeping", true);
    }

    IEnumerator SleepingAnimationGreen()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("Sleep", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Sleep", false);
        animator.SetBool("isSleeping", true);
    }
}
