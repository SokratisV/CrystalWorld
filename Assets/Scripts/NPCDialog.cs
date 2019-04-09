using UnityEngine;
using TMPro;
using System.Collections;

public class NPCDialog : MonoBehaviour
{
    public GameObject npcUI;
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

    private TextMeshProUGUI dialogText;
    private Animator anim;
    private bool isActive = false;
    private bool uiCloseDelay = false;
    private WaitForSeconds delay;
    private int currentDialog = 0;

    private void Start()
    {
        dialogText = npcUI.GetComponentInChildren<TextMeshProUGUI>();
        anim = npcUI.GetComponentInChildren<Animator>();
        delay = new WaitForSeconds(4f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleUI();
        }
        if (isActive && uiCloseDelay)
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
                dialogText.text = WinGame;
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
    private IEnumerator UiCloseDelay()
    {
        uiCloseDelay = false;
        yield return delay;
        uiCloseDelay = true;
    }

}
