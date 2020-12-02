using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    public Animator deerAnim;
    public Rigidbody2D deer;
    // Start is called before the first frame update
    public void wakeDeer(){
        deerAnim.SetBool("wakeDeer",true);
    }
}
