using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject oldManUI;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            gameManager.GetComponent<NPCDialog>().ShowDefaultDialog();
        }
        if (oldManUI.activeSelf)
        {
            oldManUI.SetActive(false);
        }
    }
}
