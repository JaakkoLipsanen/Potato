using UnityEngine;

public class DialogStarter : MonoBehaviour
{
    public Dialog dialog = new Dialog 
    { 
        DialogPieces = new DialogPiece[] {
            new DialogPiece { Person = "Wendy", Text = "I am tired of Phillip hitting on me... That old man" }
        }
    };
}
