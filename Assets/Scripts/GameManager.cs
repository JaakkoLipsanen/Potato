using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool CanPlayerMove { get { return !IsDialogActive; } }
    public bool IsDialogActive
    {
        get
        {
            return GameObject.Find("Dialog UI").GetComponent<DialogManager>().ActiveDialog != null;
        }
    }

    public GameManager()
    {
        Instance = this;
    }
}
