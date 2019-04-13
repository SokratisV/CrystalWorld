using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System;

public class GenerateEquations : MonoBehaviour {

    public TextMeshProUGUI[] buttons;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public TextMeshProUGUI equationText;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI attemptsText;
    private int score;
    private int attempts;
    private AudioSource audioSource;
    public string[] expressions;
    public int[] answers;
    private int equationIndex;
    private int correctButtonIndex;
    private WaitForSecondsRealtime delay;

	private void Start () {
        audioSource = GetComponent<AudioSource>();
        GetRandomEquationIndex();
        SetEquationText();
        SetButtonAnswers();
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
        attemptsText = GameObject.FindGameObjectWithTag("AttemptsText").GetComponent<TextMeshProUGUI>();
        delay = new WaitForSecondsRealtime(2f);
        CalculatePanelSize();
    }
    public void CheckAnswer(int buttonNumber)
    {
        IncreaseAttempts();
        if (buttonNumber == correctButtonIndex)
        {
            audioSource.clip = correctSound;
            IncreaseScore();
            GetComponentInParent<PlayMiniGame>().WonGame();
        }
        else
        {
            audioSource.clip = incorrectSound;
            GetComponentInParent<PlayMiniGame>().LostGame();
        }
        audioSource.Play();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == correctButtonIndex)
            {
                buttons[i].GetComponentInParent<Image>().color = Color.green;
            }
            else
            {
                buttons[i].GetComponentInParent<Image>().color = Color.red;
            }
            buttons[i].GetComponentInParent<Button>().interactable = false;
        }
        //StartCoroutine(GetNewEquation());
    }
    private IEnumerator GetNewEquation()
    {
        yield return delay;
        ResetButtons();
        GetRandomEquationIndex();
        SetButtonAnswers();
        SetEquationText();
    }
    private void IncreaseAttempts()
    {
        attempts++;
        attemptsText.text = "" + attempts;
    }
    private void IncreaseScore()
    {
        score++;
        scoreText.text = "" + score;
    }
    private void ResetScore()
    {
        score = 0;
        scoreText.text = "" + score;
    }
    private void ResetAttempts()
    {
        attempts = 0;
        attemptsText.text = "" + attempts;
    }
    public void ResetScoreAndAttempts()
    {
        ResetScore();
        ResetAttempts();
    }
    private void ResetButtons()
    {
        foreach (TextMeshProUGUI item in buttons)
        {
            item.GetComponentInParent<Button>().interactable = true;
            item.GetComponentInParent<Image>().color = ColorPalette.GetAccent();
        }
    }
    private void SetButtonAnswers()
    {
        int answer = answers[equationIndex]; //the answer to the equation
        correctButtonIndex = UnityEngine.Random.Range(0, 3); //choose random button to assign correct answer
        int[] answerDeviations = GetDeviations();
        int deviationCounter = 0;
        answerDeviations[0] += answer;
        answerDeviations[1] += answer;
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == correctButtonIndex)
            {
                buttons[i].text = "" + answer;
            }
            else
            {
                buttons[i].text = "" + answerDeviations[deviationCounter++];
            }
        }
    }
    private int[] GetDeviations()
    {
        int[] deviations = new int[2];
        int[] numbersToChooseFrom = { -3, -2, -1, 1, 2, 3 };
        deviations[0] = numbersToChooseFrom[UnityEngine.Random.Range(0, numbersToChooseFrom.Length)];
        while (true)
        {
            deviations[1] = numbersToChooseFrom[UnityEngine.Random.Range(0, numbersToChooseFrom.Length)];
            if (deviations[1] != deviations[0])
            {
                break;
            }
        }
        return deviations;
    }
    private void GetRandomEquationIndex()
    {
        equationIndex = UnityEngine.Random.Range(0, expressions.Length);
    }
    private void SetEquationText()
    {
        equationText.text = expressions[equationIndex] + "=?";
    }
    private void CalculatePanelSize()
    {
        GetComponent<SizeAdjuster>().Width = 550;
        GetComponent<SizeAdjuster>().Height = 500;
    }
}
