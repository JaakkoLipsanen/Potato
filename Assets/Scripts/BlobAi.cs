using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobAi : MonoBehaviour
{
    public GameObject Player {  get { return GameObject.Find("Bob"); } }
    public float SpeedOverride = 0;
    void Update()
    {
        if(this.GetComponent<Enemy>().IsDead)
        {
            return;
        }

        var speed = SpeedOverride == 0 ? Mathf.Lerp(0.8f, 2f, Mathf.Min(1, GameManager.Instance._timeSinceStart / 180f)) : SpeedOverride;
        var dist = Vector3.Distance(this.Player.transform.position, this.transform.position);

        this.transform.position = Vector3.Lerp(this.transform.position, this.Player.transform.position, speed * Time.deltaTime / dist);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0.1f);
    }
}
