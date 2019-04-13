using UnityEngine;

public class FoodPickup : MonoBehaviour
{
    public GameObject steak;
    public GameObject gameManager;
    public AudioClip pickupSound;
    public static bool enableFood = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (enableFood)
        {
            if (collision.transform.tag == "Player")
            {
                steak.SetActive(false);
                gameManager.GetComponents<AudioSource>()[1].clip = pickupSound;
                gameManager.GetComponents<AudioSource>()[1].Play();
                collision.gameObject.GetComponent<ThrowFood>().enabled = true;
                enableFood = false;
                collision.gameObject.GetComponent<ThrowFood>().enabled = true;
            }
        }
    }
}
