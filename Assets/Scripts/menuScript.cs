using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour
{
    public Animator deerAnim;
    public GameObject creditsPanel;
    public GameObject mainPanel;
    // Start is called before the first frame update
    public void wakeDeer(){
        deerAnim.SetBool("wakeDeer",true);
    }
    public void credits(){
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    public void backToMain(){
        mainPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
}
