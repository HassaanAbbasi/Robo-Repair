using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackUpgrade : PlayerUpgrade
{
    [SerializeField]
    protected float fuel = 3.0f;
    [SerializeField]
    protected float forcePower = 100.0f;

    GameObject player;
    PlayerMovement playerMove = new PlayerMovement();
    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.Find("PFB_Player");
        rb = player.GetComponentInChildren<Rigidbody2D>();
    }

    public override void UseUpgrade(int direction)
    {
        if (Input.GetKey(KeyCode.Space))
            ApplyForce();

        if(playerMove.GetIsGrounded())
        {
            if(fuel < 5.0f)
            {
                fuel = 5.0f;
            }
        }
    }

    void ApplyForce()
    {
        if(fuel > 0)
        {
            rb.AddForce(Vector2.up * forcePower);
            fuel -= Time.deltaTime;
        }
        else
        {

        }
    }
 }
