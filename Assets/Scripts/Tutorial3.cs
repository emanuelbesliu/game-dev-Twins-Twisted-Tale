using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial3 : MonoBehaviour
{
    private bool needSkip = false;
    
    // Start is called before the first frame update
    void Awake()
    {
        // Start the coroutine when the object is active.
        StartCoroutine(tutorialSteps());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            Destroy(this);
        }
    }
    IEnumerator tutorialSteps()
    {
        //Todo

        //Delay1
        yield return new WaitForSeconds(4);

        //Todo2
        

        //Wait for 2 seconds
        yield return new WaitForSeconds(2);

        //TODO3


        // Ending tutorial;
        Destroy(this);

    }
}
