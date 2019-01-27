using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool CanPlayerMove { get { return !IsDialogActive && !IsStartupPhaseActive; } }
    public bool CanPlayerConversate {  get { return !this.IsActualGameStarted; } }

    public bool IsStartupPhaseActive { get; set; }
    public bool IsDialogActive
    {
        get
        {
            return GameObject.Find("Dialog UI").GetComponent<DialogManager>().ActiveDialog != null;
        }
    }

    public GameObject AnttiAlienPrefab;
    public bool IsActualGameStarted = false;


    public GameObject BlobPrefab;
    public Vector3[] BlobSpawnPositions =
    {
        new Vector3(-6.5f, 10.9f, 0),
        new Vector3(-39.29f, -15.15f, 0),
        new Vector3(8.37f, -14.12f, 0),
        new Vector3(-2.8f, -35.1f, 0)
    };

    public float _timeSinceStart = 0f;
    private float _timeSinceLastSpawn = 0f;

    public GameManager()
    {
        Instance = this;
    }

    private void Update()
    {
        if(!this.IsActualGameStarted)
        {
            return;
        }

        _timeSinceStart += Time.deltaTime;
        _timeSinceLastSpawn += Time.deltaTime;

        var currentRateOfSpawn = Mathf.Lerp(3f, 0.6f, Mathf.Min(1, _timeSinceStart / 2400f));
        if (_timeSinceLastSpawn > currentRateOfSpawn)
        {
            _timeSinceLastSpawn = 0;
            SpawnBlob();
        }

    }

    void SpawnBlob()
    {
        Instantiate(BlobPrefab, BlobSpawnPositions[(int)Random.Range(0, BlobSpawnPositions.Length)], Quaternion.identity);
    }

    public void StartActualGame()
    {
        var antti = GameObject.Find("Antti");
        Instantiate(AnttiAlienPrefab, antti.transform.position, Quaternion.identity);
        Destroy(antti);

        DialogManager.Instance.StartDialog(new Dialog
        {
            DialogPieces = new DialogPiece[]
            {
                new DialogPiece { Person = "Antti Alien", Text = "I told you that you should leave!" },
                new DialogPiece { Person = "Antti Alien", Text = "You will die now human scum!" }
            },
            OnDone = () => { 
                GameObject.Find("LivesRemainingText").SetActive(true); 
                this.IsActualGameStarted = true;
                GameObject.Find("LivesRemainingText").GetComponent<UnityEngine.UI.Text>().text = "Lives remaining: 10";
                GameObject.Find("KillsText").GetComponent<UnityEngine.UI.Text>().text = "Kills: 0";
                foreach(var go in GameObject.FindGameObjectsWithTag("prop"))
                {
                    go.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                }
            }
        });
    }
}
