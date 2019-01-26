using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartPhase
{
    BobMoves,
    StillDialog,
    MovingDialog,
    AtRoomDialog,
    Done
}

public class GameStartManager : MonoBehaviour
{
    public GameObject Bob {  get { return GameObject.Find("Bob"); } }
    public GameObject Wendy { get { return GameObject.Find("Wendy"); } }
    public GameManager GameManager {  get { return GameManager.Instance; } }
    public DialogManager DialogManager { get { return DialogManager.Instance; } }

    public StartPhase Phase = StartPhase.BobMoves;

    public float BobMovesWait = 0;
    public float BobMovesProgress = 0;
    public Vector3 BobMovesStartPosition = new Vector3(0.68f, 7.13f, 0);
    public Vector3 BobMovesEndPosition = new Vector3(0.68f, 2.13f, 0);

    public float MovingBobStartDelay = 0;
    public Vector3[] MovingBobPath;
    public Vector3[] MovingWendyPath;
    public int MovingBobCurrentIndex = 1;
    public int MovingWendyCurrentIndex = 1;

    void Start()
    {
        MovingBobPath = CreatePath(true);
        MovingWendyPath = CreatePath(false);
        GameManager.Instance.IsStartupPhaseActive = true;
    }

    void Update()
    {
        if(Phase == StartPhase.BobMoves)
        {
            if(BobMovesWait < 3)
            {
                BobMovesWait += Time.deltaTime;
                return;
            }

            this.BobMovesProgress = Mathf.Min(1, this.BobMovesProgress + Time.deltaTime * 0.2f);
            this.Bob.transform.position = Vector3.Lerp(BobMovesStartPosition, BobMovesEndPosition, this.BobMovesProgress);
            if (this.BobMovesProgress == 1)
            {
                this.StartStillDialog();
            }
        }
        else if(Phase == StartPhase.MovingDialog)
        {
            MovingBobStartDelay += Time.deltaTime;
            if (MovingBobStartDelay > 1)
            {
                MovingBobCurrentIndex = Move(Bob, MovingBobPath, MovingBobCurrentIndex);
            }
            MovingWendyCurrentIndex = Move(Wendy, MovingWendyPath, MovingWendyCurrentIndex);

            if (MovingBobCurrentIndex == MovingBobPath.Length && MovingWendyCurrentIndex == MovingWendyPath.Length)
            {
                this.StartEndDialog();
            }
        }
    }

    int Move(GameObject person, Vector3[] path, int currentIndex)
    {
        if (currentIndex == path.Length)
        {
            return currentIndex;
        }

        Vector3 current = person.transform.position;
        Vector3 goal = path[currentIndex];

        float dist = Vector3.Distance(current, goal);
        float thisFrameMovement = Time.deltaTime * 2f;

        if (thisFrameMovement >= dist)
        {
            person.transform.position = goal;
            currentIndex++;
        }
        else
        {
            person.transform.position = Vector3.Lerp(current, goal, thisFrameMovement / dist);
        }

        Vector3 moveDirection = person.transform.position - current;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            person.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        return currentIndex;
    }

    void StartStillDialog()
    {
        this.Phase = StartPhase.StillDialog;
        var stillDialog = new Dialog
        {
            DialogPieces = new DialogPiece[]
            {
                new DialogPiece { Person = "Wendy", Text = "Hello Bob, welcome to Heavenly Hills Residents Home." },
                new DialogPiece { Person = "Bob", Text = "*Grunts*" },
                new DialogPiece { Person = "Wendy", Text = "Anyway... Let me show you to your room." }
            },
            OnDone = () =>
            {
                this.StartMovement();
            }
        };

        this.DialogManager.StartDialog(stillDialog);
    }

    void StartEndDialog()
    {
        this.Phase = StartPhase.AtRoomDialog;
        var endDialog = new Dialog
        {
            DialogPieces = new DialogPiece[]
            {
                new DialogPiece { Person = "Wendy", Text = "Here's your room!" },
                new DialogPiece { Person = "Wendy", Text = "We have lots of exciting evening activities going on here, my favourite is bingo!!" },
                new DialogPiece { Person = "Bob", Text = "How very thrilling … *Grunts*" },
                new DialogPiece { Person = "Wendy", Text = "We used to play boggle, but the game mysteriously disappeared last month and was replaced with bingo." },
                new DialogPiece { Person = "Bob", Text = "Disappeared... how so ?" },
                new DialogPiece { Person = "Wendy", Text = "Well, Antti swears there is an alien living among us, and the alien stole it to send to his family for experimentation." },
                new DialogPiece { Person = "Bob", Text = "What sort of alien?" },
                new DialogPiece { Person = "Wendy", Text = "That’s just Antti being Antti, they probably need to up his meds again. But you can ask him if you want to find out more." }
            },
            OnDone = () =>
            {
                Phase = StartPhase.Done;
                GameManager.Instance.IsStartupPhaseActive = false;
            }
        };

        DialogManager.StartDialog(endDialog);
    }

    void StartMovement()
    {
        Phase = StartPhase.MovingDialog;
    }

    Vector3[] CreatePath(bool isBob)
    {
        return new Vector3[]
        {
            isBob ? Bob.transform.position : Wendy.transform.position,
            new Vector3(-4.26f, -7.93f, 0),
            new Vector3(-25.6f, -7.93f, 0),
            !isBob ? new Vector3(-27.31f, -3.35f, 0) : new Vector3(-24.88f, -3.35f, 0),
            !isBob ? new Vector3(-27.30f, -3.35f, 0) : new Vector3(-24.89f, -3.35f, 0)
        };
    }
}
