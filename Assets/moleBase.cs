using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleBase : Damageable
{
    protected Rigidbody2D rigidbody;
    protected int walk = -2;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        rigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector3(walk, rigidbody.velocity.y, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            walk = walk * -1;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, 1, 1);
            StartCoroutine(Flash());
        }
        else if (collision.gameObject.tag == "player")
        {
            collision.gameObject.SendMessage("DamagePlayer");
            collision.gameObject.GetComponentInChildren<Rigidbody2D>;
            if ()

        }
    }
}