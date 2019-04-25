using UnityEngine;

public class AdjustColliderSize : MonoBehaviour
{
    private float initialHeight, adjustedHeight;
    private CapsuleCollider collider;

    private void Awake()
    {
        adjustedHeight = 1f;
        collider = GetComponent<CapsuleCollider>();
        initialHeight = collider.height;
    }

    void Update()
    {
        collider.height += Time.deltaTime * 1.35f;
        if (collider.height >= initialHeight)
        {
            collider.height = initialHeight;
            enabled = false;
        }
    }

    private void OnEnable()
    {
        initialHeight = collider.height;
        collider.height = adjustedHeight;
    }
}
