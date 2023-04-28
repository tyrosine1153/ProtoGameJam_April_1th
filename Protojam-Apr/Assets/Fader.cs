using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fader : MonoSingleton<Fader>
{
    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private Image progressImage;

    string loadingSceneName;

    public void LoadScene(string sceneName)
    {
        if (string.IsNullOrEmpty(loadingSceneName))
        {
            gameObject.SetActive(true);
            SceneManager.sceneLoaded += LoadSceneEnd;
            loadingSceneName = sceneName;
            StartCoroutine(Load(sceneName));
        }
    }

    private IEnumerator Load(string sceneName)
    {
        progressImage.fillAmount = 0f;
        yield return StartCoroutine(Fade(true));

        AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.unscaledDeltaTime;

            if (op.progress < 0.9f)
            {
                progressImage.fillAmount = Mathf.Lerp(progressImage.fillAmount, op.progress, timer);
                if (progressImage.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressImage.fillAmount = Mathf.Lerp(progressImage.fillAmount, 1f, timer);

                if (progressImage.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    private void LoadSceneEnd(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == loadingSceneName)
        {
            StartCoroutine(Fade(false));
            SceneManager.sceneLoaded -= LoadSceneEnd;
            loadingSceneName = string.Empty;
        }
    }

    private IEnumerator Fade(bool isFadeIn)
    {
        float timer = 0f;

        while (timer <= 1f)
        {
            yield return null;
            timer += Time.unscaledDeltaTime * 2f;
            canvasGroup.alpha = Mathf.Lerp(isFadeIn ? 0 : 1, isFadeIn ? 1 : 0, timer);
        }

        if (!isFadeIn)
        {
            gameObject.SetActive(false);
        }
    }
}
