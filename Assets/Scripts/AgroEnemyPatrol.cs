using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AgroEnemyPatrol : MonoBehaviour
{
    public AIDestinationSetter AIDestinationSetter;
    public int[] path;
    private int currentpos = -1;
    private bool isInAgro = false;
    private Vector3 enemyDirection =Vector3.right;
    public SceneTransition SceneManager;
    public GameObject raycastPosition;
    private bool isCurrentlyMoving = false;
    private Vector3 currentMove = new Vector3();
    private Vector3 movedPosition = new Vector3(0, 0);
    public float moveSpeed = 2.5f;
    public float tolerance = 0.07f;

    public void setEnemyDirection(Vector3 newDirection)
    {
        enemyDirection = newDirection;
    }
    public void setMovedPosition(Vector3 newPosition)
    {
        movedPosition = newPosition;
    }
    public void setMovedPosition(bool state)
    {
        isCurrentlyMoving = state;
    }
    private void Patrolling()
    {
        if(currentpos<path.Length-1){
            currentpos++;
        }   
        else{
            currentpos = 0;
        }
        if (path[currentpos] ==0){
            movedPosition = new Vector3(transform.position.x+1, transform.position.y);
            Vector3 newScale = transform.localScale;
            newScale.x = Mathf.Abs(newScale.x);
            transform.localScale = newScale;
            enemyDirection = Vector3.right;
        }
        else if(path[currentpos]==1){
             movedPosition = new Vector3(transform.position.x, transform.position.y+1);
             enemyDirection = Vector3.up;
        }
        else if(path[currentpos]==2){
            movedPosition = new Vector3(transform.position.x-1, transform.position.y);
            Vector3 newScale = transform.localScale;
            newScale.x = -Mathf.Abs(newScale.x);
            transform.localScale = newScale;
            enemyDirection = Vector3.left;
        }
        else if (path[currentpos]==3){
            movedPosition = new Vector3(transform.position.x, transform.position.y-1);
            enemyDirection = Vector3.down;
        }
        isCurrentlyMoving = true;
    }
    
    void Update(){
        if (canSeePlayer())
        {
            isInAgro = true;
        }
        if (isCurrentlyMoving)
        {
            if (isInAgro && enemyDirection == Vector3.zero)
            {
                enemyDirection = AIDestinationSetter.movedDirection;
                movedPosition = AIDestinationSetter.movedPosition;
            }
            else
            {
                Debug.Log("Moving");
                transform.position += enemyDirection * Time.deltaTime * moveSpeed;
                if (Mathf.Abs(transform.position.x - movedPosition.x) < tolerance && Mathf.Abs(transform.position.y - movedPosition.y) < tolerance)
                {
                    Debug.Log("Done Moving");
                    isCurrentlyMoving = false;
                    transform.position = movedPosition;
                    movedPosition = Vector3.zero;
                    enemyDirection = Vector3.zero;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                if (isInAgro)
                {
                    AIDestinationSetter.enemyMove();
                    isCurrentlyMoving = true;
                }
                else
                {
                    Patrolling();
                }
            }
        }     
    }


    bool canSeePlayer(){
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition.transform.position, enemyDirection);
        if (hit.collider !=null){
            if(hit.collider.gameObject.CompareTag("Player")){
                return true;
            }
        }
        return false;
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           SceneManager.getCircleTransition();
        }
    }
}
