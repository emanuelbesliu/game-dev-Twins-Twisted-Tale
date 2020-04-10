using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimation : MonoBehaviour
{
    //public Animator animator;
    public GameObject player;
    public GameObject player2;
    public GameObject light;
    public GameObject light2;
    public LoadLevel load;
    public float Speed = 1f;

    private Vector3 initialLight;
    private Vector3 initialLight2;

    private Vector3 rotationMask = new Vector3(1, 1, 1); //which axes to rotate around
    private float rotationSpeed = 28f;

    // Start is called before the first frame update
    void Start()
    {
        initialLight = light.transform.position;
        initialLight2 = light2.transform.position;

        //InvokeRepeating("ChangeLightPosition", 0.3f, 0.3f);
    }

    void FixedUpdate(){
        light.transform.RotateAround(player.transform.position, rotationMask, rotationSpeed * Time.deltaTime);
        light2.transform.RotateAround(player2.transform.position, rotationMask, rotationSpeed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y >= 4.8f){
            load.LoadNextLevel();
        }

        player.transform.position += Vector3.up * Time.deltaTime * Speed;
        player2.transform.position += Vector3.up * Time.deltaTime * Speed;


        //light.transform.position += Vector3.up * Time.deltaTime * Speed;
        //light2.transform.position += Vector3.up * Time.deltaTime * Speed;


        //animator.SetFloat("Speed", Mathf.Abs(1));
        player.GetComponent<Animator>().SetTrigger("isWalking");
        player2.GetComponent<Animator>().SetTrigger("isWalking");
    }


    void ChangeLightPosition(){
        light.transform.position += new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-0.5f, 0.5f),0);
        light2.transform.position += new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-0.5f, 0.5f),0);
    }
}
