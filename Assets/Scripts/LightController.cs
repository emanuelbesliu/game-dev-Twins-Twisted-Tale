using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D[] stars;
    private bool[] directions;
    // Start is called before the first frame update
    void Start()
    {
        directions = new bool[21];
        for(int i=0; i<stars.Length; i++)
        {
            directions[i] = true;
        }

        InvokeRepeating("UpdateStar", 0.11f, 0.11f);
    }

    bool updateLight(UnityEngine.Experimental.Rendering.Universal.Light2D star, bool direction, bool last)
    {
        if (star.intensity >= 1.3f)
        {
            direction = false;
        }else if(star.intensity <= 0.45f && !last)
        {
            direction = true;
        }else if(star.intensity <= 0.5f && last){
            direction = true;
        }

        return direction;
    }

    void UpdateStar()
    {
        for(int i=0; i<stars.Length; i++){
            directions[i] = updateLight(stars[i], directions[i], false);

            if (directions[i])
            {
                stars[i].intensity += Random.Range(0.0088f, 0.0260f);
            }
            else
            {
                stars[i].intensity -= Random.Range(0.0088f, 0.0260f);
            }
         }
    }
}
