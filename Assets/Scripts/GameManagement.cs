using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    public GameObject escMenuCanvas;
    public GameObject settingsMenuCanvas;
    public GameObject player;
    public Terrain terrain;
    public GameObject cinemachineCamera;
    public Slider educationalSlider;
    public PostProcessProfile profile;
    public GameObject shipMenuUI;
    public GameObject controlsPanel;
    public PlayerSettings settings;

    [SerializeField]
    private bool isPaused = false;
    private Moving movementScript;
    private Climbing climbingScript;
    private Cinemachine.CinemachineFreeLook cinemachineScript;
    private Animator controlsPanelAnimator;
    private bool minigameQuestionSwitch = false;
    private bool questionsActive = false, miniGamesActive = false, escMenuActive = false, settingsActive = false, shipMenuActive = false;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        movementScript = player.GetComponent<Moving>();
        climbingScript = player.GetComponent<Climbing>();
        cinemachineScript = cinemachineCamera.GetComponent<Cinemachine.CinemachineFreeLook>();
        controlsPanelAnimator = controlsPanel.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!miniGamesActive && !questionsActive && !shipMenuActive)
            {
                if (!settingsActive)
                {
                    EscapeMenuPause();
                    //print("Toggle Esc Menu");
                }
                else
                {
                    //print("Toggle Settings");
                    Settings();
                }
            }
            else if (miniGamesActive)
            {
                //print("Toggle Mini Games");
                ToggleMiniGames();
            }
            else if (questionsActive)
            {
                //print("Toggle questions");
                ToggleQuestions();
            }
            else if (shipMenuActive)
            {
                ToggleShipUI();
                //print("Toggle Ship Menu");
            }
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ToggleQuestions();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ToggleShipUI();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            ToggleMiniGames();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            controlsPanelAnimator.SetTrigger("Enable");
        }
        //if (Input.GetKeyUp(KeyCode.Tab))
        //{
        //    controlsPanelAnimator.SetTrigger("Disable");
        //}
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    GetComponent<SwitchModel>().ChangeModel();
        //}

    }
    /*
     * Pauses and unpauses game.
     */
    public void Pause()
    {
        if (isPaused)
        {
            isPaused = false;
            movementScript.allowMovement = true;
            climbingScript.allowClimbing = true;
            Time.timeScale = 1;
        }
        else
        {
            isPaused = true;
            movementScript.allowMovement = false;
            climbingScript.allowClimbing = false;
            Time.timeScale = 0;
        }
    }
    public void EscapeMenuPause()
    {
        if (isPaused)
        {
            escMenuCanvas.SetActive(false);
            isPaused = false;
            movementScript.allowMovement = true;
            climbingScript.allowClimbing = true;
            Time.timeScale = 1;
            escMenuActive = false;
        }
        else
        {
            escMenuCanvas.SetActive(true);
            isPaused = true;
            movementScript.allowMovement = false;
            climbingScript.allowClimbing = false;
            Time.timeScale = 0;
            escMenuActive = true;
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
    public void ToggleShipUI()
    {
        Pause();
        shipMenuActive = !shipMenuActive;
        shipMenuUI.SetActive(shipMenuActive);
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
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
        if (isPaused)
        {
            Pause();
        }
    }
    public void ToggleQuestions()
    {
        GetComponent<LoadFromJSON>().ToggleQuestionMenu();
        questionsActive = !questionsActive;
    }
    public void ToggleMiniGames()
    {
        GetComponent<SwitchGame>().ToggleMiniGames();
        miniGamesActive = !miniGamesActive;
    }
    public void SaveSliderValue(float value)
    {
        settings.edutainmentLevel = (int)value;
    }
    public void ControlVSync(bool value)
    {
        if (value)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
    public void ControlMotionBlur(bool value)
    {
        if (value)
        {         
        }
        else
        {
        }
    }
}
