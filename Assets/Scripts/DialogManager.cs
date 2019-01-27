using System;
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

    public void Reset()
    {
        index = 0;
    }

    public Action OnDone;
}

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

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

    private bool _dirty = false;
    public float DialogProgress = 0;

    public DialogManager()
    {
        Instance = this;
    }

    public void StartDialog(Dialog dialog)
    {
        this.ActiveDialog = dialog;
        this.DialogProgress = 0;
        this.ActiveDialog.Reset();

        _dirty = true;
    }

    void LateUpdate()
    {
        this.Canvas.enabled = true;
        this.DialogText.text = "";
        this.SpeakerNameText.text = "";
        if (!GameManager.Instance.CanPlayerConversate)
        {
            this.Canvas.enabled = false;
            return;
        }
        if (this.ActiveDialog != null)
        {
            this.SpeakerNameText.text = this.ActiveDialog.CurrentDialog.Person;
            this.DialogText.text = this.ActiveDialog.CurrentDialog.Text.Substring(0, Mathf.Max(1, Mathf.RoundToInt(this.ActiveDialog.CurrentDialog.Text.Length * this.DialogProgress)));
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
                        _dirty = false;
                        var oldDialog = this.ActiveDialog;
                        this.ActiveDialog.OnDone?.Invoke();
                        if (!_dirty)
                        {
                            this.ActiveDialog = null;
                        }
                    }
                }
            } else if (Input.GetKeyDown(KeyCode.Space))
            {
                this.DialogProgress = 1;
            }


            if (this.ActiveDialog != null)
            {
                var deltaMultiplier = 25 / (float)this.ActiveDialog.CurrentDialog.Text.Length;
                this.DialogProgress = Mathf.Min(1, this.DialogProgress + Time.deltaTime * deltaMultiplier);
            }
        }
        else if(this.playerDialog.startableDialog != null && GameManager.Instance.CanPlayerMove)
        {
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
