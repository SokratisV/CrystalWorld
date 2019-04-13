using System;
using UnityEngine;

public class PlayMiniGame : MonoBehaviour
{
    public event EventHandler OnMiniGameWin;

    public void WonGame()
    {
        OnMiniGameWin?.Invoke(this, EventArgs.Empty);
    }
    public void LostGame()
    {

    }
}
