using UnityEngine;

public class MazeCrystalQuest : Quest
{
    public int piecesCollected = 0;
    public GameObject background;
    private static bool amISubscribed = false;

    public override void QuestProgress(GameObject crystal)
    {
        if (settings.edutainmentLevel == 0)
        {
            QuestCompleted();
        }
        else if (settings.edutainmentLevel == 1)
        {
            gameManager.GetComponent<GameManagement>().ToggleMiniGames();
            background.GetComponent<PlayMiniGame>().OnMiniGameWin += MazeCrystalQuest_OnMiniGameWin;
        }
        else if (settings.edutainmentLevel == 2)
        {
            piecesCollected += 1;
            crystal.SetActive(false);
            if (piecesCollected >= 7)
            {
                background.GetComponent<PlayMiniGame>().OnQuestionAnswer += MazeCrystalQuest_OnQuestionAnswer;
                amISubscribed = true;
                gameManager.GetComponent<GameManagement>().ToggleMiniGames();
            }
            else
            {
                //toggle information UI
            }
        }
        crystal.SetActive(false);
    }

    private void MazeCrystalQuest_OnQuestionAnswer(object sender, System.EventArgs e)
    {
        QuestCompleted();
    }

    private void MazeCrystalQuest_OnMiniGameWin(object sender, System.EventArgs e)
    {
        QuestCompleted();
    }
}
