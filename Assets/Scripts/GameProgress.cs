using UnityEngine;

public class GameProgress : MonoBehaviour
{
    private bool villageCrystalCollected;
    private bool mazeCrystalCollected;
    private bool animalCrystalCollected;
    private NPCDialog dialogScript;

    public GameObject villageCrystal;
    public GameObject mazeCrystal;
    public GameObject animalCrystal;
    public PlayerSettings settings;

    private void Start()
    {
        villageCrystalCollected = false;
        mazeCrystalCollected = false;
        animalCrystalCollected = false;

        villageCrystal.GetComponent<Quest>().OnQuestComplete += GameProgress_OnQuestComplete;
        mazeCrystal.GetComponent<Quest>().OnQuestComplete += GameProgress_OnQuestComplete;
        animalCrystal.GetComponent<Quest>().OnQuestComplete += GameProgress_OnQuestComplete;

        dialogScript = GetComponent<NPCDialog>();
    }

    private void GameProgress_OnQuestComplete(object sender, System.EventArgs e)
    {
        switch (((Quest)sender).questName)
        {
            case "village":
                villageCrystalCollected = true;
                villageCrystal.GetComponent<Quest>().OnQuestComplete -= GameProgress_OnQuestComplete;
                dialogScript.ShowDialog(1);
                break;
            case "maze":
                mazeCrystalCollected = true;
                mazeCrystal.GetComponent<Quest>().OnQuestComplete -= GameProgress_OnQuestComplete;
                dialogScript.ShowDialog(2);
                break;
            case "animal":
                animalCrystalCollected = true;
                animalCrystal.GetComponent<Quest>().OnQuestComplete -= GameProgress_OnQuestComplete;
                dialogScript.ShowDialog(4);
                break;
            default:
                print("Unknown quest");
                break;
        }
        if (villageCrystalCollected && mazeCrystalCollected && animalCrystalCollected)
        {
            dialogScript.ShowDialog(5);
        }
    }
}
