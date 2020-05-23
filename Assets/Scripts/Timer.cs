using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    private Text timerText;
    public float startTime;
    public bool isTimerWorking = false;
    private float timerDelay = 0;

    public GameObject leavingAnimation;
    Transform npc;

    // Start is called before the first frame update
    void Awake()
    {
          //startTime = Time.time;
        timerText = this.GetComponent<Text>();
        isTimerWorking = true;
       
        try
        {
            npc = GameObject.FindGameObjectWithTag("redNPC").transform;
        }
        catch

        { }

        
   



    }
    public void AddTime(float timeToAdd)
    {
        timerDelay += timeToAdd;
    }


        // Update is called once per frame
        void Update()
    { if (timerText != null)
        {

            // Timer Timings
            if (isTimerWorking && timerDelay == 0) timerDelay = Time.time;
            if (isTimerWorking && timerDelay != 0)
            {
                //startTime = startTime + timerDelay;


                float currentTime = startTime - Time.time + timerDelay;
                if (currentTime < 0 )
                {
                    if (leavingAnimation != null)
                    {
                        if (SceneManager.GetActiveScene().name == "Level1-1")
                        {
                           // if (npc != null) npc.localEulerAngles = new Vector3(0f, 180f, 0f);
                        }
                        leavingAnimation.SetActive(true);
                    }
                }

                string minutes = ((int)currentTime / 60).ToString();
                string seconds = (currentTime % 60).ToString("f2");

                // Coloring of the text.

                if (currentTime > startTime / 2)
                {
                    timerText.color = Color.white;

                }
                else if (currentTime > startTime / 3)
                {
                    timerText.color = Color.yellow;


                }


                else if (currentTime < 0) timerText.color = Color.red;


                timerText.text = minutes + " : " + seconds;
            }
            else
            {
                timerText.text = "";
            }
        }
        

    }
}
