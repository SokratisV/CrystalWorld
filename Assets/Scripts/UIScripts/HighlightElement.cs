using TMPro;
using UnityEngine;

public class HighlightElement : MonoBehaviour
{
    private Color defaultColor;
    public Color highlightedColor;
    public PlayerSettings settings;

    private void Start()
    {
        defaultColor = new Color(255,255,255);
        //highlightedColor = new Color(180,0,150);
        Highlight(settings.edutainmentLevel);
    }

    public void Highlight(float value)
    {
        for (int i = 0; i < 3; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>().color = defaultColor;
        }
        transform.GetChild((int)value).gameObject.GetComponent<TextMeshProUGUI>().color = highlightedColor;
    }
}
