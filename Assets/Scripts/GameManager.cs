using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool CanPlayerMove { get { return !IsDialogActive && !IsStartupPhaseActive; } }
    public bool CanPlayerConversate {  get { return !this.IsActualGameStarted; } }

    public bool IsStartupPhaseActive { get; set; }
    public bool IsDialogActive
    {
        get
        {
            return GameObject.Find("Dialog UI").GetComponent<DialogManager>().ActiveDialog != null;
        }
    }

    public bool IsActualGameStarted = false;

    public GameManager()
    {
        Instance = this;
    }

    public void StartActualGame()
    {
        this.IsActualGameStarted = true;
    }
}
