using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicTrigger : MonoBehaviour
{
    public GameObject toHide;
    public GameObject secondObjectToHide;
    public GameObject nextTutorial;
   
    private GameObject shovelObject1;
    private GameObject shovelObject2;
    private GameObject shovelObject3;


    void Awake()
    {
     


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if (
    SceneManager.GetActiveScene().name == "Level1-3G")
            {
                try
                {
                    shovelObject1 = GameObject.FindGameObjectWithTag("BrokeShovel");
                   
                        Destroy(shovelObject1);
                        shovelObject1 = GameObject.FindGameObjectWithTag("BrokeShovel");


                    
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
            

            Destroy(this.gameObject);


        }


    }
}
