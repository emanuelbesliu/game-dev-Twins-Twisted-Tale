﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beehelp : MonoBehaviour
{
    public HelpScript helpscript;
    public GameObject ifHelped;
    public GameObject ifNotHelped;


   
    void Awake()
    {
       helpscript =  GameObject.Find("Helper").GetComponent<HelpScript>();

        if (ifHelped != null)
        {
            if (helpscript.beeHelp)
            {
                ifHelped.SetActive(true);
                if (ifNotHelped != null) ifNotHelped.SetActive(false);
            }
            else
            {
                ifNotHelped.SetActive(true);
                if (ifNotHelped != null) ifHelped.SetActive(false);
            }
        }
    }


}
