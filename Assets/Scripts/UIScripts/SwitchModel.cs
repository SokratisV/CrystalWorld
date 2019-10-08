using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchModel : MonoBehaviour
{
    public GameObject[] models;
    public Avatar[] avatars;
    public GameObject playerObject;
    private GameObject tempModel;
    private int index = 0;
    public MyPlayerSettings settings;

    private void Start()
    {
        ChooseModel(settings.character);
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
    public void ChooseModel(int number)
    {
        tempModel = Instantiate(models[number], playerObject.transform);
        playerObject.GetComponent<Animator>().avatar = avatars[number];
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
