using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CustomEnemyAI : MonoBehaviour
{

}
//     public Transform target;
//     public float nextWaypointDistance = 3f;
//     public Rigidbody2D rb;

//     Path path;
//     int currentWaypoint =0;
//     bool reachedEndOfPath = false;

//     Seeker seeker;

//     // Start is called before the first frame update
//     void Start()
//     {
//         seeker = GetComponent<Seeker>();
//         rb= GetComponent<Rigidbody2D>();    



//     }
//     void Update(){
//     if (Input.GetKeyDown(KeyCode.W))
//         {
//             moveEnemy();
//         }
// }

//     void OnPathComplete(Path p){
//         if (!p.error){
//             path = p;
//             currentWaypoint = 0;
//         }

//         }
    

//     // Update is called once per frame
//     void moveEnemy()
//     {
//         Vector3 movedPosition = new Vector3(transform.position.x, transform.position.y);
//         Vector2 moveDirection = new Vector2(0, 0);
//         seeker.StartPath(rb.position, target.position, OnPathComplete);

//         if (path ==null)
//             return;

//         if(currentWaypoint >= path.vectorPath.Count){
//             reachedEndOfPath = true;
//             return;
//         }
//         else{
//             reachedEndOfPath = false;
//         }
//         Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] -rb.position).normalized;
//         if(direction.y > 0){
//             movedPosition = new Vector3(transform.position.x, transform.position.y + 1);
//             moveDirection = Vector2.up;
//             Debug.Log("HEllo");
//         }
//         RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, 1, LayerMask.GetMask("Wall"));
//         if(hit.collider == null)
//             {
//                 transform.position = movedPosition;
//             }
        

//         float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
//         if(distance < nextWaypointDistance){
//             currentWaypoint++;
//         }
//     }

