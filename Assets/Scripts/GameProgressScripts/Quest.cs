using System;
using TMPro;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    public event EventHandler OnQuestComplete;
    public string questName;
    public GameObject gameManager;
    public AudioClip questCompletedSound;
    public MyPlayerSettings settings;
    public GameObject background;
    public TextMeshProUGUI crystalPiecesOutOf;
    public TextMeshProUGUI crystalPiecesScore;
    public GameObject questCompletedImage;

    protected void QuestCompleted()
    {
        OnQuestComplete?.Invoke(this, EventArgs.Empty);
        questCompletedImage.SetActive(true);
        if (questCompletedSound != null)
        {
            gameManager.GetComponents<AudioSource>()[1].clip = questCompletedSound;
            gameManager.GetComponents<AudioSource>()[1].Play();
        }
        gameObject.SetActive(false);
    }

    abstract public void QuestProgress(GameObject crystal);
}
