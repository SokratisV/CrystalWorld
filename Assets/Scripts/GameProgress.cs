using UnityEngine;

public class GameProgress : MonoBehaviour
{
    private bool villageCrystalCollected;
    private bool mazeCrystalCollected;
    private bool animalCrystalCollected;
    private NPCDialog dialogScript;

    public GameObject[] eduLevel0;
    public GameObject[] eduLevel1;
    public GameObject[] eduLevel2;
    public GameObject[] crystalCompleteImage;

    private GameObject[][] eduLevels;

    public PlayerSettings settings;

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
                print("completed village quest");
                villageCrystalCollected = true;
                eduLevels[settings.edutainmentLevel][0].GetComponent<Quest>().OnQuestComplete -= GameProgress_OnQuestComplete;
                dialogScript.ShowDialog(1);
                crystalCompleteImage[0].SetActive(true);
                break;
            case "maze":
                print("completed maze quest");
                mazeCrystalCollected = true;
                eduLevels[settings.edutainmentLevel][1].GetComponent<Quest>().OnQuestComplete -= GameProgress_OnQuestComplete;
                dialogScript.ShowDialog(2);
                crystalCompleteImage[1].SetActive(true);
                break;
            case "animal":
                print("completed animal quest");
                animalCrystalCollected = true;
                eduLevels[settings.edutainmentLevel][2].GetComponent<Quest>().OnQuestComplete -= GameProgress_OnQuestComplete;
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
            dialogScript.ShowDialog(6);
        }
    }
}
