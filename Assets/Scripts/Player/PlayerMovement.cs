using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerData
{
    protected Rigidbody2D rigidbody;
    protected GroundCheck groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        rigidbody = GetComponentInChildren<Rigidbody2D>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (b_isDamageable)
        {
            if (Input.GetKeyDown(KeyCode.G))
                DamagePlayer();

            HandleMovement(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

            foreach (PlayerUpgrade upgrade in upgrades)
            {
                upgrade.UseUpgrade((int)transform.localScale.x);
            }
        }

    }
    

    void HandleMovement(Vector2 direction)
    {

        rigidbody.velocity = new Vector3(direction.x * moveSpeed, rigidbody.velocity.y, 0);

        if(direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if((Input.GetKeyDown(KeyCode.Space)) && groundCheck.b_isGrounded )
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            rigidbody.velocity = new Vector3(rigidbody.velocity.x, Mathf.Min(rigidbody.velocity.y, maxJump), 0);
        }

    }

   public bool GetIsGrounded()
    {
        if(groundCheck)
            return groundCheck.b_isGrounded;

        return false;
    }
}
