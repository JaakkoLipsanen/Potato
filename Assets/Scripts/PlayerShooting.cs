using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    const float TIME_BETWEEN_SHOOTS = 0.25f;
    public GameObject BulletPrefab;

    float timeSinceLastShoot = 0;
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
}
