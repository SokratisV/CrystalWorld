using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public AudioClip pickupSound;
    public GameObject gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            if (pickupSound != null)
            {
                gameManager.GetComponents<AudioSource>()[1].clip = pickupSound;
                gameManager.GetComponents<AudioSource>()[1].Play();
            }
            other.GetComponent<CrystalPiecesPickup>().QuestProgress();
        }
    }
}
