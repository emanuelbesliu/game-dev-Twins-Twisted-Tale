﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject red;
    public GameObject green;
    public Animator animatorRed;
    public Animator animatorGreen;

    public GameObject guardianD;
    public GameObject guardianText1;
    public GameObject guardianText2;
    public GameObject guardianText3;

    public GameObject beesD;
    public GameObject beesInfo;
    public GameObject beesText1;
    public GameObject beesText2;
    public GameObject beesText3;

    public GameObject light;
    public GameObject collLight;


    public float Speed = 6f;
    public bool redRun = false;
    public bool endRunRed = false;

    private bool firstBees;
    // Start is called before the first frame update
    void Start()
    {
        redRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(redRun){
            red.transform.position += Vector3.right * Time.deltaTime * Speed;
            animatorRed.SetFloat("HorizontalAxis", Mathf.Abs(1));
        }

        if(endRunRed){
            green.transform.position += Vector3.right * Time.deltaTime * Speed;
            animatorGreen.SetFloat("HorizontalAxis", Mathf.Abs(1));
            StartCoroutine(GuardianSpeech());
        }

        if(green.transform.position.y >= 4.5 && !firstBees){
            firstBees = true;
            beesD.SetActive(true);
        }

        if(beesInfo.activeSelf && Input.GetButtonDown("Info")){
            if(beesText1.activeSelf){
                beesText1.SetActive(false);
                beesText2.SetActive(true);
            }else if(beesText2.activeSelf){
                beesText2.SetActive(false);
                beesText3.SetActive(true);
                beesInfo.SetActive(false);
            }
        }
    }

    IEnumerator GuardianSpeech() {

        if (guardianD != null)
        {
            guardianD.SetActive(true);
        }
        yield return new WaitForSeconds(5f);
        if (light != null)
        {
            light.SetActive(false);
        }
        if (collLight != null)
        {
            collLight.SetActive(true);
        }
            yield return new WaitForSeconds(5f);
        if  (light != null)
        {
            light.SetActive(true);
        }
        if (collLight != null)
        {
            collLight.SetActive(false);
        }
        if (guardianD != null)
        {
            guardianD.SetActive(false);
        }
            yield return new WaitForSeconds(15f);
        if (guardianD != null)
        {
            guardianD.SetActive(true);
        }
        if (guardianText1 != null)
        {
            guardianText1.SetActive(false);
        }
        if (guardianText2 != null) guardianText2.SetActive(true);
            yield return new WaitForSeconds(15f);
        if (guardianD != null) guardianD.SetActive(false);
            yield return new WaitForSeconds(20f);
        if (guardianD != null) guardianD.SetActive(true);
        if (guardianText2 != null) guardianText2.SetActive(false);
        if (guardianText3 != null) guardianText3.SetActive(true);
    
    }
}
