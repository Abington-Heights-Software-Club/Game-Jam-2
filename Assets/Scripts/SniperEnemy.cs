using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SniperEnemy : MonoBehaviour
{
    public DeerMovement DeerMovement;
    public Transform raycastPosition;
    public SceneTransition SceneTransition;
    public float tolerance = 0.1f;
    private Vector3 enemyDirection = Vector3.right;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(DeerMovement.willMove);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            float zAngle = transform.eulerAngles.z + 90;
            transform.eulerAngles = new Vector3(0, 0, zAngle);
            if(Mathf.Abs(zAngle - 90) < tolerance)
            {
                enemyDirection = Vector3.up;
            }
            else if(Mathf.Abs(zAngle - 180) < tolerance) {
                enemyDirection = Vector3.left;
            }
            else if (Mathf.Abs(zAngle + 90) < tolerance) {
                enemyDirection = Vector3.down;
            }
            else if (Mathf.Abs(zAngle) < tolerance) {
                enemyDirection = Vector3.right;
            }
        }
        if (canSeePlayer())
        {
            SceneTransition.getCircleTransition(SceneManager.GetActiveScene().buildIndex);
        }
    }
    bool canSeePlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastPosition.position, enemyDirection);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneTransition.getCircleTransition(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
