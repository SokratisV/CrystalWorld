using UnityEngine;

public class TeleportMenu : MonoBehaviour
{
    public GameObject questionsMenuUI;
    public GameObject gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.GetComponent<GameManagement>().Pause();
            questionsMenuUI.SetActive(true);
        }
    }
}
