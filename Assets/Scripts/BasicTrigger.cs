using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicTrigger : MonoBehaviour
{
    public GameObject toHide;
    public GameObject secondObjectToHide;
    public GameObject nextTutorial;
    public GameObject itemToShow;
    public bool uniqueTrigger = true;
   
    private GameObject shovelObject1;
    private GameObject shovelObject2;
    private GameObject shovelObject3;

    public AudioSource beeSound;


    void Awake()
    {
     


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player") || other.CompareTag("FlowerBoss"))
        {
            if (SceneManager.GetActiveScene().name == "Level1-3G" || SceneManager.GetActiveScene().name == "Level1-3L"|| SceneManager.GetActiveScene().name == "Level1-3N")
            {
                try
                {
                    shovelObject1 = GameObject.FindGameObjectWithTag("BrokeShovel");
                   
                        Destroy(shovelObject1);
                        shovelObject1 = GameObject.FindGameObjectWithTag("BrokeShovel");


                    
                }
                catch { }
                
            } 
            
            if (SceneManager.GetActiveScene().name == "Level1-4G" || SceneManager.GetActiveScene().name == "Level1-4L"|| SceneManager.GetActiveScene().name == "Level1-4N")
            {
                try
                {
                    shovelObject1 = GameObject.FindGameObjectWithTag("FlowerBoss");

                    if (shovelObject1 != null  && !itemToShow.activeSelf) {

                        Debug.Log("Fired");
                        itemToShow.SetActive(true);

                        Destroy(shovelObject1);
                    }
                    
                        


                    
                }
                catch { }
                
            }



            if (toHide != null)
            { // Things to happen instead of just hiding the object
                
                Destroy(toHide);
            
            }
            if (secondObjectToHide != null)
            {
                secondObjectToHide.SetActive(false);
            }
            if (nextTutorial != null) nextTutorial.SetActive(true);
            

           if (uniqueTrigger) Destroy(this.gameObject);


        }


    }
}
