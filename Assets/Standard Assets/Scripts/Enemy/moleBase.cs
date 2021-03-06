﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleBase : Damageable
{
    protected Rigidbody2D rigidbody;
    protected float walk = 2;
    [SerializeField]
    protected bool b_isStunned = false;
    [SerializeField]
    protected AudioClip deathSound;
    // Start is called before the first frame update
    protected new void Start()
    {

        walk *= transform.localScale.x;
        base.Start();
        rigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(!b_isStunned)
            rigidbody.velocity = new Vector3(walk, rigidbody.velocity.y, 0);
        else
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(b_isStunned)
        {

        }
        else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy")
        {
            walk = walk * -1;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, 1, 1);

        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("DamagePlayer");

            float enemyX = rigidbody.transform.position.x;
            float playerX = collision.rigidbody.transform.position.x;
            float direction = (playerX - enemyX) / Mathf.Abs(playerX - enemyX);

            collision.rigidbody.AddForce(new Vector2(direction * 10, 10), ForceMode2D.Impulse);

        }
        
    }

    public void TakeDamage()
    {
        GameController.PlaySound(deathSound);
        Destroy(gameObject);
    }

    public void Stun()
    {
        StartCoroutine(StunDuration());
    }

    private IEnumerator StunDuration()
    {
        float stunDuration = 2.0f;
        b_isStunned = true;
        yield return new WaitForSeconds(stunDuration);
        b_isStunned = false;

    }
}