using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transManager : MonoBehaviour
{
    public Animator anim;

    public void OnEnable()
    {
        anim.SetInteger("bIndex", SceneManager.GetActiveScene().buildIndex);
    }

    public void PlainsEncounter()
    {
        StartCoroutine(Transition());
    }

    public void GrassEncounter()
    {

    }

    IEnumerator Transition()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(1.05f);
        SceneManager.LoadScene(0);
    }


}
