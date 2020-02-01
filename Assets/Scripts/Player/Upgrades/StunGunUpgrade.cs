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

    public void Start()
    {
        StartCoroutine(Reload());
    }
    public override void UseUpgrade(int direction)
    {
        if(Input.GetKeyDown(KeyCode.Z) && numOfShots > 0)
        {
            ShootGun(direction);
        }
    }


    void ShootGun(int direction)
    {
        GameObject obj = Instantiate<GameObject>(projectile, socket.position, socket.rotation);
        Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
        Destroy(obj, 30);
        body.velocity = transform.right * direction * speed;
        numOfShots--;

    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        numOfShots++;
        if(numOfShots > 2)
        {
            numOfShots = 2;
        }

        StartCoroutine(Reload());


    }
}
