using UnityEngine;

public class GameProgress : MonoBehaviour
{
    private bool villageCrystalCollected;
    private bool mazeCrystalCollected;
    private bool animalCrystalCollected;

    public GameObject villageCrystal;
    public GameObject mazeCrystal;
    public GameObject animalCrystal;

    private void Start()
    {
        villageCrystalCollected = false;
        mazeCrystalCollected = false;
        animalCrystalCollected = false;

        villageCrystal.GetComponent<Quest>().OnQuestComplete += GameProgress_OnQuestComplete;
        mazeCrystal.GetComponent<Quest>().OnQuestComplete += GameProgress_OnQuestComplete;
        animalCrystal.GetComponent<Quest>().OnQuestComplete += GameProgress_OnQuestComplete;
    }

    private void GameProgress_OnQuestComplete(object sender, System.EventArgs e)
    {
        switch (((Quest)sender).questName)
        {
            case "village":
                villageCrystalCollected = true;
                break;
            case "maze":
                mazeCrystalCollected = true;
                break;
            case "animal":
                animalCrystalCollected = true;
                break;
            default:
                print("Unknown quest");
                break;
        }
        if (villageCrystalCollected && mazeCrystalCollected && animalCrystalCollected)
        {
            print("Grats you won!");
        }
    }
}
