using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WendyDialog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<DialogStarter>().dialog = new Dialog
        {
            DialogPieces = new DialogPiece[]
           {
                new DialogPiece { Person = "Lotta", Text = "I miss boggle" },
                new DialogPiece { Person = "Bob", Text = "Maybe I can help you get it back " },
                new DialogPiece { Person = "Lotta", Text = "That would be wonderful. Have you heard Antti thinks it was stolen by aliens. " },
                new DialogPiece { Person = "Bob", Text = "Yes, I should go speak to him about that..." }
           }
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
