using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CustomEnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    private Rigidbody2D rb;

    private Vector3 currentMove = new Vector3();

    Path path;
    int currentWaypoint =0;
    bool reachedEndOfPath = false;

    Seeker seeker;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb= GetComponent<Rigidbody2D>();    
    }
    void Update(){
    if (Input.GetKeyDown(KeyCode.W))
        {
            moveEnemy();
        }
}

    void OnPathComplete(Path p){
        if (!p.error){
            path = p;
            currentWaypoint = 0;
        }

        }
    

    // Update is called once per frame
    void moveEnemy()
    {
        seeker.StartPath(rb.position, target.position, OnPathComplete);

        if (path ==null)
            return;

        if(currentWaypoint >= path.vectorPath.Count){
            reachedEndOfPath = true;
            return;
        }
        else{
            reachedEndOfPath = false;
        }
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
    }
}
