using System;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    public event EventHandler OnQuestComplete;
    public string questName;
    public GameObject gameManager;
    public AudioClip questCompletedSound;
    public PlayerSettings settings;
    public GameObject background;

    protected void QuestCompleted()
    {
        OnQuestComplete?.Invoke(this, EventArgs.Empty);
        if (questCompletedSound != null)
        {
            gameManager.GetComponents<AudioSource>()[1].clip = questCompletedSound;
            gameManager.GetComponents<AudioSource>()[1].Play();
        }
        gameObject.SetActive(false);
    }

    abstract public void QuestProgress(GameObject crystal);
}
