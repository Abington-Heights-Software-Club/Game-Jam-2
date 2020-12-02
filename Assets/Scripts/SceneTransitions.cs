using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator sceneAnim;
    public string sceneName;

    public void changeScene(){
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene(){
        yield return new WaitForSeconds(1.5f);
        sceneAnim.SetTrigger("endScene");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
