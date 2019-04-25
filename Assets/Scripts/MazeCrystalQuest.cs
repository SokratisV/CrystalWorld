using UnityEngine;

public class MazeCrystalQuest : Quest
{
    public int piecesCollected = 0;

    private void Start()
    {
        if (settings.edutainmentLevel == 2)
        {
            crystalPiecesOutOf.text = "/7";
            crystalPiecesScore.text = "0";
        }
        else
        {
            crystalPiecesOutOf.text = "/1";
            crystalPiecesScore.text = "0";
        }
    }

    public override void QuestProgress(GameObject crystal)
    {
        crystalPiecesScore.GetComponentInParent<ProgressFeedback>().GiveFeedback();
        if (settings.edutainmentLevel == 0)
        {
            piecesCollected++;
            QuestCompleted();
        }
        else if (settings.edutainmentLevel == 1)
        {
            piecesCollected++;
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
        crystalPiecesScore.text = piecesCollected.ToString();
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
