using UnityEngine;

public class VillageCrystalQuest : Quest
{
    public int piecesCollected = 0;
    public GameObject background;

    private static bool amISubscribed = false;

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
                if (!amISubscribed)
                {
                    background.GetComponent<PlayMiniGame>().OnMiniGameWin += MazeCrystalQuest_OnMiniGameWin;
                    amISubscribed = true;
                }
                gameManager.GetComponent<GameManagement>().ToggleMiniGames();
            }
            crystal.SetActive(false);
        }
        else if (settings.edutainmentLevel == 2)
        {
            if (piecesCollected >= 7)
            {
                if (!amISubscribed)
                {
                    background.GetComponent<PlayMiniGame>().OnQuestionAnswer += VillageCrystalQuest_OnQuestionAnswer;
                    amISubscribed = true;
                    gameManager.GetComponent<GameManagement>().ToggleQuestions();
                }
            }
            else
            {
                //toggle information UI
            }
            crystal.SetActive(false);
        }
    }

    private void VillageCrystalQuest_OnQuestionAnswer(object sender, System.EventArgs e)
    {
        QuestCompleted();
    }

    private void MazeCrystalQuest_OnMiniGameWin(object sender, System.EventArgs e)
    {
        QuestCompleted();
    }
}
