using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial3 : MonoBehaviour
{
    public GameObject[] arrayOfText = new GameObject[7];
    
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
            foreach (GameObject elementOfArray in arrayOfText) elementOfArray.SetActive(false);
            Destroy(this);
        }
    }
    IEnumerator tutorialSteps()
    {
        //Todo
        arrayOfText[0].SetActive(true);
        arrayOfText[5].SetActive(true);

        //Delay1
        yield return new WaitForSeconds(5);
        arrayOfText[0].SetActive(false);
        yield return new WaitForSeconds(1);

        //Todo2
        arrayOfText[1].SetActive(true);

        //Wait for 2 seconds
        yield return new WaitForSeconds(8);

        //TODO3
        arrayOfText[1].SetActive(false);
        yield return new WaitForSeconds(1);
        arrayOfText[2].SetActive(true);
        
        //Delay1
        yield return new WaitForSeconds(7);

        //Todo2
        arrayOfText[2].SetActive(false);
        yield return new WaitForSeconds(1);
        arrayOfText[3].SetActive(true);

        //Wait for 2 seconds
        yield return new WaitForSeconds(9);

        //TODO3
        arrayOfText[3].SetActive(false);
        yield return new WaitForSeconds(1);
        arrayOfText[4].SetActive(true);
        arrayOfText[6].SetActive(true);
        //Wait for 2 seconds
        yield return new WaitForSeconds(7);

        //TODO3
        arrayOfText[4].SetActive(false);
        yield return new WaitForSeconds(1);
        
       
        arrayOfText[5].SetActive(false);

        // Ending tutorial;
        Destroy(this);

    }
}
