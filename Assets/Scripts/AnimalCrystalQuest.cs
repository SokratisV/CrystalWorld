using UnityEngine;

public class AnimalCrystalQuest : Quest
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
            background.GetComponent<PlayMiniGame>().OnMiniGameWin += AnimalCrystalQuest_OnMiniGameWin;
        }
        else if (settings.edutainmentLevel == 2)
        {
            piecesCollected += 1;
            if (piecesCollected >= 7)
            {
                gameManager.GetComponent<PlayMiniGame>().OnQuestionAnswer += AnimalCrystalQuest_OnQuestionAnswer;
                gameManager.GetComponent<GameManagement>().ToggleQuestions();
            }
            else
            {
                //toggle information UI
            }
        }
        crystal.SetActive(false);
    }

    private void AnimalCrystalQuest_OnQuestionAnswer(object sender, System.EventArgs e)
    {
        QuestCompleted();
    }

    private void AnimalCrystalQuest_OnMiniGameWin(object sender, System.EventArgs e)
    {
        QuestCompleted();
    }
}
