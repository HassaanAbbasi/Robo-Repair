using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : Damageable
{
    public float maxJump = 10;
    public float jumpForce = 100;

    public float moveSpeed = 10;

    [SerializeField]
    protected List<PlayerUpgrade> upgrades;

    protected void Start()
    {
        base.Start();
    }

    public void DamagePlayer()
    {
        if (!b_isDamageable)
            return;

        health--;
        StartCoroutine(Flash());
        if (health <= 0)
        {
            health = 0;
            SceneManager.LoadScene("DeathZone");
        }
    }

    
}
