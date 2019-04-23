using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RememberSquares : MonoBehaviour {

    public GameObject prefab;
    public Sprite revealeadCorrectImage;
    public Sprite revealeadIncorrectImage;
    public Sprite hiddenImage;
    public int[] gamePattern; //public to see correct cards in inspector
    private int length;
    public float revealSpeed = 0.5f;
    private float revealedTime = 0.3f;
    private float countDownTimer = 3f;
    public TextMeshProUGUI countDownText;
    private IEnumerator currentCoroutine;
    private WaitForSecondsRealtime delay;

    void Start () {
        MemoryClass.revealedCorrectSprite = revealeadCorrectImage;
        MemoryClass.revealedIncorrectSprite = revealeadIncorrectImage;
        MemoryClass.hiddenSprite = hiddenImage;
        length = GetComponent<GridLayoutGroup>().constraintCount;
        length *= length;
        gamePattern = new int[length];
        RandomizeArray();
        Populate();
        if (countDownText == null)
        {
            countDownText = GameObject.FindWithTag("CountDown").GetComponent<TextMeshProUGUI>();
        }
        //GetComponentInChildren<MemoryClass>().ResetScoreAndAttempts();
        delay = new WaitForSecondsRealtime(1f);
        CalculatePanelSize();
    }
    private void Populate()
    {
        GameObject temp;

        for (int i = 0; i < length; i++)
        {
            temp = Instantiate(prefab, transform);
            temp.name = "Number" + i;
            temp.transform.GetChild(0).GetComponent<Image>().sprite = hiddenImage;
            temp.GetComponentInChildren<Button>().interactable = false;
            if (gamePattern[i] < MemoryClass.howManyCorrectCards)
            {
                temp.GetComponentInChildren<MemoryClass>().amIActive = true;
            }
        }
        currentCoroutine = ShowCorrect();
        StartCoroutine(currentCoroutine);
    }
    private void RandomizeArray()
    {
        int temp;
        for (int i = 0; i < length; i++)
        {
            gamePattern[i] = i;
        }
        for (int i = 0; i < length; i++)
        {
            int rnd = UnityEngine.Random.Range(0, length);
            temp = gamePattern[rnd];
            gamePattern[rnd] = gamePattern[i];
            gamePattern[i] = temp;
        }
    }
    private IEnumerator ShowCorrect()
    {
        Transform temp;
        if (countDownText == null)
        {
            yield return new WaitForEndOfFrame();
        }

        countDownText.text = "" + countDownTimer--;
        yield return delay;
        countDownText.text = "" + countDownTimer--;
        yield return delay;
        countDownText.text = "" + countDownTimer--;
        yield return delay;
        countDownText.text = "" + countDownTimer;
        
        for (int i = 0; i < length; i++)
        {
            if (gamePattern[i] < MemoryClass.howManyCorrectCards)
            {
                transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = revealeadCorrectImage;
                yield return new WaitForSecondsRealtime(revealSpeed);
            }
        }
        yield return new WaitForSecondsRealtime(revealedTime);
        countDownText.text = "Go!";

        for (int i = 0; i < length; i++)
        {
            temp = transform.GetChild(i);
            if (gamePattern[i] < MemoryClass.howManyCorrectCards)
            {
                temp.GetChild(0).GetComponent<Image>().sprite = hiddenImage;
            }
            temp.GetComponentInChildren<Button>().interactable = true;
        }
        yield return new WaitForSecondsRealtime(.5f);
        countDownText.text = "";
    }
    public void RestartGame()
    {
        StopTheCoroutine();
        RandomizeArray();
        Transform temp;

        for (int i = 0; i < length; i++)
        {
            temp = transform.GetChild(i);
            temp.GetChild(0).GetComponent<Image>().sprite = hiddenImage;
            if (gamePattern[i] < MemoryClass.howManyCorrectCards)
            {
                temp.GetComponentInChildren<MemoryClass>().amIActive = true;
            }
            else
            {
                temp.GetComponentInChildren<MemoryClass>().amIActive = false;
            }
            temp.GetComponentInChildren<Button>().interactable = false;
        }
        currentCoroutine = ShowCorrect();
        StartCoroutine(currentCoroutine);
        GetComponentInParent<PlayMiniGame>().LostGame();
    }
    private void StopTheCoroutine()
    {
        StopCoroutine(currentCoroutine);
        countDownText.text = "";
        countDownTimer = 3;
    }
    private void CalculatePanelSize()
    {
        GridLayoutGroup gridScript = GetComponent<GridLayoutGroup>();
        float middlePanelHeight = gridScript.cellSize.y * gridScript.constraintCount + gridScript.spacing.y * gridScript.constraintCount;
        float middlePanelWidth = gridScript.cellSize.x * gridScript.constraintCount + gridScript.spacing.x * gridScript.constraintCount;
        float upperPanelHeight = middlePanelHeight / 4;
        float lowerPanelHeight = upperPanelHeight;
        float tempHeight = middlePanelHeight + upperPanelHeight + lowerPanelHeight;
        GetComponent<SizeAdjuster>().Height = tempHeight;
        GetComponent<SizeAdjuster>().Width = middlePanelWidth;
    }
    public void WonGame()
    {
        GetComponentInParent<PlayMiniGame>().WonGame();
    }
}
