using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Trans : MonoBehaviour
{
    public LoadLevel ll;

    public GameObject green;
    public GameObject red;

    public GameObject redD;
    public GameObject greenD;

    public Animator redAnimator;
    public Animator greenAnimator;

    public int step;
    public bool greenRun;
    public bool redRun;

    private bool greenRunInitial;

    public float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        green.GetComponentInParent<MovementPlatformer>().canMove = false;
        StartCoroutine(InitialSpeech());

    }

    // Update is called once per frame
    void Update()
    {
        if(green.transform.position.x > 20f){
            ll.LoadNextLevel();
        }

        if(greenRunInitial){
            green.transform.position += Vector3.right * Time.deltaTime * Speed ;
            greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
        }

        if(green.transform.position.x >= -24f){
            greenRunInitial = false;
            greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(0));
        }

        if(redRun){
            if(red.transform.position.x <= 15){
                red.transform.position += Vector3.right * Time.deltaTime * Speed;
                redAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
            }else if (red.transform.position.x > 15 && red.transform.position.y < 15.5f){
                red.transform.position += Vector3.up * Time.deltaTime * Speed;
                redAnimator.SetBool("isWalking", true);
                redAnimator.SetBool("Climb", false);
            }else{
                redAnimator.SetBool("isWalking", false);
                redAnimator.SetBool("Climb", false);
                red.transform.position += Vector3.right * Time.deltaTime * Speed;
                redAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
            }

            if(greenRun){
                if(green.transform.position.x <= -1f){
                    green.transform.position += Vector3.right * Time.deltaTime * Speed ;
                    greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
                }else if (green.transform.position.x > -1f && green.transform.position.y < 4.1f){
                    green.transform.position += Vector3.up * Time.deltaTime * Speed ;
                    greenAnimator.SetBool("isWalking", true);
                    greenAnimator.SetBool("Climb", false);
                }else{
                    greenAnimator.SetBool("isWalking", false);
                    greenAnimator.SetBool("Climb", false);
                    green.transform.position += Vector3.right * Time.deltaTime * Speed ;
                    greenAnimator.SetFloat("HorizontalAxis", Mathf.Abs(1));
                }
            }
        }
    }


    IEnumerator InitialSpeech()
    {
        greenRunInitial = true;
        redD.SetActive(true);

        yield return new WaitForSeconds(5f);
        redD.SetActive(false);
        redRun = true;
        StartCoroutine(SecondSpeech());
    }

    IEnumerator SecondSpeech()
    {
        yield return new WaitForSeconds(3f);
        greenD.SetActive(true);
        yield return new WaitForSeconds(3f);
        greenD.SetActive(false);
        greenRun = true;
    }
}
