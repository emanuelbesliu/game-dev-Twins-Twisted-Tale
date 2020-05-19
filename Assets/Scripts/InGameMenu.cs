using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InGameMenu : MonoBehaviour
{
    public GameObject block;
    public GameObject menu;
    public GameObject helpMenu;
    public GameObject settingsMenu;

    public LoadLevel level;

    public GameObject light;
    public Level0 script;

    public Button resume;
    public Button help;
    public Button settings;
    public Button mainMenu;
    public Button backHelp;
    public Button backSettings;

    public GameObject pointLight;

    // Start is called before the first frame update
    void Start()
    {
        resume.onClick.AddListener(ResumeOnClick);
        help.onClick.AddListener(HelpOnClick);
        settings.onClick.AddListener(SettingsOnClick);
        mainMenu.onClick.AddListener(MainMenuOnClick);
        backHelp.onClick.AddListener(BackOnClick);
        backSettings.onClick.AddListener(BackOnClick);
    }


    void ResumeOnClick(){
        Debug.Log("Click");
        //if(menu.activeSelf){
            Time.timeScale=1;
            block.SetActive(false);
            light.SetActive(true);
        //}
    }

    void BackOnClick(){
        settingsMenu.SetActive(false);
        helpMenu.SetActive(false);
        menu.SetActive(true);
    }

    void HelpOnClick(){
        settingsMenu.SetActive(false);
        menu.SetActive(false);
        helpMenu.SetActive(true);
    }

    void SettingsOnClick(){
        menu.SetActive(false);
        helpMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    void MainMenuOnClick(){
        level.FadeToLevel(0);
        Time.timeScale=1;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("ESC")){
            if(block.activeSelf){
                //script.pause = true;
                Time.timeScale=1;
                block.SetActive(false);
                light.SetActive(true);
            }else{
                //script.pause = false;
                block.SetActive(true);
                light.SetActive(false);
                if(menu.activeSelf){
                    resume.Select();
                }else if(helpMenu.activeSelf){

                }
                Time.timeScale=0;
            }
        }

        if(block.activeSelf){
            pointLight.SetActive(true);
        }
    }


    /*private void setButtonsActive(Button button, bool set)
    {
     GameObject buttons = button.gameObject;
     buttons.SetActive(set);
     if (set)
         EventSystem.current.SetSelectedGameObject(buttons.GetComponentInChildren<Button>().gameObject, null);
     else
         EventSystem.current.SetSelectedGameObject(null);
    }*/
}
