using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 25f;
    private float _timeSinceSpawn = 0;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += this.transform.up * Speed * Time.deltaTime;
        _timeSinceSpawn += Time.deltaTime;
        if (_timeSinceSpawn > 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var x = collision.gameObject.GetComponent<Enemy>(); 
        if(x != null)
        {
            x.TakeHit();
        }


        Destroy(this.gameObject);
    }
}
