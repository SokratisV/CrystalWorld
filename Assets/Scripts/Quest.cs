using System;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    public event EventHandler OnQuestComplete;
    public string questName;
    public GameObject gameManager;
    public AudioClip questCompletedSound;
    public PlayerSettings settings;

    protected void QuestCompleted()
    {
        print("quest complete, level " + settings.edutainmentLevel);
        OnQuestComplete?.Invoke(this, EventArgs.Empty);
        if (questCompletedSound != null)
        {
            gameManager.GetComponents<AudioSource>()[1].clip = questCompletedSound;
            gameManager.GetComponents<AudioSource>()[1].Play();
        }
        if (settings.edutainmentLevel == 1)
        {
            //gameManager.GetComponent<GameManagement>().ToggleMiniGames();
        }
        if (settings.edutainmentLevel == 2)
        {
            gameManager.GetComponent<GameManagement>().ToggleQuestions();
        }
    }

    abstract public void QuestProgress(GameObject crystal);
}
