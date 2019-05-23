using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AutoFade : MonoBehaviour
{
    public int index;
    public Image black;
    public Animator anim;


    public void LevelTransition(int indexToTransitionTo)
    {
        index = indexToTransitionTo;
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }
}
