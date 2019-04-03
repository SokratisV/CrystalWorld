using UnityEngine;

public class SwitchModel : MonoBehaviour
{
    public GameObject[] models;
    public Avatar[] avatars;
    public GameObject playerObject;
    private GameObject tempModel;
    public int index = 0;

    private void Start()
    {
        ChangeModel();
    }
    
    public void ChangeModel()
    {
        if (playerObject.transform.childCount > 0)
        {
            Destroy(playerObject.transform.GetChild(0).gameObject);
        }
        tempModel = Instantiate(models[index], playerObject.transform);
        playerObject.GetComponent<Animator>().avatar = avatars[index];
        AdvanceIndex();
    }

    private void AdvanceIndex()
    {
        if (index + 1 == models.Length)
        {
            index = 0;
        }
        else
        {
            index++;
        }
    }
}
