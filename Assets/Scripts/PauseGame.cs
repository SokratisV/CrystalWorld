using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject cinemachineObject;
    [SerializeField]
    private bool isPaused = false;
    private Moving movingScript;
    private Climbing climbingScript;
    private bool wasMoving = true, wasClimbing = false;
    private float maxSpeedX, maxSpeedY;
    private Cinemachine.CinemachineFreeLook freeLookScript;


    private void Awake()
    {
        movingScript = GetComponent<Moving>();
        climbingScript = GetComponent<Climbing>();
        freeLookScript = cinemachineObject.GetComponent<Cinemachine.CinemachineFreeLook>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }       
    }

    public void Pause()
    {
        if (isPaused)
        {
            //Re-activate the necessary scripts
            movingScript.enabled = wasMoving;
            climbingScript.enabled = wasClimbing;
            //Show cursor
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //Reset Cinemachine
            freeLookScript.m_XAxis.m_MaxSpeed = maxSpeedX;
            freeLookScript.m_YAxis.m_MaxSpeed = maxSpeedY;
            isPaused = false;
        }
        else
        {
            //Lock cinemachine rotation
            maxSpeedX = freeLookScript.m_XAxis.m_MaxSpeed;
            maxSpeedY = freeLookScript.m_YAxis.m_MaxSpeed;
            freeLookScript.m_XAxis.m_MaxSpeed = 0;
            freeLookScript.m_YAxis.m_MaxSpeed = 0;
            //cinemachineCamera.SetActive(false);
            movingScript.ZeroInputs();
            //Save script state
            wasMoving = movingScript.enabled;
            wasClimbing = climbingScript.enabled;
            //Disable movement scripts
            movingScript.enabled = false;
            climbingScript.enabled = false;
            //Hide cursor
            Cursor.lockState = CursorLockMode.Locked;
            isPaused = true;
        }

    }
}
