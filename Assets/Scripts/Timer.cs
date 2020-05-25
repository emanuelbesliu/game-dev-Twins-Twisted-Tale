using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    private Text timerText; 
    public Text extratimerText;
    public float startTime;
    public bool isTimerWorking = false;
    private float timerDelay = 0;
    public LevelTrigger levelTrigger;
    public string levelTransitionGoodTime;
    public string levelTransitionBadTime;
    public string levelTransitionWorstTime;
    public GameObject leavingAnimation;
    Transform npc;

    // Start is called before the first frame update
    void Awake()
    {
          //startTime = Time.time;
        timerText = this.GetComponent<Text>();
        isTimerWorking = true;
        //ExtraTime(10);
       
        try
        {
            npc = GameObject.FindGameObjectWithTag("redNPC").transform;
            levelTrigger = GameObject.FindGameObjectWithTag("levelTrigger").GetComponent<LevelTrigger>();
        }
        catch

        { }

        
   



    }
    public void AddTime(float timeToAdd)
    {
        StartCoroutine(ExtraTime(timeToAdd));
        //Debug.Log("Extra time show");
        timerDelay += timeToAdd;
        
    }

    IEnumerator ExtraTime(float delay)
    
    {
       // Debug.Log("Extra time show")
        string seconds = (delay % 60).ToString("f0");

       
        extratimerText.text =" + " + seconds;

        yield return new WaitForSeconds(2);
       // Debug.Log("Extra time hide");
        extratimerText.text = " ";

    }



        // Update is called once per frame
        void Update()
    {try
        {
            levelTrigger = GameObject.FindGameObjectWithTag("levelTrigger").GetComponent<LevelTrigger>();
        }
        catch { }
        
        if (timerText != null)
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
                        if (SceneManager.GetActiveScene().name == "Level1-1" || SceneManager.GetActiveScene().name == "Level1-2L" || SceneManager.GetActiveScene().name == "Level1-2N")
                        {
                            // if (npc != null) npc.localEulerAngles = new Vector3(0f, 180f, 0f);
                            leavingAnimation.SetActive(true);
                        }
                        
                    }
                }

                string minutes = ((int)currentTime / 60).ToString();
                string seconds = (currentTime % 60).ToString("f2");

                // Coloring of the text.

                if (currentTime > startTime / 2)
                {
                    try { levelTrigger.levelToLoadWhenTriggered = levelTransitionGoodTime; }
                    
                    catch { }

                timerText.color = Color.white;

                }
                else if (currentTime > startTime / 3)
                {
                    timerText.color = Color.yellow;


                }


                else if (currentTime < 0 && currentTime > (startTime / 2) * (-1f))
                {
                  try {  levelTrigger.levelToLoadWhenTriggered = levelTransitionBadTime; }
                    catch { }
                    timerText.color = Color.red;
                
                }
                else if (currentTime < (startTime / 2 ) * (-1f))
                {
                    timerText.color = Color.gray;
                    try { levelTrigger.levelToLoadWhenTriggered = levelTransitionWorstTime; 
                    }
                    catch { }
            }



                timerText.text = minutes + " : " + seconds;
            }
            else
            {
                timerText.text = "";
            }
        }
        

    }
}
