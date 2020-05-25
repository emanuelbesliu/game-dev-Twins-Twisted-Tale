using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioClip[] soundtrack;
    public Slider volumeSlider;

    public AudioSource audioSource;


  public string currentLevel;
    public  bool isMusicPlaying=false;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if(SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "TranMainMenu"){
            try
            {
                volumeSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
                GameObject.FindGameObjectWithTag("Settings").SetActive(false);
            }
            catch { }
        }

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            audioSource.clip = soundtrack[0];
            Debug.Log("Changed music");

            audioSource.Play();
            isMusicPlaying = true;

        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Use this for initialization
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;

        audioSource = GetComponent<AudioSource>();
        //Debug.Log(audioSource.volume);
        audioSource.volume = 0.5f;
        volumeSlider.value = audioSource.volume;

        if (!audioSource.playOnAwake)
        {
            audioSource.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (currentLevel != SceneManager.GetActiveScene().name)
        {
            isMusicPlaying = false;
            currentLevel = SceneManager.GetActiveScene().name;
        }
        if (!isMusicPlaying)
        {
            // Music needs updating

            if (SceneManager.GetActiveScene().name == "Level0")
            {
                audioSource.clip = soundtrack[6];
                Debug.Log("Changed music");

                audioSource.Play();
                isMusicPlaying = true;

            }
             if (SceneManager.GetActiveScene().name == "Level1-1")
            {
                audioSource.clip = soundtrack[1];
                Debug.Log("Changed music");

                audioSource.Play();
                isMusicPlaying = true;

            }

            if (SceneManager.GetActiveScene().name == "Level1-2G" || SceneManager.GetActiveScene().name == "Level1-2L" || SceneManager.GetActiveScene().name == "Level1-2N")
            {
                audioSource.clip = soundtrack[2];
                Debug.Log("Changed music");

                audioSource.Play();
                isMusicPlaying = true;

            }
            if (SceneManager.GetActiveScene().name == "Level1-3G" || SceneManager.GetActiveScene().name == "Level1-3L" || SceneManager.GetActiveScene().name == "Level1-3N")
            {
                audioSource.clip = soundtrack[3];
                Debug.Log("Changed music");

                audioSource.Play();
                isMusicPlaying = true;

            }
            if (SceneManager.GetActiveScene().name == "Level1-4G" || SceneManager.GetActiveScene().name == "Level1-4L" || SceneManager.GetActiveScene().name == "Level1-4N")
            {
                audioSource.clip = soundtrack[4];
                Debug.Log("Changed music");

                audioSource.Play();
                isMusicPlaying = true;

            }
             if (SceneManager.GetActiveScene().name == "Level1-5-N" || SceneManager.GetActiveScene().name == "Level1-5-LG")
            {
                audioSource.clip = soundtrack[5];
                Debug.Log("Changed music");

                audioSource.Play();
                isMusicPlaying = true;

            }



        }


        if (volumeSlider == null){
            try { volumeSlider = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<InGameMenu>().volumeSlider; }
            catch
            {

            }
        }else{
            volumeSlider.value = audioSource.volume;
        }

        if (!audioSource.isPlaying)
        {
            audioSource.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audioSource.Play();
        }
    }

    void OnEnable()
    {

        //Register Slider Events
        volumeSlider.onValueChanged.AddListener(delegate { changeVolume(volumeSlider.value); });
    }

    //Called when Slider is moved
    public void changeVolume(float sliderValue)
    {
        audioSource.volume = sliderValue;
    }

    void OnDisable()
    {
        //Un-Register Slider Events
        volumeSlider.onValueChanged.RemoveAllListeners();

      //  if (SceneManager.GetActiveScene().name == "Level1-3G" || SceneManager.GetActiveScene().name == "Level1-3L" || SceneManager.GetActiveScene().name == "Level1-3N")
          //  if (SceneManager.GetActiveScene().name == "Level1-3G" || SceneManager.GetActiveScene().name == "Level1-3L" || SceneManager.GetActiveScene().name == "Level1-3N")
           //     if (SceneManager.GetActiveScene().name == "Level1-3G" || SceneManager.GetActiveScene().name == "Level1-3L" || SceneManager.GetActiveScene().name == "Level1-3N")



    }
}
