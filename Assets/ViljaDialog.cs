using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViljaDialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogStarter>().dialog = new Dialog
        {
            DialogPieces = new DialogPiece[]
            {
                new DialogPiece { Person = "Vilja", Text = "Hello Bob, have you noticed the strange green slime in the living room. " },
                new DialogPiece { Person = "Bob", Text = "Strange slime? Do you think it could be from the aliens? " },
                new DialogPiece { Person = "Vilja", Text = "What aliens? " },
                new DialogPiece { Person = "Bob", Text = "Apparently Antti thinks there are aliens living here " },
                new DialogPiece { Person = "Vilja", Text = "Antti says lots of strange things. " },


            }
        };
    }
}
