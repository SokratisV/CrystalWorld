public class VillageCrystalQuest : Quest
{
    public int piecesCollected = 0;

    public override void QuestProgress()
    {
        piecesCollected += 1;
        if (piecesCollected >= 2)
        {
            QuestCompleted();
        }
    }
}
