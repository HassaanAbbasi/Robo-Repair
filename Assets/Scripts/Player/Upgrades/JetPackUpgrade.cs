using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPackUpgrade : PlayerUpgrade
{
    [SerializeField]
    protected float fuel = 2.0f;
    [SerializeField]
    protected float fuelJumpCost = 0.5f;
    [SerializeField]
    protected float fuelDepletionRate = 1.0f;
    [SerializeField]
    protected float m_maxFuel = 2.0f;
    [SerializeField]
    protected int maxJumps = 2;
    [SerializeField]
    protected float forcePower = 100.0f;

    protected bool canJump = true;
    [SerializeField]
    protected int jumpCount = 2;

    [SerializeField]
    private ParticleSystem particleSystem;

    GameObject player;
    PlayerMovement playerMove;
    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.Find("PFB_Player");
        rb = player.GetComponentInChildren<Rigidbody2D>();
        playerMove = player.GetComponentInChildren<PlayerMovement>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
}

    public override void UseUpgrade(int direction)
    {


        if (playerMove.GetIsGrounded())
        {
            particleSystem.Stop();
            if (fuel < m_maxFuel)
            {
                fuel = m_maxFuel;
            }
            if(jumpCount  <= 0)
            {
                jumpCount = maxJumps;
            }
            canJump = true;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && canJump && fuel > 0)
        {
            particleSystem.Play();
            ApplyForce();
            jumpCount--;
            if (jumpCount <= 0)
            {
                canJump = false;
            }
        }
        else if (Input.GetKey(KeyCode.Space) && fuel > 0)
        {
            particleSystem.Play();
            SlowFall();
        }
        else
        {
            particleSystem.Stop();
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
            fuel -= fuelJumpCost;
        }
    }
    
    void SlowFall()
    {
        if(rb.velocity.y < 0)
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y/ 2, 0);
        fuel -= Time.deltaTime * fuelDepletionRate;

    }
 }
