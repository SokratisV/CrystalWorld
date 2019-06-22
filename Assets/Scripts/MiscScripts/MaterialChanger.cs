using UnityEngine;

public class MaterialChanger : MonoBehaviour {

    public GameObject modelSurface;
    public GameObject modelJoints;
    public Material[] materials;
    private int index = 0;
    private float i;

    private void Start()
    {
        modelSurface.GetComponent<Renderer>().material = materials[index++];
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Crystal")
        {
            i = Random.Range(0.0f, 1.0f);
            if ( i > 0.5f )
            {
                modelSurface.GetComponent<Renderer>().material = collision.transform.GetChild(0).GetComponent<Renderer>().material;
            }
            else
            {
                modelJoints.GetComponent<Renderer>().material = collision.transform.GetChild(0).GetComponent<Renderer>().material;
            }
        }

    }
}
