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
        startClouds = true;
        if(scenario == 1){
            StartCoroutine(InitialSpeech());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(runRed){
            red.transform.position += Vector3.right * Time.deltaTime * SpeedRed ;
            redAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
        }

        if(runGreen){
            green.transform.position += Vector3.right * Time.deltaTime * SpeedGreen;
            greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
        }

        if(startClouds){
            clouds.transform.position += Vector3.right * Time.deltaTime * CloudSpeed ;
        }

        if(green.transform.position.x >= -4f){
            runGreen = false;
            greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(0));
            trollspeach.SetActive(false);
        }

        if(red.transform.position.x >= -6.5f){
            runRed = false;
            redAnimator.SetFloat("HorizontalAxis", Mathf.Abs(0));
        }
    }


    IEnumerator InitialSpeech(){
        runRed = true;
        runGreen = true;

        momSpeech.SetActive(true);
        momText1.SetActive(true);
        yield return new WaitForSeconds(5f);
        trollspeach.SetActive(true);
        momText1.SetActive(false);
        momText2.SetActive(true);
    }
}
