using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillHelp : MonoBehaviour
{

    public int x;
    public int y;
    public int z;

    private int tempX;
    private int tempY;
    // Start is called before the first frame update
    void Start()
    {
        x = 16;
        y = -26;
        z = 0;
        tempX = x;
        tempY = y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextTile(){
        if(x>=54){
            if(y >= -29){
                y = tempY;
                y++;
            }else{
                tempX++;
                x = tempX;
                y--;
            }
        }else{
            x++;
        }
    }
}
