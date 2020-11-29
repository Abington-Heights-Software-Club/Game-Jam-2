using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{
    [SerializeField]
    Transform castPoint;
    private float agroRange = 3;
    void Update(){
        if(canSeePlayer(agroRange)){

        }
    }

    bool canSeePlayer(float distance){
        bool val = false;
        float castDist = distance;
        //calculates end position
        Vector2 endPosition = castPoint.position + Vector3.right * distance;
        //action is player space can include walls 
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPosition, 1 << LayerMask.NameToLayer("Action"));
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
