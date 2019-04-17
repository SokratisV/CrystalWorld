using UnityEngine;

public class CrystalPiecesPickup : MonoBehaviour
{
    public void QuestProgress(int level, GameManagement management)
    {
        if (gameObject.name.Contains("Piece"))
        {
            transform.parent.GetComponent<Quest>().QuestProgress(gameObject);
            //switch (level)
            //{
            //    case 0:
            //        break;
            //    case 1:
            //        break;
            //    case 2:
            //        break;
            //    default:
            //        break;
            //}
        }
        else
        {
            GetComponent<Quest>().QuestProgress(gameObject);
            //switch (level)
            //{
            //    case 0:
            //        break;
            //    case 1:
            //        break;
            //    case 2:
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
