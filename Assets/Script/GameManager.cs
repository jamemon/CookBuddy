using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Animator animator;
    public void nextScene()
    {
        AudioManager.instance.PlaySFX("Click",true);
        StartCoroutine(nextSceneEnum());
    }
    public void HomeScene()
    {
        AudioManager.instance.PlaySFX("Click", true);
        StartCoroutine(HomeSceneEnum());
    }
    public void restart()
    {
        AudioManager.instance.PlaySFX("Click", true);
        StartCoroutine(RestartSceneEnum());
    }
    public void Quit()
    {
        AudioManager.instance.PlaySFX("Click", true);
        Application.Quit();
    }
    public void checkActive(GameObject optionUI)
    {
        AudioManager.instance.PlaySFX("Click", true);
        if (optionUI.activeSelf == false)
        {
            optionUI.SetActive(true);

        }
        else
        {
            optionUI.SetActive(false);
        }
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
