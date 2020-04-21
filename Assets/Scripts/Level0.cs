using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0 : MonoBehaviour
{
    public float Speed = 3f;
    public Animator animator;
    public GameObject canvasRed;
    public GameObject dialogRed;
    public GameObject red;
    public GameObject controllers;
    public MovementPlatformer player;

    public GameObject canvasGreen1;
    public GameObject canvasGreen2;
    public GameObject dialogGreen;

    private bool run = false;
    void Start(){
        player.canMove = false;
        StartCoroutine(InitialSpeech());
    }
    // Update is called once per frame
    void Update()
    {
        if(red.transform.position.x > 34){
            red.SetActive(false);
        }

        if(run){
            red.transform.position += Vector3.right * Time.deltaTime * Speed ;
            animator.SetFloat("HorizontalAxis", Mathf.Abs(1));
        }

        if(transform.position.x > 45){
            this.gameObject.SetActive(false);
            run = false;
        }
    }


    IEnumerator InitialSpeech()
    {
        yield return new WaitForSeconds(5f);
        canvasRed.SetActive(false);
        dialogRed.SetActive(false);
        run = true;
        StartCoroutine(SecondSpeech());
    }

    IEnumerator SecondSpeech()
    {
        yield return new WaitForSeconds(3f);
        dialogGreen.SetActive(true);
        canvasGreen1.SetActive(true);
        yield return new WaitForSeconds(5f);
        canvasGreen1.SetActive(false);
        canvasGreen2.SetActive(true);
        yield return new WaitForSeconds(9f);
        dialogGreen.SetActive(false);
        canvasGreen2.SetActive(false);
        controllers.SetActive(true);
        player.canMove = true;
    }
}
