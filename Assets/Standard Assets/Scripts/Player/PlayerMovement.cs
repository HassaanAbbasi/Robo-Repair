using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerData
{
    protected Rigidbody2D rigidbody;
    protected GroundCheck groundCheck;

    [SerializeField]
    protected PlayerUpgrade stunGun;
    [SerializeField]
    protected PlayerUpgrade jetPack;
    [SerializeField]
    protected PlayerUpgrade gauntlet;
    
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
        if (b_isDamageable && !GameController.b_isPaused)
        {

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

    void OnTriggerEnter2D(Collider2D col)
    {
        string otherTag = col.gameObject.tag;
        if (otherTag == "Environment")
        {
            this.gameObject.SendMessageUpwards("DamagePlayer");
        }
        if(otherTag == "PickUp")
        {
            AddPowerUp(col.gameObject.GetComponentInChildren<PickUp>().upgrade);
            Destroy(col.gameObject);
        }
    }
    public bool GetIsGrounded()
    {
        if(groundCheck)
            return groundCheck.b_isGrounded;

        return false;
    }

    public void AddPowerUp(int upgrade)
    {
        switch(upgrade)
        {
            case 1:
                upgrades.Add(jetPack);
                jetPack.gameObject.SetActive(true);
                break;
            case 2:
                upgrades.Add(stunGun);
                stunGun.gameObject.SetActive(true);
                break;
            case 3:
                upgrades.Add(gauntlet);
                gauntlet.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
    
}
