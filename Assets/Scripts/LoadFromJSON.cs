using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class LoadFromJSON : MonoBehaviour
{
    public TextMeshProUGUI question;
    public Button[] answers;
    //public TextMeshProUGUI points;
    public GameObject questionsUICanvas;
    public AudioClip correctSound;
    public AudioClip incorrectSound;
    //public TextMeshProUGUI score;
    public TextMeshProUGUI source;
    //public Button skipQuestionButton;
    public static bool isQuestionsUIActive = false;

    private AudioSource audioSource;
    private string path;
    private string jsonString;
    private Questions[] QuestionsFromJson;
    private int index = 0;
    private int[] answeredQuestions;
    private ColorBlock cb;
    private ColorBlock defaultButtonColors;

    private void Start()
    {
        audioSource = GetComponents<AudioSource>()[1];
        defaultButtonColors = new ColorBlock();
        cb = new ColorBlock();
        defaultButtonColors = answers[0].colors;
        cb = defaultButtonColors;
        if (Application.isEditor)
        {
            path = Application.streamingAssetsPath + "/questions.json";
            //path = Application.dataPath + "/questions.json"; //path of the json file to read
        }
        else
        {
            path = Application.streamingAssetsPath + "/questions.json";
        }

        jsonString = File.ReadAllText(path);
        QuestionsFromJson = JsonHelper.FromJson<Questions>(jsonString); //helper JSON class, not in libraries

        //-1 is unanswered, 0 is answer falsly, 1 is answered correctly, 2 skipped by player
        answeredQuestions = new int[QuestionsFromJson.Length];
        for (int i = 0; i < answeredQuestions.Length; i++)
        {
            answeredQuestions[i] = -1;
        }

        /*Debug.Log(QuestionsFromJson[0].question);
        Debug.Log(QuestionsFromJson[0].answers[0]);
        Debug.Log(QuestionsFromJson[1].question + QuestionsFromJson[1].points);
        foreach (string str in QuestionsFromJson[1].answers)
        {
            Debug.Log(str);
        }*/
    }
    private void Update()
    {
        if (questionsUICanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F3))
            {
                GetNextQuestion();
            }
            if (Input.GetKeyDown(KeyCode.F4)) //highlight the correct answer
            {
                HighlightCorrectAnswer();
            }
            //if (Input.GetKeyDown(KeyCode.F5))
            //{
            //    ShowQuestionStatus();
            //}
        }
        if (isQuestionsUIActive)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                answers[0].onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                answers[1].onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                answers[2].onClick.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                answers[3].onClick.Invoke();
            }
        }

    }
    public void HighlightCorrectAnswer()
    {
        if (index != 0)
        {
            answers[int.Parse(QuestionsFromJson[index - 1].correctAnswer) - 1].Select();
        }
        else
        {
            answers[int.Parse(QuestionsFromJson[QuestionsFromJson.Length - 1].correctAnswer) - 1].Select();
        }
    }
    public void ToggleQuestionMenu()
    {
        if (questionsUICanvas.activeSelf)
        {
            isQuestionsUIActive = false;
        }
        else
        {
            GetNextQuestion();
            isQuestionsUIActive = true;
        }
        questionsUICanvas.SetActive(!questionsUICanvas.activeSelf);
        //CheckForQuestionSkip();
        GetComponent<GameManagement>().Pause();
    }
    public void GetNextQuestion()
    {
        question.text = QuestionsFromJson[index].question; //update question text
        //points.text = QuestionsFromJson[index].points; //update points for each question
        source.text = QuestionsFromJson[index].source; //add the source of the question

        foreach (Button btn in answers) //TODO-Only enable as many buttons as answers
        {
            btn.GetComponentInChildren<TextMeshProUGUI>().text = "";
            btn.interactable = false;
        }//remove text from previous answers
        for (int i = 0; i < QuestionsFromJson[index].answers.Length; i++)
        {
            answers[i].GetComponentInChildren<TextMeshProUGUI>().text = QuestionsFromJson[index].answers[i];
            answers[i].interactable = true;
        }//add text of new answers
        GoToNextIndex();
    }
    //public void SkipTheQuestion()
    //{
    //    if (CanQuestionBeSkipped())
    //    {
    //        //remove the points from score
    //        //Gameplay.SubtractFromScore(int.Parse(QuestionsFromJson[GetCurrentAnswerIndex()].points));
    //        //score.text = "" + Gameplay.GetScore();
    //        //mark the question done and skip
    //        answeredQuestions[index - 1] = 2;
    //        StartCoroutine(VisualFeedBackBeforeClosing(int.Parse(QuestionsFromJson[GetCurrentAnswerIndex()].correctAnswer), true));
    //        if (audioSource != null)
    //        {
    //            audioSource.clip = correctSound;
    //            audioSource.Play();
    //        }
    //    }
    //}
    //private bool CanQuestionBeSkipped()
    //{
    //    if (int.Parse(QuestionsFromJson[GetCurrentAnswerIndex()].points) <= Gameplay.GetScore()) return true; else return false;
    //}
    public void CorrectAnswer(int buttonNumber)
    {
        int temp = GetCurrentAnswerIndex();
        //if the question is not the first one
        //get the previous question since it always does index++ after getting a question
        if (buttonNumber == int.Parse(QuestionsFromJson[GetCurrentAnswerIndex()].correctAnswer))
        {
            if (audioSource != null)
            {
                audioSource.clip = correctSound;
                audioSource.Play();
            }
            //Gameplay.AddToScore(int.Parse(QuestionsFromJson[temp].points));
            //score.text = "" + Gameplay.GetScore();
            answeredQuestions[temp] = 1;
            //if (lastQuestionAreaTrigger != null)
            //{
            //    lastQuestionAreaTrigger.SetActive(false);
            //}
            StartCoroutine(VisualFeedBackBeforeClosing(buttonNumber, true));
        }
        else
        {
            if (audioSource != null)
            {
                audioSource.clip = incorrectSound;
                audioSource.Play();
            }
            answeredQuestions[temp] = 0;
            StartCoroutine(VisualFeedBackBeforeClosing(buttonNumber, false));
        }

    }
    private void GoToNextIndex()
    {
        index = (index + 1 >= QuestionsFromJson.Length) ? 0 : index + 1; //check if index goes above json file object length
    }
    private int SetRandomIndex()
    {
        //TODO-only get numbers from questions marked as not answered
        return Random.Range(0,QuestionsFromJson.Length);
    } //--NOT YET CORRECT--
    //private void CheckForQuestionSkip()
    //{
    //    if (CanQuestionBeSkipped())
    //    {
    //        skipQuestionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Press F1 to skip the question";
    //        skipQuestionButton.interactable = true;
    //    }
    //    else
    //    {
    //        skipQuestionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Insufficient score to skip question";
    //        skipQuestionButton.interactable = false;
    //    }
    //} //Changes button appearance based on the ability to skip questions.
    public void OpenSiteURL()
    {
        if (index != 0)
        {
            Application.OpenURL(QuestionsFromJson[index - 1].source);
        }
        else
        {
            Application.OpenURL(QuestionsFromJson[QuestionsFromJson.Length - 1].source);
        }
    }
    private void ShowQuestionStatus()
    {
        question.text = "[";
        foreach (int i in answeredQuestions)
        {
            question.text += i + "],["; 
        }
        question.text += "done]";
        source.text = "Number of questions: " + answeredQuestions.Length;
    }
    private IEnumerator VisualFeedBackBeforeClosing(int buttonNumber, bool isItCorrect)
    {
        if (isItCorrect)
        {
            cb.disabledColor = Color.green;
            answers[buttonNumber - 1].colors = cb;
        }
        else
        {
            cb.disabledColor = Color.red;
            answers[buttonNumber - 1].colors = cb;
        }
        foreach (Button b in answers)
        {
            b.interactable = false;
        }
        yield return new WaitForSecondsRealtime(1.5f);
        ToggleQuestionMenu();
        foreach (Button b in answers)
        {
            b.interactable = true;
        }
        answers[buttonNumber - 1].colors = defaultButtonColors;
    }
    //Creating a JSON file by hand adds a lot of spaces/newlines and makes it unusable with ReadAllText
    //Alternatively use browserling.com/tools/remove-all-whitespace and jsonlint to correct it
    public void CreateProperJsonFile()
    {
        string jsonString = "{\r\n    \"Items\": [\r\n        {\r\n            \"playerId\": \"8484239823\",\r\n            \"playerLoc\": \"Powai\",\r\n            \"playerNick\": \"Random Nick\"\r\n        },\r\n        {\r\n            \"playerId\": \"512343283\",\r\n            \"playerLoc\": \"User2\",\r\n            \"playerNick\": \"Rand Nick 2\"\r\n        }\r\n    ]\r\n}";
        QuestionsFromJson = JsonHelper.FromJson<Questions>(jsonString);
        File.WriteAllText(Application.dataPath + "/test.json", JsonHelper.ToJson<Questions>(QuestionsFromJson, true));
        //Alternatively use browserling.com/tools/remove-all-whitespace and jsonlint to correct it
    }
    private int GetCurrentAnswerIndex()
    {
        if (index != 0)
        {
            return index - 1;
        }
        else
        {
            return QuestionsFromJson.Length - 1;
        }
    }
}
