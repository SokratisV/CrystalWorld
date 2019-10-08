using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public AudioClip pickupSound;
    public GameObject gameManager;
    public MyPlayerSettings settings;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectible")
        {
            other.GetComponent<CrystalPiecesPickup>().QuestProgress(settings.edutainmentLevel, gameManager.GetComponent<GameManagement>());
            if (pickupSound != null)
            {
                gameManager.GetComponents<AudioSource>()[1].clip = pickupSound;
                gameManager.GetComponents<AudioSource>()[1].Play();
            }
        }
    }
}
