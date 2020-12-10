using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class menuScript : MonoBehaviour
{
    public Animator deerAnim;
    public GameObject creditsPanel;
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    public void wakeDeer(){
        deerAnim.SetBool("wakeDeer",true);
    }
    public void credits(){
        mainPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    public void options(){
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void backToMain(){
        mainPanel.SetActive(true);
        creditsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void SetVolume(float volume){
        audioMixer.SetFloat("masterVolume",Mathf.Log10(volume)*20);
    }
}
