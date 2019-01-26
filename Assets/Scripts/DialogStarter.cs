using UnityEngine;

public class DialogStarter : MonoBehaviour
{
    public Dialog dialog = new Dialog 
    { 
        DialogPieces = new DialogPiece[] { new DialogPiece { Person = "Sarah", Text = "Oh Jaakko you're so brave!" } }
    };
}
