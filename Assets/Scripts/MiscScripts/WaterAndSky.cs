using UnityEngine;

//[ExecuteAlways]
public class WaterAndSky : MonoBehaviour
{
    public Transform wind;
    [Header("Water Shader")]
    private float UvRotateSpeed = .3f;
    private float UvRotateDistance = .3f;
    public float UvBumpRotateSpeed = 1;
    private float UvBumpRotateDistance = 2;
    //[SerializeField]
    //private float rate = 10f;
    //[SerializeField]
    //private float time = 0f;
    //private bool increase;
    //public AnimationCurve curve;
    
    float timeTime;
    Vector2 Vector2one, lwVector, lwNVector, ssgVector;
    Vector3 Vector3forward;
    
    private void Awake()
    {
        lwVector = Vector2.zero;
        lwNVector = Vector2.zero;
        ssgVector = Vector2.zero;
    }

    void Update()
    {
        //if (time <= 0) increase = true;
        //if (time >= 1) increase = false;
        //if (increase)
        //{
        //    time += Time.deltaTime;
        //}
        //else
        //{
        //    time -= Time.deltaTime;
        //}
        //UvBumpRotateSpeed = Mathf.LerpUnclamped(-.15f, .15f, curve.Evaluate(time));

        if (timeTime != Time.time) timeTime = Time.time;
        if (Vector3forward != Vector3.forward) Vector3forward = Vector3.forward;
        if (Vector2one != Vector2.one) Vector2one = Vector2.one;        

        lwVector = Quaternion.AngleAxis(timeTime * UvRotateSpeed, Vector3forward) * Vector2one * UvRotateDistance;
        lwNVector = Quaternion.AngleAxis(timeTime * UvBumpRotateSpeed, Vector3forward) * Vector2one * UvBumpRotateDistance;

        Shader.SetGlobalFloat("_WaterLocalUvX", lwVector.x);
        Shader.SetGlobalFloat("_WaterLocalUvZ", lwVector.y);
        Shader.SetGlobalFloat("_WaterLocalUvNX", lwNVector.x);
        Shader.SetGlobalFloat("_WaterLocalUvNZ", lwNVector.y);

        wind.rotation = Quaternion.LookRotation(new Vector3(lwNVector.x, 0, lwNVector.y), Vector3.zero) * Quaternion.Euler(0, -40, 0);

    }
}
