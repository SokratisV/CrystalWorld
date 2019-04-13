using UnityEngine;

public class VillageCrystalQuest : Quest
{
    public int piecesCollected = 0;
    public PlayerSettings settings;
    public GameObject background;

    public override void QuestProgress()
    {
        if (settings.edutainmentLevel == 0)
        {
            piecesCollected += 1;
            if (piecesCollected >= 7)
            {
                if (settings.edutainmentLevel == 0)
                {
                    QuestCompleted();
                }
            }
            else
            {
                background.GetComponent<PlayMiniGame>().OnMiniGameWin += MazeCrystalQuest_OnMiniGameWin;
            }
        }
    }

    private void MazeCrystalQuest_OnMiniGameWin(object sender, System.EventArgs e)
    {
        QuestCompleted();
    }

        //public override void QuestProgress()
        //{
        //    piecesCollected += 1;
        //    if (piecesCollected >= 7)
        //    {
        //        if (settings.edutainmentLevel == 0)
        //        {
        //            QuestCompleted();
        //        }
        //    }
        //}
}
