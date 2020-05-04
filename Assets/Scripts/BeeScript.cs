using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour
{
    public List<GameObject> beesLeft;
    public List<GameObject> beesRight;
    public Camera mainCamera;
    public float Speed = 7f;

    public bool fly;
    // Start is called before the first frame update
    void Start()
    {
        fly = false;
        InvokeRepeating("UpdateBeesLeft", 0.04f, 0.07f);
        InvokeRepeating("UpdateBeesRight", 0.03f, 0.06f);
    }

    // Update is called once per frame
    void UpdateBeesLeft()
    {
        if(fly){
            foreach(GameObject bee in beesLeft){
                if(bee.transform.position.x <= -28f){
                    beesLeft.Remove(bee);
                    beesRight.Add(bee);
                    bee.transform.Rotate(new Vector3(0,180,0));
                }else{
                    if(bee.transform.position.y > 16f){
                        bee.transform.position += new Vector3(0, -4, 0);
                    // }if(bee.transform.position.y > -10f){
                    //    bee.transform.position += new Vector3(0, +4, 0);
                    }else{
                        bee.transform.position += new Vector3(Random.Range(-5.0f, -1.0f), Random.Range(-2.5f, 2.5f), 0) * Time.deltaTime * Speed;
                    }
                }
            }
        }
    }

    void UpdateBeesRight(){
        if(fly){
            foreach(GameObject bee in beesRight){
                if(bee.transform.position.x >= 31f){
                    beesRight.Remove(bee);
                    beesLeft.Add(bee);
                    bee.transform.Rotate(new Vector3(0,180,0));
                }else{
                    if(bee.transform.position.y > 16f){
                        bee.transform.position += new Vector3(0, -4, 0);
                    // }if(bee.transform.position.y > -10f){
                    //    Debug.Log("here");
                    //    bee.transform.position += new Vector3(0, +4, 0);
                    }else{
                        bee.transform.position += new Vector3(Random.Range(1.0f, 5.0f), Random.Range(-2.5f, 2.5f), 0) * Time.deltaTime * Speed;
                    }
                }
            }
        }
    }
}
