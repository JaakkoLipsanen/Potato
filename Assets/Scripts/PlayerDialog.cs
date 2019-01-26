using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialog : MonoBehaviour
{
    public GameManager gameManager;
    public DialogStarter startableDialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameManager.IsDialogActive)
        {
            return;
        }

        var dialogStarter = collision.GetComponent<DialogStarter>();
        if (dialogStarter != null)
        {
            this.startableDialog = dialogStarter;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameManager.IsDialogActive)
        {
            return;
        }

        var dialogStarter = collision.GetComponent<DialogStarter>();
        if (dialogStarter == startableDialog)
        {
            this.startableDialog = null;
        }
    }
}
