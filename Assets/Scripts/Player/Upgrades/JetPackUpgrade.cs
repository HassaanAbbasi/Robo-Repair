using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackUpgrade : PlayerUpgrade
{
    [SerializeField]
    protected float fuel = 2.0f;
    [SerializeField]
    protected float m_maxFuel = 2.0f;
    [SerializeField]
    protected int maxJumps = 2;
    [SerializeField]
    protected float forcePower = 100.0f;

    protected bool canJump = true;
    protected int jumpCount = 0;

    GameObject player;
    PlayerMovement playerMove;
    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.Find("PFB_Player");
        rb = player.GetComponentInChildren<Rigidbody2D>();
        playerMove = player.GetComponentInChildren<PlayerMovement>();
    }

    public override void UseUpgrade(int direction)
    {

        if (Input.GetKeyDown(KeyCode.Space) && !playerMove.GetIsGrounded() && canJump)
        {
            ApplyForce();
            jumpCount++;
            if (jumpCount == maxJumps)
            {
                canJump = false;
            } 
        }

        if(playerMove.GetIsGrounded())
        {
            if(fuel < m_maxFuel)
            {
                fuel = m_maxFuel;
            }
            if(jumpCount > 0)
            {
                jumpCount = 0;
            }
            canJump = true;
        }
    }


    //TO DO
    // FIX AMOUNTS OF JUMPS
    // ADD SLOW FALL
    // ADD PARTICLE EFFECTS
    void ApplyForce()
    {
        if(fuel > 0)
        {
            rb.AddForce(Vector2.up * forcePower, ForceMode2D.Impulse);

            rb.velocity = new Vector3(rb.velocity.x, Mathf.Min(rb.velocity.y, playerMove.maxJump), 0);
            fuel -= Time.deltaTime;
        }
        else
        {

        }
    }
 }
