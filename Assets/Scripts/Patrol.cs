using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Patrol : MonoBehaviour
{
    public AIDestinationSetter AIDestinationSetter;
    public int[] path;
    private int currentpos = -1;
    private bool isInAgro = false;
    public Transform castPoint;
    private Vector3 enemyDirection =Vector3.right;
    public SceneTransition SceneManager;

    private void Patrolling()
    {
        if(currentpos<path.Length-1){
            currentpos++;
        }   
        else{
            currentpos = 0;
        }
        if (path[currentpos] ==0){
             transform.position= new Vector3(transform.position.x+1, transform.position.y);
             enemyDirection = Vector3.right;
        }
        else if(path[currentpos]==1){
             transform.position= new Vector3(transform.position.x, transform.position.y+1);
             enemyDirection = Vector3.up;
        }
        else if(path[currentpos]==2){
            transform.position= new Vector3(transform.position.x-1, transform.position.y);
            enemyDirection = Vector3.left;
        }
        else if (path[currentpos]==3){
            transform.position= new Vector3(transform.position.x, transform.position.y-1);
            enemyDirection = Vector3.down;
        }
        }
    
    void Update(){
        if (canSeePlayer()){
                    isInAgro = true;
                }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ){
        if (isInAgro){
            AIDestinationSetter.enemyMove();
            }

        else{
            Patrolling();
            }
        }
              
    }


    bool canSeePlayer(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, enemyDirection);
        if(hit.collider !=null){
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
