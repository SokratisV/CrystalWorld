using System.Collections;
using TMPro;
using UnityEngine;

public class SwitchGame : MonoBehaviour {
    public TextMeshProUGUI[] texts;
    public GameObject[] prefabGames;
    private int whichPrefabIsActive = 0;
    private GameObject activeMiddlePanel;
    public TextMeshProUGUI gameNameText;
    public GameObject backgroundOfGames; //previous owner of script, MiniGamesUI--> Background
    public GameObject miniGamesUI;

    private void Awake()
    {
        activeMiddlePanel = Instantiate(prefabGames[whichPrefabIsActive], backgroundOfGames.transform);
        activeMiddlePanel.name = prefabGames[whichPrefabIsActive].name;
        gameNameText.text = "Game: " + activeMiddlePanel.name;
        StartCoroutine(EndOfFrame());
    }
    public void ToggleMiniGames()
    {
        miniGamesUI.SetActive(!miniGamesUI.activeSelf);
    }
    public void ChangeGame()
    {
        Destroy(activeMiddlePanel);
        whichPrefabIsActive++;
        whichPrefabIsActive = whichPrefabIsActive % prefabGames.Length;
        activeMiddlePanel = Instantiate(prefabGames[whichPrefabIsActive], backgroundOfGames.transform);
        activeMiddlePanel.name = prefabGames[whichPrefabIsActive].name;
        ResetUIText();
        gameNameText.text = "Game: " + activeMiddlePanel.name;
        StartCoroutine(EndOfFrame());
    }
    public void RestartCurrent()
    {
        Destroy(activeMiddlePanel);
        activeMiddlePanel = Instantiate(prefabGames[whichPrefabIsActive], backgroundOfGames.transform);
        activeMiddlePanel.name = prefabGames[whichPrefabIsActive].name;
        gameNameText.text = "Game: " + activeMiddlePanel.name;
        StartCoroutine(EndOfFrame());
    }
    private void ResetUIText()
    {
        foreach (TextMeshProUGUI item in texts)
        {
            item.GetComponent<ResetValue>().ResetToDefault();
        }
    }
    private IEnumerator EndOfFrame()
    {
        yield return new WaitForEndOfFrame();
        backgroundOfGames.GetComponent<AdjustSize>().ChangeSize(activeMiddlePanel);
        yield return new WaitForEndOfFrame();
        backgroundOfGames.GetComponent<ColorPalette>().AdjustColors();
    }
}
