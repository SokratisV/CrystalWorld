using UnityEngine;

public class ShowModel : MonoBehaviour
{
    public GameObject playerModels;
    public MyPlayerSettings settings;

    void Start()
    {
        playerModels.transform.GetChild(settings.character).gameObject.SetActive(true);
    }

    public void ChangeModel()
    {
        playerModels.transform.GetChild(settings.character).gameObject.SetActive(false);
        if (settings.character == 5)
        {
            settings.character = 0;
        }
        else
        {
            settings.character += 1;
        }
        playerModels.transform.GetChild(settings.character).gameObject.SetActive(true);
        playerModels.transform.GetChild(settings.character).GetComponent<Animator>().SetTrigger("Wave");
    }
}
