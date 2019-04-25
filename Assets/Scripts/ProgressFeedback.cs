using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressFeedback : MonoBehaviour
{
    private float timeOfTravel = .3f;
    private float currentTime = 0f;
    private float normalizedValue;
    private RectTransform rectTransform;
    private Vector3 endPosition;
    private Vector3 startPosition;
    private Color colorStart;
    private Color colorEnd;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        endPosition = rectTransform.anchoredPosition;
        endPosition.x = 9;
        startPosition = rectTransform.anchoredPosition;
        colorStart = GetComponent<Image>().color;
        colorEnd = Color.green;
        colorEnd.a = 1f;
    }

    public void GiveFeedback()
    {
        currentTime = 0f;
        StartCoroutine(LerpObject());
    }

    private IEnumerator LerpObject()
    {
        GetComponent<Image>().color = colorEnd;
        while(currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;
            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, endPosition, normalizedValue);
            yield return null;
        }
        while (currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel;
            rectTransform.anchoredPosition = Vector3.Lerp(startPosition, endPosition, normalizedValue);
            print(normalizedValue);
            yield return null;
        }
        GetComponent<Image>().color = colorStart;
    }
}
