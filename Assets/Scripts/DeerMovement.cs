using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DeerMovement : MonoBehaviour
{
    public static float gridSquareSize = 1;
    public static float moveSpeed = 0.5f;
    public AIDestinationSetter AIDestinationSetter;

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
        Vector3 movedPosition = new Vector3(0, 0);
        Vector2 moveDirection = new Vector2(0, 0);
        if (Input.GetKeyDown(KeyCode.D))
        {
            movedPosition = new Vector3(transform.position.x + 1, transform.position.y);
            moveDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            movedPosition = new Vector3(transform.position.x - 1, transform.position.y);
            moveDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            movedPosition = new Vector3(transform.position.x, transform.position.y - 1);
            moveDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            movedPosition = new Vector3(transform.position.x, transform.position.y + 1);
            moveDirection = Vector2.up;
        }
        if(movedPosition != new Vector3(0, 0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 1, LayerMask.GetMask("Wall"));
            if(hit.collider == null)
            {
                transform.position = movedPosition;
            }
            AIDestinationSetter.enemyMove();
        }

        /*if (currentMove == new Vector3()) { //currently not moving
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

        else //currently moving
        {
            transform.position += new Vector3(currentMove.x * gridSquareSize, currentMove.y * gridSquareSize);
            
            if (currentDistTraveled < gridSquareSize)
            {
                transform.position = transform.position + new Vector3(currentMove.x * gridSquareSize * Time.deltaTime * moveSpeed, currentMove.y * gridSquareSize * Time.deltaTime * moveSpeed);
                currentDistTraveled = currentDistTraveled + gridSquareSize * Time.deltaTime * moveSpeed;
            }
            if(currentDistTraveled>)
                
        }*/
    }
}