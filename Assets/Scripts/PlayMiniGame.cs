using System;
using UnityEngine;

public class PlayMiniGame : MonoBehaviour
{
    public event EventHandler OnMiniGameWin;
    public event EventHandler OnQuestionAnswer;

    public void WonGame()
    {
        OnMiniGameWin?.Invoke(this, EventArgs.Empty);
    }
    public void LostGame()
    {

    }
    public void CorrectQuestion()
    {
        OnQuestionAnswer?.Invoke(this, EventArgs.Empty);
    }
    public void IncorrectQuestion()
    {

    }
}
