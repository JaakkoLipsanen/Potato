using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhilipDialog : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<DialogStarter>().dialog = new Dialog
        {
            DialogPieces = new DialogPiece[]
            {
                new DialogPiece { Person = "Philip", Text = "Hey, have you seen Wendy today?" },
                new DialogPiece { Person = "Philip", Text = "She is looking fine... What I wouldn't give for a bit of that booty action" }
            }
        };
    }
}
