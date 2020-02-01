using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGunUpgrade : PlayerUpgrade
{
    [SerializeField]
    private Transform socket;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private int numOfShots = 2;
    [SerializeField]
    private float reloadTime = 30.0f;
    [SerializeField]
    private float speed = 10f;
    public override void UseUpgrade(int direction)
    {
        if(Input.GetKeyDown(KeyCode.Z))
            ShootGun(direction);
    }


    void ShootGun(int direction)
    {
        GameObject obj = Instantiate<GameObject>(projectile, socket.position, socket.rotation);
        Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
        body.velocity = transform.right * direction * speed;

    }
}
