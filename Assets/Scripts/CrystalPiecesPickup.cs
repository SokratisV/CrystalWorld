using UnityEngine;

public class CrystalPiecesPickup : MonoBehaviour
{
    public void QuestProgress()
    {
        if (gameObject.name.Contains("Piece"))
        {
            transform.parent.GetComponent<Quest>().QuestProgress();
        }
        else
        {
            GetComponent<Quest>().QuestProgress();
        }
        gameObject.SetActive(false);
    }    
}
