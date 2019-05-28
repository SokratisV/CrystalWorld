using UnityEngine;

public class TurnBasedOnCamera : MonoBehaviour {

    public GameObject objectToFollow;
    private Vector3 transformToFollow;

	void Start () {
	    if (objectToFollow == null)
        {
            objectToFollow = Camera.main.gameObject;
        }
        transformToFollow = 2 * transform.position - objectToFollow.transform.position;
    }
    void LateUpdate () {
        transformToFollow = 2 * transform.position - objectToFollow.transform.position;
        transformToFollow.y = transform.position.y;
        transform.LookAt(transformToFollow);
	}
}
