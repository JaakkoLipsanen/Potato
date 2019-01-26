using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPiece
{
    public string Person;
    public string Text;
}

public class Dialog
{
    private int index = 0;
    public DialogPiece[] DialogPieces;

    public DialogPiece CurrentDialog { get { return DialogPieces[index]; } }
    public bool HasNext {  get { return DialogPieces.Length > index + 1;  } }
    public void MoveToNext()
    {
        if(HasNext)
        {
            index++;
        }
    }
}

public class DialogManager : MonoBehaviour
{
    public PlayerDialog playerDialog;
    public Dialog ActiveDialog;
    public Canvas Canvas
    {
        get { return this.GetComponentInChildren<Canvas>(); }
    }

    public Text DialogText
    {
        get { return GameObject.Find("DialogText").GetComponentInChildren<Text>(); }
    }

    public Text SpeakerNameText
    {
        get { return GameObject.Find("SpeakerName").GetComponentInChildren<Text>(); }
    }

    public float DialogProgress = 0;


    public void StartDialog(Dialog dialog)
    {
        this.ActiveDialog = dialog;
        this.DialogProgress = 0;
    }

    void LateUpdate()
    {
        this.Canvas.enabled = true;
        this.DialogText.text = "";
        this.SpeakerNameText.text = "";
        if (this.ActiveDialog != null)
        {
            Debug.Log("active");
            this.SpeakerNameText.text = this.ActiveDialog.CurrentDialog.Person;
            this.DialogText.text = this.ActiveDialog.CurrentDialog.Text.Substring(0, Mathf.Max(1, Mathf.RoundToInt(this.ActiveDialog.CurrentDialog.Text.Length * this.DialogProgress) - 1));
            if(this.DialogProgress >= 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (this.ActiveDialog.HasNext)
                    {
                        this.ActiveDialog.MoveToNext();
                        this.DialogProgress = 0;
                    }
                    else
                    {
                        this.ActiveDialog = null;
                    }
                }
            }


            if (this.ActiveDialog != null)
            {
                var deltaMultiplier = 25 / (float)this.ActiveDialog.CurrentDialog.Text.Length;
                this.DialogProgress = Mathf.Min(1, this.DialogProgress + Time.deltaTime * deltaMultiplier);
            }
        }
        else if(this.playerDialog.startableDialog != null)
        {
            Debug.Log("player");
            this.DialogText.text = "Press F to start conversation";
            if (Input.GetKeyDown(KeyCode.F))
            {
                this.StartDialog(this.playerDialog.startableDialog.dialog);
            }
        }
        else
        {
            this.Canvas.enabled = false;
        }
    }
}
