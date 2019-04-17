using UnityEngine;

public class MazeCrystalQuest : Quest
{
    public int piecesCollected = 0;

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
            if (piecesCollected >= 7)
            {
                gameManager.GetComponent<PlayMiniGame>().OnQuestionAnswer += MazeCrystalQuest_OnQuestionAnswer;
                gameManager.GetComponent<GameManagement>().ToggleQuestions();
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
