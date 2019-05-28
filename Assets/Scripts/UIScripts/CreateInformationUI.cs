using UnityEngine;

public class CreateInformationUI : MonoBehaviour
{
    public GameObject prefab;
    public GameObject worldSpaceCanvas;
    private GameObject tempObject;

    private void Start()
    {
        tempObject = Instantiate(prefab, worldSpaceCanvas.transform);
        tempObject.transform.position = transform.position;
        Vector3 tempPosition = transform.position;
        tempPosition.y += 2.5f;
        tempObject.transform.position = tempPosition;
    }

}
