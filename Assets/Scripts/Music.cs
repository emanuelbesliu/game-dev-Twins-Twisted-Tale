using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioClip[] soundtrack;
    public Slider volumeSlider;

    public AudioSource audioSource;


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

        

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Use this for initialization
    void Start()
    {
        
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
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Level0")
        {
            audioSource.clip = soundtrack[1];
            Debug.Log("Changed music");
            
            audioSource.Play();

        }


        if (volumeSlider == null){
            volumeSlider = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<InGameMenu>().volumeSlider;
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
