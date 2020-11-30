using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    [SerializeField]
    Transform castPoint;
    private Vector3 direction = Vector3.right;
    void Update()
    {
        patrol(direction);
    }

    void patrol(Vector3 direction)
    {
        bool val = false;
        //calculates end position
        Vector2 endPosition = castPoint.position + direction;
        //action is player space can include walls 
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPosition);
        //if it hits anything
        if (hit.collider != null)
        {
            //if what it hits is wall
            if (hit.collider.gameObject.layer.Equals("Wall"))
            {
                direction = new Vector3(-direction.x, -direction.y);
            }

        }
        else //doesnt hit anything
        {
            transform.position += direction;
        }
        transform.position += direction;
    }
}
