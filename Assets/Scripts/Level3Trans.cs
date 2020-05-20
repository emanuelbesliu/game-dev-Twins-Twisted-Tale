using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Trans : MonoBehaviour
{
    public LoadLevel loadlevel;

    public GameObject green;
    public GameObject red;

    public GameObject redSprite;

    public GameObject greenD;
    public GameObject redD;

    public Animator greenAnimator;
    public Animator redAnimator;

    public bool runGreen;
    public bool runRed;

    private bool greenRunInitial;

    public float Speed = 5f;
    public int step;
    // Start is called before the first frame update
    void Start()
    {
        green.GetComponentInParent<MovementPlatformer>().canMove = false;
        StartCoroutine(InitialSpeech());
    }

    // Update is called once per frame
    void Update()
    {
        if(greenRunInitial){
            green.transform.position += Vector3.right * Time.deltaTime * Speed ;
            greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
        }

        if(green.transform.position.x >= -24f){
            greenRunInitial = false;
            greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(0));
        }

        if(red.transform.position.y > 15.3){
            runRed = false;
            red.SetActive(false);
        }

        if(green.transform.position.y > 5.5){
            runGreen = false;
            loadlevel.LoadNextLevel();
        }

        if(runRed){
            if(red.transform.position.x < 14f){
                red.transform.position += Vector3.right * Time.deltaTime * Speed;
                redAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
            }else{
                red.transform.position += Vector3.up * Time.deltaTime * Speed;
                redAnimator.SetBool("isWalking", true);
                redAnimator.SetBool("Climb", false);
            }
        }

        if(runGreen){
            if(green.transform.position.x < -1.7f){
                green.transform.position += Vector3.right * Time.deltaTime * Speed;
                greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
            }else{
                green.transform.position += Vector3.up * Time.deltaTime * Speed;
                greenAnimator.SetBool("isWalking", true);
                greenAnimator.SetBool("Climb", false);
            }
        }
    }

    IEnumerator InitialSpeech()
    {
        greenRunInitial = true;
        redD.SetActive(true);
        if(step == 0)
            yield return new WaitForSeconds(6f);
       // if(redSprite.transform.localScale.x > 0)
        // redSprite.transform.localScale = new Vector3(redSprite.transform.localScale.x * (-1), redSprite.transform.localScale.y, redSprite.transform.localScale.z);
        redD.SetActive(false);
        runRed = true;
        StartCoroutine(SecondSpeech());
    }

    IEnumerator SecondSpeech()
    {
        yield return new WaitForSeconds(3f);
        greenD.SetActive(true);
        yield return new WaitForSeconds(5f);
        greenD.SetActive(false);
        runGreen = true;
    }
}
