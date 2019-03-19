using UnityEngine;

public class WindmillRotation : MonoBehaviour {

    public float degreesPerSecond = 75;

	void Update () {
        transform.Rotate(new Vector3(0f, 0f, -(Time.deltaTime * degreesPerSecond)));
	}
}
