using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillMole : moleBase
{
    [SerializeField]
    protected int hopFlag = 1;
    [SerializeField]
    protected int chargeFlag = 0;
    protected SpriteRenderer sprite;
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected Vector3 startPosition;
    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        rigidbody = GetComponentInChildren<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    override protected void Update()
    {
        if (hopFlag != 0)
        {
            hop();
            rigidbody.velocity = new Vector3(0, 5 * hopFlag, 0);
            if (rigidbody.transform.position.x - player.transform.position.x < 8)
                chargeFlag = 1;
        }
        else if (startPosition.x - rigidbody.transform.position.x >= 6)
        {
            returnToPosition();
        }

    }

    void hop()
    {
        if (rigidbody.transform.position.y >= -0.36)
        {
            hopFlag = -1;
        }
        else if (rigidbody.transform.position.y <= -0.65)
        {
            hopFlag = 1;
            if (chargeFlag == 1)
            {
                hopFlag = 0;
                rigidbody.velocity = new Vector3(0, rigidbody.transform.position.y, 0);
                print("meh");
                StartCoroutine(charge());
            }
        }
        

    }

    private IEnumerator charge()
    {
        print("bleh");
        rigidbody.transform.localScale = new Vector3(rigidbody.transform.localScale.x * -1, 1, 1);
        yield return new WaitForSeconds(2);
        rigidbody.velocity = new Vector3(-5, 0, 0);
    }

    void returnToPosition()
    {
        //rigidbody.velocity = new Vector3(1, 0, 0);
        rigidbody.velocity = Vector3.Lerp(rigidbody.transform.position, startPosition, 0);
        hopFlag = 1;
    }
}
