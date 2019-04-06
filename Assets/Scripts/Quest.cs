using System;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    public event EventHandler OnQuestComplete;
    public string questName;
    public GameObject gameManager;
    public AudioClip questCompletedSound;

    protected void QuestCompleted()
    {
        OnQuestComplete?.Invoke(this, EventArgs.Empty);
        if (questCompletedSound != null)
        {
            gameManager.GetComponents<AudioSource>()[1].clip = questCompletedSound;
            gameManager.GetComponents<AudioSource>()[1].Play();
        }
    }

    abstract public void QuestProgress();
}
