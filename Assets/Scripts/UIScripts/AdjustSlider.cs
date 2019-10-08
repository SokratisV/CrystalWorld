using UnityEngine;
using UnityEngine.UI;

public class AdjustSlider : MonoBehaviour
{
    public MyPlayerSettings settings;

    private void Start()
    {
        GetComponent<Slider>().value = settings.edutainmentLevel;
    }
}
