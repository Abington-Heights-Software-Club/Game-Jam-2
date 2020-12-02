using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DeerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float tolerance = 0.05f;
    private bool isWaiting = false;
    private bool isWaitingTimerOn = false;
    private Animator anim;
    private bool isCurrentlyMoving = false;
    private Vector3 currentMove = new Vector3();
    private Vector3 movedPosition = new Vector3(0, 0);
    private Vector3 moveDirection = new Vector2(0, 0);
    //private Vector3 targetPos = new Vector3();
    public GameObject predictedPosition;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(isCurrentlyMoving)
        {
            transform.position += moveDirection * Time.deltaTime * moveSpeed;
            predictedPosition.transform.position -= moveDirection * Time.deltaTime * moveSpeed;
            if (Mathf.Abs(transform.position.x - movedPosition.x) < tolerance && Mathf.Abs(transform.position.y - movedPosition.y) < tolerance)
            {
                isCurrentlyMoving = false;
                transform.position = movedPosition;
                anim.SetBool("isRunning", false);
                predictedPosition.transform.position = transform.position;
            }
        }
        else
        {
            movedPosition = new Vector3(0, 0);
            moveDirection = new Vector2(0, 0);
            if (Input.GetKeyDown(KeyCode.D))
            {
                isCurrentlyMoving = true;
                movedPosition = new Vector3(transform.position.x + 1, transform.position.y);
                moveDirection = Vector2.right;
                GetComponent<SpriteRenderer>().flipX = false;
                isWaiting = false;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                isCurrentlyMoving = true;
                movedPosition = new Vector3(transform.position.x - 1, transform.position.y);
                moveDirection = Vector2.left;
                GetComponent<SpriteRenderer>().flipX = true;
                isWaiting = false;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                isCurrentlyMoving = true;
                movedPosition = new Vector3(transform.position.x, transform.position.y - 1);
                moveDirection = Vector2.down;
                isWaiting = false;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                isCurrentlyMoving = true;
                movedPosition = new Vector3(transform.position.x, transform.position.y + 1);
                moveDirection = Vector2.up;
                isWaiting = false;
            }
            else if (!isWaitingTimerOn)
            {
                isWaitingTimerOn = true;
                isWaiting = true;
                anim.SetBool("isRunning", false);
                StartCoroutine(idleWait());
            }
            if (movedPosition != new Vector3(0, 0))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 1, LayerMask.GetMask("Wall"));
                if (hit.collider != null)
                {
                    anim.SetBool("isRunning", false);
                    movedPosition = new Vector3(0, 0);
                    isCurrentlyMoving = false;
                }
                else
                {
                    anim.SetBool("isRunning", true);
                    predictedPosition.transform.position = movedPosition;
                }
            }
        }
    }
    IEnumerator idleWait()
    {
        int count = 0;
        while (isWaiting)
        {
            yield return new WaitForSeconds(1);
            count++;
            if (count == 9)
            {
                anim.SetTrigger("isWaitingLong");
            }
        }
        isWaitingTimerOn = false;
    }
    

}