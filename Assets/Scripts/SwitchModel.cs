using System.Collections;
using UnityEngine;

public class SwitchModel : MonoBehaviour
{
    public GameObject[] models;
    public Avatar[] avatars;
    public GameObject playerObject;
    private GameObject tempModel;
    private int index = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tempModel = GameObject.Instantiate<GameObject>(models[index], playerObject.transform);
            //Add tag model and destroy that, fix for T pose extra model
            GameObject.Destroy(playerObject.transform.GetChild(0).gameObject);
            playerObject.GetComponent<Animator>().avatar = avatars[index];
            AdvanceIndex();
        }
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
