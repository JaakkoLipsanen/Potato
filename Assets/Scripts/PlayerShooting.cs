using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    const float TIME_BETWEEN_SHOOTS = 0.25f;
    public GameObject BulletPrefab;

    float timeSinceLastShoot = 0;
    public int Lives = 10;
    void Update()
    {
        if(!GameManager.Instance.CanPlayerMove)
        {
            return;
        }

        var isShootTriggered = Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0);
        timeSinceLastShoot += Time.deltaTime;

        if (timeSinceLastShoot > TIME_BETWEEN_SHOOTS && isShootTriggered)
        {
            StartCoroutine(Shoot());
            timeSinceLastShoot = 0;
        }
    }

    IEnumerator Shoot()
    {
        Instantiate(BulletPrefab, this.transform.position + this.transform.forward * 0.5f, this.transform.rotation);
        yield return new WaitForSeconds(0.05f);
        /*   Instantiate(BulletPrefab, this.transform.position + this.transform.forward * 0.5f, this.transform.rotation);
         */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("COLLISION");
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            if (enemy.IsDead)
            {
                return;
            }

            enemy.Die(false);
            Lives = Mathf.Max(0, Lives - 1);
            GameObject.Find("LivesRemainingText").GetComponent<UnityEngine.UI.Text>().text = "Lives remaining: " + Lives;

            if (Lives == 0)
            {
                GameObject.Find("GameOverText").active = true;
            }

        }
    }
}
