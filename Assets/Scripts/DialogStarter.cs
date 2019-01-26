using UnityEngine;

public class DialogStarter : MonoBehaviour
{
    public Dialog dialog = new Dialog 
    { 
        DialogPieces = new DialogPiece[] { 
            new DialogPiece { Person = "Sarah", Text = "Oh Jaakko you're so brave!" }, 
            new DialogPiece { Person = "Jaakko", Text = "Aww thank you Sarah!" },
            new DialogPiece { Person = "Sarah", Text = "Could you be my knight in a shining armor and go fetch some stuff for me from the kitchen?" },
            new DialogPiece { Person = "Jaakko", Text = "Of course! I will be back in 20 seconds" },
        }
    };
}
