using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public GameObject escMenuCanvas;
    public GameObject settingsMenuCanvas;
    public GameObject player;
    public Terrain terrain;
    public GameObject cinemachineCamera;

    [SerializeField]
    private bool isPaused = false;
    private bool settingsActive = false;
    private Moving movementScript;
    private Climbing climbingScript;
    private Cinemachine.CinemachineFreeLook cinemachineScript;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        movementScript = player.GetComponent<Moving>();
        climbingScript = player.GetComponent<Climbing>();
        cinemachineScript = cinemachineCamera.GetComponent<Cinemachine.CinemachineFreeLook>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Pause();
            }
            else
            {
                if (settingsActive)
                {
                    Settings();
                }
                else
                {
                    Pause();
                }
            }
        }       
    }
    public void Pause()
    {
        if (isPaused)
        {
            escMenuCanvas.SetActive(false);
            isPaused = false;
            movementScript.allowMovement = true;
            climbingScript.allowClimbing = true;
            Time.timeScale = 1;
        }
        else
        {
            escMenuCanvas.SetActive(true);
            isPaused = true;
            movementScript.allowMovement = false;
            climbingScript.allowClimbing = false;
            Time.timeScale = 0;
        }
    }
    public void Settings()
    {
        if (settingsActive)
        {
            settingsMenuCanvas.SetActive(false);
            escMenuCanvas.SetActive(true);
            isPaused = true;
            settingsActive = false;
        }
        else
        {
            settingsMenuCanvas.SetActive(true);
            escMenuCanvas.SetActive(false);
            isPaused = false;
            settingsActive = true;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ChangeFOV(float value)
    {
        cinemachineScript.m_Lens.FieldOfView = value;
    }
    public void ChangeViewDistance(float value)
    {
        cinemachineScript.m_Lens.FarClipPlane = value;
    }
    public void ChangePixelError(float value)
    {
        terrain.heightmapPixelError = value;
    }
}
