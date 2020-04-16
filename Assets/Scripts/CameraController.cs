using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cameratarget;
    public Camera cameratarget2;
    public float panSteps = 0.5f;

    private float oldfieldofview;
    public float currentStep;
    private float speed;

    private Vector3 oldposition;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
        oldposition = this.transform.position;
        oldfieldofview = this.GetComponent<Camera>().fieldOfView;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentStep == 1){
            speed += Time.deltaTime;
            this.transform.position = Vector3.Lerp(oldposition, cameratarget.transform.position, speed / panSteps);
            this.GetComponent<Camera>().fieldOfView = Mathf.Lerp(oldfieldofview, cameratarget.fieldOfView, speed / panSteps);
        }else if(currentStep == 2){
            speed += Time.deltaTime;
            this.transform.position = Vector3.Lerp(oldposition, cameratarget2.transform.position, speed / panSteps);
            this.GetComponent<Camera>().fieldOfView = Mathf.Lerp(oldfieldofview, cameratarget2.fieldOfView, speed / panSteps);
        }
    }
}
