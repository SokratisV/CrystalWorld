using UnityEngine;

public class TeleportMenu : MonoBehaviour
{
    public GameObject shipMenuUI;
    public GameObject gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.GetComponent<GameManagement>().Pause();
            shipMenuUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            print("playing");
            GetComponent<AudioSource>().Play();
        }
    }
}
