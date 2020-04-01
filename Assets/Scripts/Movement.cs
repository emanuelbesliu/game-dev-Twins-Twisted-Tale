using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public GameObject platform;
    public Animator animator;

	public int rows;
	public int columns;
	public float distance;

    float horizontalMove = 0f;

	private int startC;
	private int startR;
	private int[,] grid;
    // Start is called before the first frame update
    void Start()
    {
       grid = new int[columns, rows];
       grid[0, 4] = 1;
       startC = 0;
       startR = 4;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    	Vector3 pos = platform.transform.position;

        if(Input.GetButtonDown("Up") && startR > 0){
        	//Debug.Log("Pressed Up");
        	grid[startC, startR] = 0;
        	startR --;
        	grid[startC, startR] = 1;
        	pos.y += distance;
        	transform.position = pos;
        }else if(Input.GetButtonDown("Down") && startR < rows-1){
        	//Debug.Log("Pressed Down");
        	grid[startC, startR] = 0;
        	startR ++;
        	grid[startC, startR] = 1;
        	pos.y -= distance;
        	transform.position = pos;
    	}else if(Input.GetButtonDown("Left") && startC > 0){
    		//Debug.Log("Pressed Left");
    		grid[startC, startR] = 0;
    		startC --;
    		grid[startC, startR] = 1;
    		pos.x -= distance;
    		transform.position = pos;
    	}else if(Input.GetButtonDown("Right") && startC < columns-1){
    		//Debug.Log("Pressed Right");
    		grid[startC, startR] = 0;
    		startC ++;
    		grid[startC, startR] = 1;
    		pos.x += distance;
    		transform.position = pos;
    	}
    }
}
