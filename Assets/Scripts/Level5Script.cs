using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Level5Script : MonoBehaviour
{
    public LoadLevel loadlevel;

    public GameObject clouds;
    public GameObject trollspeach;

    public GameObject red;
    public GameObject green;
    public GameObject mom;

    public float SpeedRed;
    public float SpeedGreen;
    public float CloudSpeed;

    public GameObject greenSpeech;
    public GameObject redSpeech;
    public GameObject momSpeech;
    public GameObject momText1;
    public GameObject momText2;

    public Animator greenAnimator;
    public Animator redAnimator;
    public Animator momAnimator;

    public bool startClouds;
    public bool runRed;
    public bool runGreen;
    public bool runMom;

    public int scenario;

    private bool done;
    // Start is called before the first frame update
    void Start()
    {
        if(scenario == 1){
            StartCoroutine(InitialSpeech());
        }else if(scenario == 2){
            StartCoroutine(InitialSpeech2());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(green.transform.position.x >= 15f){
            if(scenario == 2){
                loadlevel.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 2);
            }
            green.SetActive(false);
        }

        if(red.transform.position.x >= 15f){
            if(scenario == 1){
                loadlevel.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 2);
            }
            red.SetActive(false);
        }

        if(mom.transform.position.x >= 15f){
            mom.SetActive(false);
        }

        if(runRed){
            red.transform.position += Vector3.right * Time.deltaTime * SpeedRed ;
            redAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
        }

        if(runGreen){
            green.transform.position += Vector3.right * Time.deltaTime * SpeedGreen;
            greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
        }

        if(runMom){
            mom.transform.position += Vector3.right * Time.deltaTime * SpeedGreen;
        }

        if(startClouds){
            clouds.transform.position += Vector3.right * Time.deltaTime * CloudSpeed ;
        }

        if(green.transform.position.x >= -4f && scenario == 2 && !done){
            runGreen = false;
            greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(0));
            StartCoroutine(ThirdSpeech2());
        }

        if(green.transform.position.x >= -4f && momText1.activeSelf && scenario == 1){
            runGreen = false;
            greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(0));
            trollspeach.SetActive(false);
            startClouds = true;
        }

        if(red.transform.position.x >= -6.5f && momText1.activeSelf){
            runRed = false;
            redAnimator.SetFloat("HorizontalAxis", Mathf.Abs(0));
            trollspeach.SetActive(false);
            if(scenario == 1){
                StartCoroutine(SecondSpeech());
            }else if(scenario == 2){
                startClouds = true;
                StartCoroutine(SecondSpeech2());
            }
            momSpeech.SetActive(false);
            momText1.SetActive(false);
        }
    }


    IEnumerator InitialSpeech(){
        runRed = true;
        runGreen = true;

        momSpeech.SetActive(true);
        momText1.SetActive(true);
        yield return new WaitForSeconds(3f);
        trollspeach.SetActive(true);
    }

    IEnumerator InitialSpeech2(){
        runRed = true;

        momSpeech.SetActive(true);
        momText1.SetActive(true);
        yield return new WaitForSeconds(3f);
        trollspeach.SetActive(true);
    }

    IEnumerator ThirdSpeech2(){
         greenSpeech.SetActive(true);
         yield return new WaitForSeconds(5f);
         greenSpeech.SetActive(false);
         runGreen = true;
         done = true;
    }

    IEnumerator SecondSpeech2(){
        redSpeech.SetActive(true);
        yield return new WaitForSeconds(7f);
        redSpeech.SetActive(false);
        momSpeech.SetActive(true);
        momText2.SetActive(true);
        yield return new WaitForSeconds(3f);
        mom.transform.Rotate(0, 180, 0);
        momAnimator.SetBool("Running", true);
        runMom = true;
        runRed = true;
        runGreen = true;
        momSpeech.SetActive(false);
        momText2.SetActive(false);
    }

    IEnumerator SecondSpeech(){
        //momText2.SetActive(true);
        greenSpeech.SetActive(true);
        yield return new WaitForSeconds(7f);
        greenSpeech.SetActive(false);
        momSpeech.SetActive(true);
        momText2.SetActive(true);
        yield return new WaitForSeconds(3f);
        mom.transform.Rotate(0, 180, 0);
        momAnimator.SetBool("Running", true);
        runMom = true;
        runRed = true;
        runGreen = true;
        momSpeech.SetActive(false);
        momText2.SetActive(false);
    }
}
