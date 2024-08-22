using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Animator animator;
    public void nextScene()
    {
        StartCoroutine(nextSceneEnum());
    }
    public void HomeScene()
    {
        StartCoroutine(HomeSceneEnum());
    }
    public void restart()
    {
        StartCoroutine(RestartSceneEnum());
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator nextSceneEnum()
    {
        animator.SetBool("IsEnd", true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator HomeSceneEnum()
    {
        animator.SetBool("IsEnd", true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator RestartSceneEnum()
    {
        animator.SetBool("IsEnd", true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
