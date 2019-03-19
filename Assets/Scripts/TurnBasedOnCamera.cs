using UnityEngine;

public class TurnBasedOnCamera : MonoBehaviour {

    public GameObject objectToFollow;
    private Vector3 transformToFollow;
    public bool x, y, z;

	void Start () {
	    if (objectToFollow == null)
        {
            objectToFollow = GameObject.FindWithTag("Player");
        }
        transformToFollow = 2 * transform.position - objectToFollow.transform.position;
    }
    void LateUpdate () {
        transformToFollow = 2 * transform.position - objectToFollow.transform.position;
        transformToFollow.y = transform.position.y;
        transform.LookAt(transformToFollow);
	}
}
