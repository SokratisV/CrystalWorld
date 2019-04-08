using System.Collections;
using UnityEngine;

public class CrystalPiecesPickup : MonoBehaviour
{
    private GameObject prefab;

    private void Start()
    {
         prefab = Resources.Load<GameObject>("FireFlies");
    }

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
        //GameObject temp = Instantiate(prefab, transform);
        //temp.AddComponent<DeleteAfterDelay>();
        //temp.transform.parent = transform.parent;
        gameObject.SetActive(false);
    }
}
