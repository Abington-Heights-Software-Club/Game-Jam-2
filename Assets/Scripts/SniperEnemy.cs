﻿using System.Collections;
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
    public bool rotate;
    //Use only when rotate == false. Options: "right", "left", "up", "down"
    public string initialDirection;
    public GameObject gunParticles;
    private bool notDoneShooting = true;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        if(!rotate)
        {
            if(initialDirection.ToLower().Equals("right"))
            {
                enemyDirection = Vector3.right;
            }
            else if (initialDirection.ToLower().Equals("left"))
            {
                enemyDirection = Vector3.left;
            }
            else if (initialDirection.ToLower().Equals("up"))
            {
                enemyDirection = Vector3.up;
            }
            else if (initialDirection.ToLower().Equals("down"))
            {
                enemyDirection = Vector3.down;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            float zAngle = transform.eulerAngles.z + 90;
            if(zAngle == 360)
            {
                zAngle = 0;
            }
            transform.eulerAngles = new Vector3(0, 0, zAngle);
            animationChange();
            if (Mathf.Abs(zAngle - 90) < tolerance)
            {
                enemyDirection = Vector3.up;
            }
            else if(Mathf.Abs(zAngle - 180) < tolerance) {
                enemyDirection = Vector3.left;
            }
            else if (Mathf.Abs(zAngle - 270) < tolerance) {
                enemyDirection = Vector3.down;
            }
            else if (Mathf.Abs(zAngle) < tolerance) {
                enemyDirection = Vector3.right;
            }
        }
        if (canSeePlayer() && notDoneShooting)
        {
            Instantiate(gunParticles, raycastPosition.position, Quaternion.identity);
            SceneTransition.getCircleTransition(SceneManager.GetActiveScene().buildIndex);
            notDoneShooting = false;
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
    private void animationChange()
    {
        float zAngle = transform.eulerAngles.z;
        Animator anim = UI.GetComponent<Animator>();
        SpriteRenderer sprite = UI.GetComponent<SpriteRenderer>();

            if (zAngle == 360)
            {
                zAngle = 0;
            }
            Debug.Log("zAngle: " + zAngle);
            if (Mathf.Abs(zAngle - 90) < tolerance)
            {
                anim.SetTrigger("up");
                sprite.flipX = false;
            }
            else if (Mathf.Abs(zAngle - 180) < tolerance)
            {
                anim.SetTrigger("side");
                sprite.flipX = true;
            }
            else if (Mathf.Abs(zAngle - 270) < tolerance)
            {
                anim.SetTrigger("down");
                sprite.flipX = false;
            }
            else if (Mathf.Abs(zAngle) < tolerance)
            {
                anim.SetTrigger("side");
                sprite.flipX = false;
            }
    }
}
