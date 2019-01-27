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
                new DialogPiece { Person = "Antti", Text = "Plaa plaa plaa" }

            },
            OnDone = () =>
            {
                GameManager.Instance.StartActualGame();
            }
        };
    }
}
