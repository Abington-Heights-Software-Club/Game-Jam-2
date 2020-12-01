using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Patrol : MonoBehaviour
{
    public AIDestinationSetter AIDestinationSetter;
    public int[] path;
    private int currentpos = 0;
    private bool isInAgro = false;
    private float agroRange = 3;
    public Transform castPoint;

    private void Agro(){

    }
    // Update is called once per frame
    private void Patrolling()
    {   
        if(currentpos<path.Length){
            
       
        if (path[currentpos] ==0){
             transform.position= new Vector3(transform.position.x+1, transform.position.y);
        }
        else if(path[currentpos]==1){
             transform.position= new Vector3(transform.position.x, transform.position.y+1);
        }
        else if(path[currentpos]==2){
            transform.position= new Vector3(transform.position.x-1, transform.position.y);
        }
        else if (path[currentpos]==3){
            transform.position= new Vector3(transform.position.x, transform.position.y-1);
        }
        }
        currentpos++;
    }
    void Update(){

        if (canSeePlayer(agroRange))
                {
                    isInAgro = true;
                }
                if (isInAgro)
                {
                    AIDestinationSetter.enemyMove();
                }
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
