using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{

    public Text TimelineText;
    public Text TroubleText;

    public Image Background;

    public void StartAnimations()
    {
        StartCoroutine(RandomTextEffect(TimelineText));
        StartCoroutine(RandomTextEffect(TroubleText));

        StartCoroutine(RandomColorEffect(TimelineText));
        StartCoroutine(RandomColorEffect(TroubleText));

        StartCoroutine(RandomBG());
    }

    IEnumerator RandomTextEffect(Text text)
    {
        while (true)
        {
            float duration = Random.Range(0.02f, 0.15f);
            text.rectTransform.DOShakePosition(duration, Vector3.right * Random.Range(-50f, 50f)).OnComplete(() =>
            {

            });
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }

    IEnumerator RandomColorEffect(Text text)
    {
        while (true)
        {
            float value = Random.Range(0.1f, 0.6f);
            float duration = Random.Range(0.05f, 0.1f);
            text.DOFade(value, duration).OnComplete(() =>
            {
                text.DOFade(0.9f, 0f);
            });
            yield return new WaitForSeconds(Random.Range(0.1f, 1.5f));
        }
    }

    IEnumerator RandomBG()
    {
        bool blue = true;
        while (true)
        {
            Color c = blue ? new Color(0f, 0f, 40f / 255f, 1f) : new Color(30f / 255f, 0f, 0f, 1f);
            Background.DOColor(c, 4f).OnComplete(() =>
            {
                Background.DOColor(Color.black, 4f);
            });
            blue = !blue;
            yield return new WaitForSeconds(10f);
        }
    }
}
