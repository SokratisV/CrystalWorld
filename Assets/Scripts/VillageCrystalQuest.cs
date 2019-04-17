using UnityEngine;

public class VillageCrystalQuest : Quest
{
    public int piecesCollected = 0;

    public override void QuestProgress(GameObject crystal)
    {
        piecesCollected += 1;
        crystal.SetActive(false);

        if (settings.edutainmentLevel == 0)
        {
            if (piecesCollected >= 7)
            {
                QuestCompleted();
            }
        }
        else if (settings.edutainmentLevel == 1)
        {
            if (piecesCollected >= 7)
            {
                background.GetComponent<PlayMiniGame>().OnMiniGameWin += VillageCrystalQuest_OnMiniGameWin;
                gameManager.GetComponent<GameManagement>().ToggleMiniGames();
            }
        }
        else if (settings.edutainmentLevel == 2)
        {
            if (piecesCollected >= 7)
            {
                gameManager.GetComponent<PlayMiniGame>().OnQuestionAnswer += VillageCrystalQuest_OnQuestionAnswer;
                gameManager.GetComponent<GameManagement>().ToggleQuestions();
            }
            else
            {
                //toggle information UI
            }
        }
    }

    private void VillageCrystalQuest_OnQuestionAnswer(object sender, System.EventArgs e)
    {
        QuestCompleted();
    }

    private void VillageCrystalQuest_OnMiniGameWin(object sender, System.EventArgs e)
    {
        print(sender);
        QuestCompleted();
    }

}
