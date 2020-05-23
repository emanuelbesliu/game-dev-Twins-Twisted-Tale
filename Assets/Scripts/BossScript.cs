using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    public int hp;
    
    public LevelTrigger levelTrigger;

    // Start is called before the first frame update
    void Start()
    {
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AttackBee"))
        {
            hp--;
            other.gameObject.SetActive(false);
            if (hp <0)
            {
                // Add code to happen when the boss dies.
                this.gameObject.SetActive(false);

                
                SceneManager.LoadScene(levelTrigger.levelToLoadWhenTriggered);


            }

            
   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
