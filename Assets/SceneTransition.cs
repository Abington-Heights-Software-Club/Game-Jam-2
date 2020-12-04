using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator anim;
    private IEnumerator circleTransition()
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void getCircleTransition(){
        StartCoroutine(circleTransition());
    }
}
