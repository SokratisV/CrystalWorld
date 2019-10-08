using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class GameProgress : MonoBehaviour
{
    private bool villageCrystalCollected;
    private bool mazeCrystalCollected;
    private bool animalCrystalCollected;
    private NPCDialog dialogScript;

    public GameObject peasantManCurrent;
    public GameObject peasantManNew;
    public GameObject player;
    public Cinemachine.CinemachineVirtualCamera vcam6;
    public GameObject[] eduLevel0;
    public GameObject[] eduLevel1;
    public GameObject[] eduLevel2;
    public GameObject[] crystalCompleteImage;
    public GameObject mainMenuButton;
    public AudioClip thriller;

    private GameObject[][] eduLevels;

    public MyPlayerSettings settings;

    private void Start()
    {
        villageCrystalCollected = false;
        mazeCrystalCollected = false;
        animalCrystalCollected = false;
        //add all configurations of crystals to a [][] so that the proper reference can be used for the event subscription
        eduLevels = new GameObject[3][];
        eduLevels[0] = eduLevel0;
        eduLevels[1] = eduLevel1;
        eduLevels[2] = eduLevel2;

        //activate the crystals based on level
        eduLevels[settings.edutainmentLevel][0].transform.parent.gameObject.SetActive(true);

        eduLevels[settings.edutainmentLevel][0].GetComponent<Quest>().OnQuestComplete += GameProgress_OnQuestComplete;
        eduLevels[settings.edutainmentLevel][1].GetComponent<Quest>().OnQuestComplete += GameProgress_OnQuestComplete;
        eduLevels[settings.edutainmentLevel][2].GetComponent<Quest>().OnQuestComplete += GameProgress_OnQuestComplete;

        dialogScript = GetComponent<NPCDialog>();
    }

    private void GameProgress_OnQuestComplete(object sender, System.EventArgs e)
    {
        switch (((Quest)sender).questName)
        {
            case "village":
                //print("completed village quest");
                villageCrystalCollected = true;
                dialogScript.ShowDialog(1);
                crystalCompleteImage[0].SetActive(true);
                break;
            case "maze":
                //print("completed maze quest");
                mazeCrystalCollected = true;
                dialogScript.ShowDialog(2);
                crystalCompleteImage[1].SetActive(true);
                break;
            case "animal":
                //print("completed animal quest");
                animalCrystalCollected = true;
                dialogScript.ShowDialog(4);
                crystalCompleteImage[2].SetActive(true);
                break;
            default:
                print("Unknown quest");
                break;
        }
        if (settings.edutainmentLevel == 1)
        {
            GetComponent<GameManagement>().ToggleMiniGames();
        }
        else if (settings.edutainmentLevel == 2)
        {
            GetComponent<GameManagement>().ToggleQuestions();
        }
        if (villageCrystalCollected && mazeCrystalCollected && animalCrystalCollected)
        {
            StartCoroutine(WonTheGame());
        }
    }
    private IEnumerator WonTheGame()
    {
        GetComponent<PlayableDirector>().Play();
        peasantManCurrent.SetActive(false);
        peasantManNew.SetActive(true);
        peasantManNew.GetComponent<VictoryDance>().Victory();
        player.GetComponent<VictoryDance>().Victory();
        GetComponents<AudioSource>()[0].clip = thriller;
        GetComponents<AudioSource>()[0].volume = .025f;
        GetComponents<AudioSource>()[0].Play();
        vcam6.Priority = 15;
        yield return new WaitForSeconds(9f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        mainMenuButton.SetActive(true);
        dialogScript.ShowDialog(6);
        yield return new WaitForSeconds(5 * 60 + 5);
        GetComponent<GameManagement>().ChangeScene(0);
    }
}
