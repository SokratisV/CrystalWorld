using UnityEngine;

public class AdjustSoundWithDistance : MonoBehaviour
{
    public Transform player;
    public bool x = true;
    public bool y;
    public bool z;
    
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (x)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
        else if (y)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
        else if (z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z);
        }
    }
}
