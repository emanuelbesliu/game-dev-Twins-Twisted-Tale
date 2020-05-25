using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuAnim : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sp;
    public Button playButton;
    public Button exitButton;
    public Button settingsButton;
    public Button backButton;
    public LoadLevel load;

    public Slider volumeSlider;

    public GameObject title;
    public GameObject titleLight;
    public GameObject settings;
    public GameObject settingsLight;
    public GameObject volume;

    public float Speed = 3f;
    public bool red;
    public bool play;
    public bool exit;
    public bool walking;
    //private bool sleeping = false;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(TaskOnClick);
        exitButton.onClick.AddListener(ExitOnClick);
        settingsButton.onClick.AddListener(SettingsOnClick);
        backButton.onClick.AddListener(BackOnClick);
        if(red){
            StartCoroutine(SleepingAnimation());
        }else{
            StartCoroutine(SleepingAnimationGreen());
        }
        //animator.SetBool("Sleep", true);
        //sleeping = true;
    }


    void TaskOnClick(){
        playButton.gameObject.SetActive(false);
        //exitButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        play = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(exitButton.gameObject, new BaseEventData(EventSystem.current));
        exitButton.Select ();
        exitButton.OnSelect (null);
    }

    void ExitOnClick(){
        exit = true;
    }

    void SettingsOnClick(){
        title.SetActive(false);
        titleLight.SetActive(false);

        EventSystem.current.SetSelectedGameObject(backButton.gameObject);
        settings.SetActive(true);
        settingsLight.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        volume.SetActive(true);

        playButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        backButton.Select ();
        backButton.OnSelect (null);
    }

    void BackOnClick(){
        title.SetActive(true);
        titleLight.SetActive(true);

        settings.SetActive(false);
        volume.SetActive(false);
        settingsLight.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);

        playButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playButton.gameObject, new BaseEventData(EventSystem.current));
        playButton.Select ();
        playButton.OnSelect (null);
    }

    // Update is called once per frame
    void Update()
    {

        if(settings.activeSelf){
            if(Input.GetButtonDown("Left")){
                volumeSlider.value -= 0.05f;
                GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().changeVolume(volumeSlider.value);
            }else if(Input.GetButtonDown("Right")){
                volumeSlider.value += 0.05f;
                GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().changeVolume(volumeSlider.value);
            }
        }
        //float h = Input.GetAxis("Horizontal");
        //Debug.Log(h);

        if(play){
            StartCoroutine(WalkingAnimation());
        }

        if(walking){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * Speed;
            transform.position += Vector3.right * Time.deltaTime * Speed ;
            //animator.SetFloat("Speed", Mathf.Abs(1));
            animator.SetFloat("HorizontalAxis", Mathf.Abs(1));
        }

        if(exit){
            Application.Quit();
            exit = false;
            Debug.Log("EXIT");
        }

        if(this.transform.position.x > 30){
            load.LoadNextLevel();
        }
    }


    IEnumerator WalkingAnimation()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("isSleeping", false);
        yield return new WaitForSeconds(0.25f);
        animator.SetBool("isSleeping", true);
        play = false;
        yield return new WaitForSeconds(1f);
        if(!red){
            sp.flipX = false;
        }
        walking = true;
    }

    IEnumerator SleepingAnimation()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Sleep", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Sleep", false);
        animator.SetBool("isSleeping", true);
    }

    IEnumerator SleepingAnimationGreen()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("Sleep", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Sleep", false);
        animator.SetBool("isSleeping", true);
        playButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playButton.gameObject, new BaseEventData(EventSystem.current));
        playButton.Select ();
        playButton.OnSelect (null);
    }
}
