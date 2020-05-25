using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public MainMenuAnim player2;

    private int levelToLoad;

    void Start(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadNextLevel(){
        try { FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1); }
        catch { }

    }

    public void FadeToLevel(int levelIndex){
        levelToLoad = levelIndex;
        animator.SetTrigger("fade_out");
    }

    public void OnFadeComplete(){
        try { SceneManager.LoadScene(levelToLoad); }
        catch {}

    }

    public void RestartLevel(){
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }
}

