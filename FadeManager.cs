using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed;
    public bool fading;

    private void Awake() {
        fadeImage.transform.localScale = new Vector2(Screen.width, Screen.height);
        StartCoroutine(Fade());
    }

    public IEnumerator Fade() {
        fading = true;
        yield return FadeIn();
        yield return new WaitForSeconds(0.5f);
        yield return FadeOut();
        fading = false;
    }

    public IEnumerator FadeIn() {
        while(fading) {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.black, fadeSpeed * Time.deltaTime);
            if (fadeImage.color.a >= 0.95f) {
                fadeImage.color = Color.black;
                yield break;
            }

            yield return null;
        }
    }

    public IEnumerator FadeOut() {
        while (fading) {
            fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, fadeSpeed * Time.deltaTime);
            if (fadeImage.color.a <= 0.05f) {
                fadeImage.color = Color.clear;
                yield break;
            }

            yield return null;
        }
    }
}
