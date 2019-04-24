using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject oldManUI;
    private bool guided = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            //gameManager.GetComponent<NPCDialog>().ShowDefaultDialog();
            GetComponentInChildren<Animator>().SetTrigger("Talking");
            if (guided)
            {
                gameManager.GetComponent<NPCDialog>().ShowDefaultDialog();
            }
            else
            {
                guided = true;
                gameManager.GetComponent<NPCDialog>().ShowGuideDialog();
            }
        }
        if (oldManUI.activeSelf)
        {
            oldManUI.SetActive(false);
        }
    }
}
