using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    Player player;
    public string sceneName;
    public GameObject pauseMenu;

    public void Start()
    {
        player = GetComponent<Player>();
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    public void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel +1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }




    public float fadeTime = 1;
    public RectTransform rectTransform;
    public CanvasGroup canvasGroup;

    public void FadeIn()
    {
        canvasGroup.alpha = 0;
        rectTransform.transform.localScale = new Vector3(0, -1000f, 0);
        rectTransform.DOAnchorPos(new Vector2(0, 0), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
    }

    public void FadeOut()
    {
        canvasGroup.alpha = 1;
        rectTransform.transform.localScale = new Vector3(0, 0, 0);
        rectTransform.DOAnchorPos(new Vector2(0, 0), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime);
    }
}
