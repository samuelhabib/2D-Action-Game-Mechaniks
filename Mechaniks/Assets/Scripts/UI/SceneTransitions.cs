using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    private Animator transitionAnim;

    private void Start()
    {
        transitionAnim = GetComponent<Animator>();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    } 

    IEnumerator Transition(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(0.5f);
    }


}
