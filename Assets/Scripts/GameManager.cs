using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool CanPlayerMove { get { return IsDialogActive; } }
    public bool IsDialogActive = false;
}
