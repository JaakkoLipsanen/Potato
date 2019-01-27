using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _hits;
    public int HowManyBulletsToDie = 2;
    public bool IsDead = false;

    public SpriteRenderer Sprite {  get { return this.GetComponent<SpriteRenderer>(); } }
    private float _deadTime = 0;

    private void Update()
    {
        if(this.IsDead)
        {
            _deadTime += Time.deltaTime * 0.6f;
            float colorLerpTime =  _deadTime;
            float scaleLerpTime = _deadTime < 1 ? 0 : _deadTime - 1;

            this.Sprite.color = Color.Lerp(Color.white, new Color(0.7f, 0.5f, 0.3f, 0.6f), _deadTime);
            this.transform.localScale = Vector3.one * Mathf.SmoothStep(1, 0, scaleLerpTime * 0.5f);

            if (_deadTime >= 3)
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

    void Die()
    {
        this.IsDead = true;
    }
}
