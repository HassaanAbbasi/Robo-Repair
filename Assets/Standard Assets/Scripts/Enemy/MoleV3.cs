using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleV3 : MonoBehaviour
{
    [SerializeField]
    private Transform socket;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private int numOfShots = 1;
    [SerializeField]
    private float reloadTime = 3.0f;
    [SerializeField]
    private float speed = 10f;

   /* protected GroundCheck groundCheck; */

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reload());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ThrowPickaxe()
    {
        GameObject playerPosition = GameObject.FindGameObjectWithTag("Player");
        GameObject obj = Instantiate<GameObject>(projectile, socket.position, socket.rotation);
        Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
        Destroy(obj, 5);


        Vector3 pickaxeDirection = playerPosition.transform.position - transform.position + new Vector3(0, 4, 0);
        pickaxeDirection = Vector3.Normalize(pickaxeDirection);
        body.AddForce(pickaxeDirection * speed, ForceMode2D.Impulse);

        numOfShots--;
     
        /*if (body.groundCheck.b_isGrounded)
        {
            Destroy(body);
        }*/

    }

    /*
    public bool GetIsGrounded()
    {
        if (groundCheck)
            return groundCheck.b_isGrounded;

        return false;
    }*/

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        numOfShots++;
        if (numOfShots > 1)
        {
            numOfShots = 1;
        }
        ThrowPickaxe();
        StartCoroutine(Reload());
    }
}
