using UnityEngine;

public class AnimalCrystalQuest : Quest
{
    public PlayerSettings settings;
    public GameObject background;

    public override void QuestProgress()
    {
        if (settings.edutainmentLevel == 0)
        {
            QuestCompleted();
        }
        else
        {
            background.GetComponent<PlayMiniGame>().OnMiniGameWin += MazeCrystalQuest_OnMiniGameWin;
        }
    }

    private void MazeCrystalQuest_OnMiniGameWin(object sender, System.EventArgs e)
    {
        QuestCompleted();
    }
}
