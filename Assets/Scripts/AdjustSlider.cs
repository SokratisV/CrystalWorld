using UnityEngine;
using UnityEngine.UI;

public class AdjustSlider : MonoBehaviour
{
    public PlayerSettings settings;

    private void Start()
    {
        GetComponent<Slider>().value = settings.edutainmentLevel;
    }
}
