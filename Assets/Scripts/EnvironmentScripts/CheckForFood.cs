using UnityEngine;

public class CheckForFood : MonoBehaviour
{
    public GameObject player;
    public float detectDistance;

    private void Start()
    {
        player.GetComponent<ThrowFood>().OnFoodThrow += CheckForFood_OnFoodThrow;
    }

    private void CheckForFood_OnFoodThrow(object sender, System.EventArgs e)
    {
        Vector3 pA = transform.position;
        Vector3 pB = player.transform.position;

        if ((pA-pB).sqrMagnitude < detectDistance * detectDistance)
        {
            player.GetComponent<ThrowFood>().OnFoodThrow -= CheckForFood_OnFoodThrow;
            AnimalSleep(((GameObject)sender));
            Destroy(player.GetComponent<RhinoKnockback>());
        }
    }

    private void AnimalSleep(GameObject food)
    {
        Destroy(GetComponent<RhinoAI>());
        GetComponent<RhinoSleep>().enabled = true;
        GetComponent<RhinoSleep>().food = food;
        enabled = false;
    }
}
