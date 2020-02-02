using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillMole : moleBase
{

    public enum DrillState
    {
        DS_HOP = 0,
        DS_CHARGE,
        DS_RETURN,
        DS_COUNT
    }
    
    [SerializeField]
    protected DrillState currentState = DrillState.DS_HOP;
    [SerializeField]
    protected AudioSource alertSound;
    protected SpriteRenderer exSprite;
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected Vector3 startPosition;
    [SerializeField]
    protected int hopDirection = 1;

    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
        rigidbody = GetComponentInChildren<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = gameObject.transform.position;
        alertSound = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    override protected void Update()
    {

        switch (currentState)
        {
            case DrillState.DS_HOP:
                hop();
                rigidbody.velocity = new Vector3(0, 5 * hopDirection, 0);
                if (rigidbody.transform.position.x - player.transform.position.x < 10)
                {
                    currentState++;
                    alertSound.Play();
                }
                break;

            case DrillState.DS_CHARGE:

                StartCoroutine(charge());

                break;
            case DrillState.DS_RETURN:

                 returnToPosition();
                break;
            default:
                Debug.Log("MEH");
                break;
        }

    }

    void hop()
    {
        if (rigidbody.transform.position.y >= -0.04)
        {
            hopDirection = -1;
        }
        else if (rigidbody.transform.position.y <= -0.42)
        {
            hopDirection = 1;
            if (currentState == DrillState.DS_CHARGE)
            {
                hopDirection = 0;
                rigidbody.velocity = new Vector3(0, rigidbody.transform.position.y, 0);
            }
        }
        

    }

    private IEnumerator charge()
    {
        
        currentState = DrillState.DS_COUNT;
        rigidbody.transform.localScale = new Vector3(rigidbody.transform.localScale.x * -1, 1, 1);
        GameObject.FindWithTag("Exclamation").GetComponentInChildren<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(1);
        GameObject.FindWithTag("Exclamation").GetComponentInChildren<SpriteRenderer>().enabled = false;
        rigidbody.velocity = new Vector3(-30, 0, 0);

        yield return new WaitForSeconds(0.4f);
        rigidbody.transform.localScale = new Vector3(rigidbody.transform.localScale.x * -1, 1, 1);
        currentState = DrillState.DS_RETURN;
    }

    void returnToPosition()
    {

        rigidbody.velocity = new Vector3(Vector3.Normalize((startPosition - transform.position)).x * 3 , 0, 0);


        if (transform.position.x >= startPosition.x - 0.1f && transform.position.x <= startPosition.x + 0.1f)
        {
            hopDirection = 1;
            rigidbody.velocity = new Vector3(0, 0, 0);
            currentState = 0;
        }
    }
}
