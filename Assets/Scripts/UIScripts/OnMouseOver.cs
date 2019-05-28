using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Shadow))]
public class OnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public AudioClip mouseOverSound;
    private Vector3 scaleUp;
    private Vector3 scaleNormal;
    private Shadow shadowScript;
    private new AudioSource audio;

    private void Start()
    {
        scaleUp = new Vector3(1.07f, 1.07f, 1);
        scaleNormal = transform.localScale;
        shadowScript = GetComponent<Shadow>();
        audio = GameObject.FindWithTag("GameController").GetComponents<AudioSource>()[1];
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = scaleUp;
        shadowScript.enabled = true;
        audio.clip = mouseOverSound;
        audio.Play();
    }
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = scaleNormal;
        shadowScript.enabled = false;
    }
}
