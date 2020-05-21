using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private Text timerText;
    public float startTime;
    public bool isTimerWorking = false;
    private float timerDelay = 0;
    // Start is called before the first frame update
    void Start()
    {
          //startTime = Time.time;
        timerText = this.GetComponent<Text>();
        
   



    }

    // Update is called once per frame
    void Update()
    {

        // Timer Timings
        if (isTimerWorking && timerDelay == 0) timerDelay = Time.time;
        if (isTimerWorking && timerDelay != 0)
        {
            //startTime = startTime + timerDelay;
    

            float currentTime = startTime  - Time.time + timerDelay;

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
