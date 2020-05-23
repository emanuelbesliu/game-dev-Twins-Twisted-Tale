using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrigger : MonoBehaviour
{
    public GameObject toHide;
    public GameObject secondObjectToHide;
    public GameObject nextTutorial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        { if (toHide != null)
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
