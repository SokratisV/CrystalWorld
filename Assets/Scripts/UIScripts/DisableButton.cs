using UnityEngine;

public class DisableButton : MonoBehaviour
{
    public GameObject gameManager;

    private void OnEnable()
    {
        int temp = gameManager.GetComponent<GameManagement>().currentArea;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (temp == i)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
