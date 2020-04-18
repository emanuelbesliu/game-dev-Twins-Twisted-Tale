using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Level0Trans : MonoBehaviour
{
    public CameraController script;
    public MovementPlatformer mp;
    public LoadLevel lc;

    public GameObject speechGreen;
    public GameObject speechGreen2;
    public GameObject speechRed;
    public GameObject speechRed2;

    public Sprite climbGreen;
    public GameObject rocket2;
    public GameObject rocket3;

    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject textRed;
    public GameObject textRed2;

    public GameObject red;
    public Animator animatorRed;

    public GameObject green;
    public Animator animatorGreen;

    public float Speed = 3f;
    public bool ladderCollision = false;
    public bool ladderCollision2 = false;
    public bool ladderCollisionGreen = false;
    public bool ladderCollision2Green = false;

    public bool runRed = false;
    public bool runGreen = false;

    private int nextLevel;
    public bool no = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InitialSpeech());
    }

    // Update is called once per frame
    void Update()
    {

        if(runRed){
            red.transform.position += Vector3.right * Time.deltaTime * Speed ;
            animatorRed.SetFloat("HorizontalAxis", Mathf.Abs(1));
        }

        if(runGreen){
            animatorGreen.SetFloat("HorizontalAxis", Mathf.Abs(1));

            if(green.transform.position.x >= 13.65f && green.transform.position.y >= -4.16f && no == true){
                animatorGreen.SetFloat("HorizontalAxis", 0);
                animatorGreen.SetBool("isWalking", true);
                mp.animator.SetBool("isWalking", true);
                speechGreen2.SetActive(false);
                text3.SetActive(false);
                runGreen = false;
                rocket2.SetActive(false);
                rocket3.SetActive(true);
                lc.FadeToLevel(nextLevel);
            }else if(green.transform.position.x >= 13.65f && green.transform.position.y >= -4.16f && no != true){
                red.transform.position += Vector3.right * Time.deltaTime * Speed ;
                animatorRed.SetFloat("HorizontalAxis", Mathf.Abs(1));
                if(red.transform.position.x >= 26f){
                    lc.FadeToLevel(nextLevel);
                }
            }

            if(green.transform.position.y >= -3.7f){
                //Debug.Log("Col");
                green.transform.position += Vector3.right * Time.deltaTime * Speed ;
            }else{
                //Debug.Log("Non-Col");
                green.transform.position += new Vector3(1, 0.45f, 0) * Time.deltaTime * Speed ;
            }
        }

        if(ladderCollision){
            red.transform.position += Vector3.up * Time.deltaTime * Speed;
            animatorRed.SetBool("isWalking", true);
        }

        if(ladderCollision2){
            animatorRed.SetBool("isWalking", true);
            StartCoroutine(SecondSpeech());

        }

        if(text2.activeSelf && Input.GetButton("No")){
            script.currentStep = 1;
            runRed =  true;
            nextLevel = SceneManager.GetActiveScene().buildIndex + 2;
            no = true;
        }

        if(text2.activeSelf && Input.GetButton("Yes")){
            StartCoroutine(ThirdSpeech());
        }

        if((Input.GetButton("Yes") || Input.GetButton("No")) && text2.activeSelf){
            text2.SetActive(false);
            textRed.SetActive(false);
            speechRed.SetActive(false);
            speechGreen.SetActive(false);
        }
    }

    IEnumerator ThirdSpeech()
    {
        yield return new WaitForSeconds(2f);
        speechGreen.SetActive(true);
        text4.SetActive(true);
        yield return new WaitForSeconds(4f);
        speechGreen.SetActive(false);
        text4.SetActive(false);
        script.currentStep = 1;
        yield return new WaitForSeconds(2f);
        green.transform.position = new Vector3(1.3f, -7.15f, 0f);
        runGreen =  true;
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        no = false;
        //yield return new WaitForSeconds(6f);
    }

    IEnumerator SecondSpeech()
    {
        yield return new WaitForSeconds(2f);
        speechRed2.SetActive(true);
        textRed2.SetActive(true);
        yield return new WaitForSeconds(4f);
        speechGreen2.SetActive(true);
        text3.SetActive(true);
        green.transform.position = new Vector3(1.3f, -7.15f, 0f);
        runGreen = true;
        ladderCollision2 = false;
        //yield return new WaitForSeconds(6f);
    }

    IEnumerator InitialSpeech()
    {
        yield return new WaitForSeconds(5f);
        speechGreen.SetActive(true);
        text1.SetActive(true);
        yield return new WaitForSeconds(4f);
        text1.SetActive(false);
        text2.SetActive(true);
    }
}
