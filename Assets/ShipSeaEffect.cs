using UnityEngine;

public class ShipSeaEffect : MonoBehaviour
{
    public int oscillationSpeed;

    void Update()
    {
        print(Mathf.Sin(Time.time * oscillationSpeed));
        transform.position = new Vector3(0, Mathf.Sin(Time.time * oscillationSpeed) * 10, 0);
    }
}
