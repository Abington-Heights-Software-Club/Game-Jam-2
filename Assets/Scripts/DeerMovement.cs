using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerMovement : MonoBehaviour
{
    public static float gridSquareSize = 1;
    public static float moveSpeed = 0.5f;

    private Vector3 currentMove = new Vector3();
    //private Vector3 targetPos = new Vector3();
    private float currentDistTraveled; //used to determine how much of each player move is left to make

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMove == new Vector3()) { //currently not moving
            if (Input.GetAxisRaw("Horizontal") > 0.5f)
            {
                currentMove = new Vector3(1, 0);
            }
            else if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                currentMove = new Vector3(-1, 0);
            }
            else if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                currentMove = new Vector3(1, 0);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                currentMove = new Vector3(-1, 0);
            }
            //targetPos = transform.position + new Vector3(currentMove.x * gridSquareSize, currentMove.y * gridSquareSize);
            currentDistTraveled = 0f;

        }
        else //currently moving
        {
            transform.position += new Vector3(currentMove.x * gridSquareSize, currentMove.y * gridSquareSize);
            /*
            if (currentDistTraveled < gridSquareSize)
            {
                transform.position = transform.position + new Vector3(currentMove.x * gridSquareSize * Time.deltaTime * moveSpeed, currentMove.y * gridSquareSize * Time.deltaTime * moveSpeed);
                currentDistTraveled = currentDistTraveled + gridSquareSize * Time.deltaTime * moveSpeed;
            }
            if(currentDistTraveled>)
                */
        }
    }
}
