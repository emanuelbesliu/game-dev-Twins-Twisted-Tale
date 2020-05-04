using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject red;
    public GameObject green;
    public Animator animatorRed;
    public Animator animatorGreen;

    public float Speed = 6f;
    public bool redRun = false;
    public bool endRunRed = false;
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
        }
    }
}
