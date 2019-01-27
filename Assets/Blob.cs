using UnityEngine;

public class Blob : MonoBehaviour
{
    public Sprite[] BlobTextures;

    public SpriteRenderer Sprite
    {
        get { return this.GetComponent<SpriteRenderer>(); }
    }

    private void Start()
    {
        this.Sprite.sprite = BlobTextures[(int)Random.Range(0, BlobTextures.Length)];
        this.transform.localScale = Vector3.one * Random.Range(0.7f, 1.3f);
    }
}
