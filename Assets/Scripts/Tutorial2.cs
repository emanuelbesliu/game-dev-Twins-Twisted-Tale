using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial2 : MonoBehaviour
{

        public bool canBeActive;
        public GameObject objectTocheck;
        public GameObject optionalPreviousTutorialTip;
        public GameObject nextTutorial;

        public GameObject objectToBeDisplayed;


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1-1")
        {

            if (objectTocheck == null && canBeActive && Input.GetKeyDown("1"))
            {

                if (optionalPreviousTutorialTip != null) optionalPreviousTutorialTip.SetActive(false);
                canBeActive = false;
                if (objectToBeDisplayed != null) objectToBeDisplayed.SetActive(true);
                if (nextTutorial != null) nextTutorial.SetActive(true);






            }
        }
        else
        {

            if (objectTocheck == null && canBeActive)
            {

                if (optionalPreviousTutorialTip != null) optionalPreviousTutorialTip.SetActive(false);
                canBeActive = false;
                if (objectToBeDisplayed != null) objectToBeDisplayed.SetActive(true);
                if (nextTutorial != null) nextTutorial.SetActive(true);






            }
        }
    }
    



}
