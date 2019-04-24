using UnityEngine;
using TMPro;
using System.Collections;

public class NPCDialog : MonoBehaviour
{
    public GameObject npcUI;
    public AudioClip[] clips;
    public GameObject godraysCrystals;

    [TextArea][SerializeField] //0
    private string InitialDialog;
    [TextArea][SerializeField] //1
    private string VillageQuestCompleted;
    [TextArea][SerializeField] //2 
    private string MazeQuestCompleted;
    [TextArea][SerializeField] //3
    private string AnimalProblem;
    [TextArea][SerializeField] //4
    private string AnimalQuestCompleted;
    [TextArea][SerializeField] //5
    private string DefaultText;
    [TextArea][SerializeField] //6
    private string WinGame;
    [TextArea][SerializeField] //7
    private string GuideDialog1;
    [TextArea][SerializeField] //8
    private string GuideDialog2;
    [TextArea][SerializeField] //9
    private string GuideDialog3;
    [TextArea][SerializeField] //10
    private string GuideDialog4;


    private TextMeshProUGUI dialogText;
    private Animator anim;
    private bool isActive = false;
    private bool uiCloseDelay = false;
    private WaitForSeconds delay;
    private int currentDialog = 0;
    private bool guiding = false;
    private AudioSource audio;

    private void Start()
    {
        dialogText = npcUI.GetComponentInChildren<TextMeshProUGUI>();
        anim = npcUI.GetComponentInChildren<Animator>();
        delay = new WaitForSeconds(5f);
        audio = GetComponents<AudioSource>()[2];
    }
    private void Update()
    {
        if (isActive && uiCloseDelay && !guiding)
        {
            if (Input.anyKey)
            {
                ToggleUI();
            }
        }
    }
    public void ShowCurrentDialog()
    {
        ShowDialog(currentDialog);
    }
    public void ShowDefaultDialog()
    {
        if (currentDialog == 0)
        {
            ShowDialog(0);
        }
        else
        {
            ShowDialog(5);
        }
    }
    public void ToggleUI()
    {
        isActive = !isActive;
        anim.SetBool("Active", isActive);
        StartCoroutine(UiCloseDelay());
    }
    private void UseCorrectText(int number)
    {
        audio.clip = clips[number];
        audio.Play();
        switch (number)
        {
            case 0:
                dialogText.text = InitialDialog;
                break;
            case 1:
                dialogText.text = VillageQuestCompleted;
                break;
            case 2:
                dialogText.text = MazeQuestCompleted;
                break;
            case 3:
                dialogText.text = AnimalProblem;
                break;
            case 4:
                dialogText.text = AnimalQuestCompleted;
                break;
            case 5:
                dialogText.text = DefaultText;
                break;
            case 6:
                dialogText.text = WinGame;
                break;
            case 7:
                dialogText.text = GuideDialog1;
                break;
            case 8:
                dialogText.text = GuideDialog2;
                break;
            case 9:
                dialogText.text = GuideDialog3;
                break;
            case 10:
                dialogText.text = GuideDialog4;
                break;
            default:
                dialogText.text = DefaultText;
                break;
        }
    }
    public void ShowDialog(int number)
    {
        currentDialog = number;
        UseCorrectText(number);
        ToggleUI();
    }
    public void ShowGuideDialog()
    {
        StartCoroutine(StartGuideDialog());
    }
    private IEnumerator UiCloseDelay()
    {
        uiCloseDelay = false;
        yield return delay;
        uiCloseDelay = true;
    }

    private IEnumerator StartGuideDialog()
    {
        ToggleUI();
        godraysCrystals.SetActive(true);
        guiding = true;
        UseCorrectText(0);
        yield return new WaitForSeconds(5.3f);
        UseCorrectText(7);
        yield return new WaitForSeconds(5.1f);
        UseCorrectText(8);
        yield return new WaitForSeconds(5.4f);
        UseCorrectText(9);
        yield return new WaitForSeconds(6.1f);
        UseCorrectText(10);
        yield return new WaitForSeconds(5.3f);
        guiding = false;
        GameObject.FindWithTag("Player").GetComponent<Moving>().allowMovement = true;
        godraysCrystals.SetActive(false);
    }
}
