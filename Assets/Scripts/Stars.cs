using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stars : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D[] star1;
    private bool[] directions;

    void Start()
    {
        directions = new bool[26];
        for(int i=0; i<star1.Length; i++)
		{
            directions[i] = true;
		}

        InvokeRepeating("UpdateStar", 0.11f, 0.11f);
        if(SceneManager.GetActiveScene().buildIndex == 0){
            InvokeRepeating("UpdateLantern", 0.25f, 0.25f);
        }
    }

    bool updateLight(UnityEngine.Experimental.Rendering.Universal.Light2D star, bool direction, bool last)
	{
		if (star.intensity >= 1.3f)
		{
            direction = false;
		}else if(star.intensity <= 0.0f && !last)
		{
            direction = true;
		}else if(star.intensity <= 0.5f && last){
            direction = true;
        }

        return direction;
	}

     void UpdateStar()
    {
        for(int i=0; i<star1.Length; i++){
            directions[i] = updateLight(star1[i], directions[i], false);
            if (i != 11)
            {
                if (directions[i])
                {
                    star1[i].intensity += 0.038f;
                }
                else
                {
                    star1[i].intensity -= 0.038f;
                }
            }
         }
    }

    void UpdateLantern(){
        directions[11] = updateLight(star1[11], directions[11], true);
        if(directions[11]){
            star1[11].intensity += 0.025f;
        }else{
            star1[11].intensity -= 0.025f;
        }

    }
}
