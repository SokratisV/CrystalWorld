using UnityEngine;

public class CrystalPiecesPickup : MonoBehaviour
{
    public void QuestProgress(int level, GameManagement management)
    {
        if (gameObject.name.Contains("Piece"))
        {
            transform.parent.GetComponent<Quest>().QuestProgress(gameObject);
        }
        else
        {
            GetComponent<Quest>().QuestProgress(gameObject);
        }
    }
}
