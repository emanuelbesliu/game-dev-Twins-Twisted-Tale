using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Script : MonoBehaviour
{

    public GameObject clouds;
    public GameObject trollspeach;

    public GameObject red;
    public GameObject green;
    public GameObject mom;

    public float SpeedRed;
    public float SpeedGreen;
    public float CloudSpeed;

    public GameObject greenSpeech;
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
    // Start is called before the first frame update
    void Start()
    {
        if(scenario == 1){
            StartCoroutine(InitialSpeech());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(green.transform.position.x >= 15f){
            green.SetActive(false);
        }

        if(red.transform.position.x >= 15f){
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

        if(green.transform.position.x >= -4f && momText1.activeSelf){
            runGreen = false;
            greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(0));
            trollspeach.SetActive(false);
            startClouds = true;
        }

        if(red.transform.position.x >= -6.5f && momText1.activeSelf){
            runRed = false;
            redAnimator.SetFloat("HorizontalAxis", Mathf.Abs(0));
            trollspeach.SetActive(false);
            StartCoroutine(SecondSpeech());
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
