using UnityEngine;
using TMPro;
using System.Collections;

public class NPCDialog : MonoBehaviour
{
    public GameObject npcUI;
    [TextArea][SerializeField]
    private string InitialDialog;
    [TextArea][SerializeField]
    private string VillageQuestCompleted;
    [TextArea][SerializeField]
    private string MazeQuestCompleted;
    [TextArea][SerializeField]
    private string AnimalProblem;
    [TextArea][SerializeField]
    private string AnimalQuestCompleted;
    [TextArea][SerializeField]
    private string DefaultText;
    [TextArea][SerializeField]
    private string WinGame;

    private TextMeshProUGUI dialogText;
    private Animator anim;
    private bool isActive = false;
    private bool uiCloseDelay = false;
    private WaitForSeconds delay;

    private void Start()
    {
        dialogText = npcUI.GetComponentInChildren<TextMeshProUGUI>();
        anim = npcUI.GetComponentInChildren<Animator>();
        delay = new WaitForSeconds(2f);
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
