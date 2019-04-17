using UnityEngine;

public class ShowModel : MonoBehaviour
{
    public GameObject playerModels;
    public PlayerSettings settings;

    void Start()
    {
        playerModels.transform.GetChild(settings.character).gameObject.SetActive(true);    
    }

    public void ChangeModel()
    {
        playerModels.transform.GetChild(settings.character).gameObject.SetActive(false);
        if (settings.character == 7)
        {
            settings.character = 0;
        }
        else
        {
            settings.character += 1;
        }
        playerModels.transform.GetChild(settings.character).gameObject.SetActive(true);
    }
}
