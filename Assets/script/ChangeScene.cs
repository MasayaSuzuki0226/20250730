using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1.0f;
    private bool isFading = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        fadePanel.color = new Color(1f, 1f, 1f, 0f); // 最初は透明
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFading)
        {
            StartCoroutine(FadeOutIn());
        }
    }

    IEnumerator FadeOutIn()
    {
        isFading = true;

        // フェードアウト（透明→白）
        yield return StartCoroutine(Fade(0f, 1f));

        //SceneManager.LoadScene("sceneB");

        // フェードイン（白→透明）
        yield return StartCoroutine(Fade(1f, 0f));

        isFading = false;
    }

    IEnumerator Fade(float fromAlpha, float toAlpha)
    {
        float elapsed = 0f;
        Color baseColor = Color.white;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(fromAlpha, toAlpha, elapsed / fadeDuration);
            fadePanel.color = new Color(baseColor.r, baseColor.g, baseColor.b, alpha);
            yield return null;
        }

        fadePanel.color = new Color(baseColor.r, baseColor.g, baseColor.b, toAlpha);
    }
}
//7 findanyobjectbytypeを使う→ヒューマンエラーを減らすためにオート化する
