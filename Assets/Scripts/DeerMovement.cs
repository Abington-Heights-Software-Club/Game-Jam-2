using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DeerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float tolerance = 0.05f;
    public AIDestinationSetter AIDestinationSetter;
    private bool isWaiting = false;
    private bool isWaitingTimerOn = false;
    private Animator anim;
    private bool isCurrentlyMoving = false;

    public Transform castPoint;
    private bool isInAgro = false;
    private Vector3 currentMove = new Vector3();
    private float agroRange = 3;
    private Vector3 movedPosition = new Vector3(0, 0);
    private Vector3 moveDirection = new Vector2(0, 0);
    //private Vector3 targetPos = new Vector3();
    private float currentDistTraveled; //used to determine how much of each player move is left to make


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
            if(Mathf.Abs(transform.position.x - movedPosition.x) < tolerance && Mathf.Abs(transform.position.y - movedPosition.y) < tolerance)
            {
                isCurrentlyMoving = false;
                transform.position = movedPosition;
                anim.SetBool("isRunning", false);
                // AIDestinationSetter.enemyMove();
                if (canSeePlayer(agroRange))
                {
                    isInAgro = true;
                }
                if (isInAgro)
                {
                    AIDestinationSetter.enemyMove();
                }
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
    bool canSeePlayer(float distance){
        bool val = false;
        float castDist = distance;
        //calculates end position
        Vector2 endPosition = castPoint.position + Vector3.right * distance;
        //action is player space can include walls 
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPosition);
        //if it hits anything
        if(hit.collider !=null){
            //if what it hits is player
            if(hit.collider.gameObject.CompareTag("Player")){
                //switch on agro mode
                val = true;
            }
            else{
                //not agro
                val = false;
            }

        }
        return val;
    }

}