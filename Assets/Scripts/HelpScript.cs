using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpScript : MonoBehaviour


{
    public bool bearHelp = false;
    public bool beeHelp = false;
    public bool antHelp = false;

    public GameObject platformBee1;
    public GameObject platformBee2;
    public GameObject bearCherry;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (SceneManager.GetActiveScene().name == "Level1-1")
            {
               platformBee1 = GameObject.Find("beehelpplatform1");
                platformBee2 = GameObject.Find("beehelpplatform2");


            }
            if (SceneManager.GetActiveScene().name == "Level1-2G" || SceneManager.GetActiveScene().name == "Level1-2L" || SceneManager.GetActiveScene().name == "Level1-2N")
            {
                platformBee1 = GameObject.Find("anthelpplatform1");
                platformBee2 = GameObject.Find("anthelpplatform2");
            }

        }
        catch
        {

        }
        if (bearCherry != null )
        {
            bearHelp = bearCherry.activeSelf;
        }
        if (platformBee1 != null && platformBee2 !=null)
        {

            if (platformBee1.activeSelf && platformBee2.activeSelf)
            {
                if (SceneManager.GetActiveScene().name == "Level1-1") beeHelp = true;
                if (SceneManager.GetActiveScene().name == "Level1-2G" || SceneManager.GetActiveScene().name == "Level1-2L" || SceneManager.GetActiveScene().name == "Level1-2N") antHelp = true;

            }
        }
    }
}
