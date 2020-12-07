using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator anim;
    private IEnumerator circleTransition(int level)
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(level);
    }
    public void getCircleTransition(int num){
        StartCoroutine(circleTransition(num));
    }
}
