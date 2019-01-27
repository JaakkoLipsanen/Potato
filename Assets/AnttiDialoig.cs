using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnttiDialoig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogStarter>().dialog = new Dialog
        {
            DialogPieces = new DialogPiece[]
            {
                new DialogPiece { Person = "Antti", Text = "Hello Bob, how are you settling in..." },
                new DialogPiece { Person = "Bob", Text = "*Grunts*" },
                new DialogPiece { Person = "Bob", Text = "I was wondering if you could tell me more about the aliens" },
                new DialogPiece { Person = "Antti", Text = "I don’t know anything about aliens." },
                new DialogPiece { Person = "Bob", Text = "But everyone says you think someone here is disguised as an alien, and that they stole the bingo game" },
                new DialogPiece { Person = "Bob", Text = "What is that green slime on your floor" },
                new DialogPiece { Person = "Antti", Text = "What green slime... No green slime... nothing to see here" },
                new DialogPiece { Person = "Bob", Text = "There is green slime all over your floor" },
                new DialogPiece { Person = "Antti", Text = "I think you should leave now" },
                new DialogPiece { Person = "Bob", Text = "Not until you tell me about the slime!" },

            },
            OnDone = () =>
            {
                GameManager.Instance.StartActualGame();
            }
        };
    }
}
