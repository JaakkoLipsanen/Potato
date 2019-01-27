using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static int kills = 0;
    private int _hits;
    public int HowManyBulletsToDie = 2;
    public bool IsDead = false;

    public SpriteRenderer Sprite {  get { return this.GetComponent<SpriteRenderer>(); } }
    private float _deadTime = 0;

    private void Update()
    {
        if(this.IsDead)
        {
            _deadTime += Time.deltaTime * 1.4f;
            float colorLerpTime =  _deadTime;
            float scaleLerpTime = _deadTime < 1 ? 0 : _deadTime - 1;

            this.Sprite.color = Color.Lerp(Color.white, new Color(1, 1, 1, 0.6f), _deadTime);
            this.transform.localScale = Vector3.one * Mathf.SmoothStep(1, 0, scaleLerpTime);

            if (_deadTime >= 2)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void TakeHit()
    {
        _hits++;
        if (_hits >= HowManyBulletsToDie)
        {
            Die();
        }
    }

    public void Die(bool killedBySelf = true)
    {
        this.IsDead = true;
        if (killedBySelf)
        {
            GameObject.Find("KillsText").GetComponent<UnityEngine.UI.Text>().text = "Kills: " + ++kills;
        }
        Destroy(this.GetComponent<Rigidbody2D>());
        Destroy(this.GetComponent<BoxCollider2D>());
    }
}
