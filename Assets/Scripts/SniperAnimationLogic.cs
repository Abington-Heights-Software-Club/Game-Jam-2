using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAnimationLogic : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    public float tolerance = 0.1f;
    public bool rotate;
    public string initialDirection;
    public Transform logicRotation;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        if (!rotate)
        {
            if (initialDirection.ToLower().Equals("right"))
            {
                anim.SetTrigger("side");
                sprite.flipX = false;
            }
            else if (initialDirection.ToLower().Equals("left"))
            {
                anim.SetTrigger("side");
                sprite.flipX = true;
            }
            else if (initialDirection.ToLower().Equals("up"))
            {
                anim.SetTrigger("up");
                sprite.flipX = false;
            }
            else if (initialDirection.ToLower().Equals("down"))
            {
                anim.SetTrigger("down");
                sprite.flipX = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            float zAngle = logicRotation.eulerAngles.z + 90;
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
}
