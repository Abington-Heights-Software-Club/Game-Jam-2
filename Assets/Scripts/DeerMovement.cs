using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DeerMovement : MonoBehaviour
{
    public AIDestinationSetter AIDestinationSetter;

    private float currentDistTraveled; //used to determine how much of each player move is left to make
    private bool isWaiting = false;
    private bool isWaitingTimerOn = false;


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
            isWaiting = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            movedPosition = new Vector3(transform.position.x - 1, transform.position.y);
            moveDirection = Vector2.left;
            isWaiting = false;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            movedPosition = new Vector3(transform.position.x, transform.position.y - 1);
            moveDirection = Vector2.down;
            isWaiting = false;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            movedPosition = new Vector3(transform.position.x, transform.position.y + 1);
            moveDirection = Vector2.up;
            isWaiting = false;
        }
        else if(!isWaitingTimerOn)
        {
            isWaitingTimerOn = true;
            isWaiting = true;
            StartCoroutine(idleWait());
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
    }
    IEnumerator idleWait()
    {
        int count = 0;
        while(isWaiting)
        {
            yield return new WaitForSeconds(1);
            count++;
            Debug.Log("Time: " + count);
            if(count == 9)
            {
                Debug.Log("Waiting Long");
            }
        }
        isWaitingTimerOn = false;
    }
}