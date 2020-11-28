using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CustomEnemyAI : MonoBehaviour
{
<<<<<<< HEAD
        
<<<<<<< HEAD
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public Rigidbody2D rb;
=======
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    private Rigidbody2D rb;

    private Vector3 currentMove = new Vector3();
>>>>>>> d873e4d20001b41d3c806a382522c2d0e34ef9d3
=======
//     public Transform target;
//     public float speed = 200f;
//     public float nextWaypointDistance = 3f;
//     public Rigidbody2D rb;
>>>>>>> parent of 90c7419... FixedPathfinder

//     Path path;
//     int currentWaypoint =0;
//     bool reachedEndOfPath = false;

//     Seeker seeker;

<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb= GetComponent<Rigidbody2D>();    
<<<<<<< HEAD
=======
//     // Start is called before the first frame update
//     void Start()
//     {
//         seeker = GetComponent<Seeker>();
//         rb= GetComponent<Rigidbody2D>();    
>>>>>>> parent of 90c7419... FixedPathfinder


//         //this is key with timing with player
//         InvokeRepeating("UpdatePath", 0f,.5f);

//     }

<<<<<<< HEAD
    void UpdatePath(){
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
=======
    }
    void Update(){
    if (Input.GetKeyDown(KeyCode.W))
        {
            moveEnemy();
        }
}
>>>>>>> d873e4d20001b41d3c806a382522c2d0e34ef9d3
=======
//     void UpdatePath(){
//         seeker.StartPath(rb.position, target.position, OnPathComplete);
//     }
>>>>>>> parent of 90c7419... FixedPathfinder

//     void OnPathComplete(Path p){
//         if (!p.error){
//             path = p;
//             currentWaypoint = 0;
//         }

//         }
    

<<<<<<< HEAD
    // Update is called once per frame
<<<<<<< HEAD
    public void enemyMove()
    {
        //Vector3 movePosition = new Vector3(0, 0);
=======
    void moveEnemy()
    {
        seeker.StartPath(rb.position, target.position, OnPathComplete);

>>>>>>> d873e4d20001b41d3c806a382522c2d0e34ef9d3
        if (path ==null)
            return;

        if(currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }
        else{
            reachedEndOfPath = false;
        }
<<<<<<< HEAD

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] -rb.position),normalized;
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance){
            currentWaypoint++;
        }
        Debug.Log(direction);
        // if(Input.GetKeyDown(KeyCode.W)) {
        //     movePosition = new Vector3(transform.position.x + 1, transform.position.y);
        //     transform.position = movePosition;
        // }
=======
//     // Update is called once per frame
//     void Update()
//     {
//         if (path ==null)
//             return;
>>>>>>> parent of 90c7419... FixedPathfinder

//         if(currentWaypoint >= path.vectorPath.Count){
//             reachedEndOfPath = true;
//             return;
//         }
//         else{
//             reachedEndOfPath = false;
//         }

<<<<<<< HEAD
    void Update() {
        
=======
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Debug.Log(direction.y);
        if(direction.y > 0){
            transform.position = new Vector3(transform.position.x, transform.position.y + 1);
            Debug.Log("HEllo");
        }
        

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance){
            currentWaypoint++;
        }
>>>>>>> d873e4d20001b41d3c806a382522c2d0e34ef9d3
    }
}
=======
//         Vector2 direction = direction = ((Vector2)path.vectorPath[currentWaypoint] -rb.position),normalized;
//         Debug.Log(direction);
//         Vector2 force = direction * speed * Time.deltaTime;

//         rb.AddForce(force);

//         float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
//         if(distance < nextWaypointDistance){
//             currentWaypoint++;
//         }
//     }
// }

}
>>>>>>> parent of 90c7419... FixedPathfinder
