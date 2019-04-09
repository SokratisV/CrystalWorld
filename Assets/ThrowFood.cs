using System;
using UnityEngine;

public class ThrowFood : MonoBehaviour
{
    public event EventHandler OnFoodThrow;
    public GameObject foodPrefab;
    public int force;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject food = Instantiate(foodPrefab, transform.up+transform.position+(transform.forward)*2, transform.rotation);
            food.GetComponent<Rigidbody>().AddForce(food.transform.forward*force);
            OnFoodThrow?.Invoke(food, EventArgs.Empty);
        }
    }
}
