using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalFistUpgrade : PlayerUpgrade
{
    [SerializeField]
    protected float cooldown = 5.0f;
    [SerializeField]
    protected bool canPunch = true;
    [SerializeField]
    protected float wait = 0.1f;

    protected bool canDestroy = false;
    
    [SerializeField]
    protected SpriteRenderer sprender;
    //when player interacts with enemy type" breakable wall" && player pressing use metal fist button, destroy(wall)

    // Start is called before the first frame update
    void Awake()
    { 
        sprender.enabled = false;
    }

    void Start()
    {

        sprender.enabled = false;
    }
    public override void UseUpgrade(int direction)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Punchu");
            canPunch = false;
            CheckWallBreak(direction);
        }
    }

    void CheckWallBreak(int direction)
    {
        if(sprender)
            sprender.enabled = true;
        StartCoroutine(Punch(direction));
        //StartCoroutine(CooldownTimer());
    }

    public IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(cooldown);
        canPunch = true;
    }

    public IEnumerator Punch(int direction)
    {
        if (direction > 0)
        {
            Vector3 pos = transform.position;
            yield return new WaitForSeconds(wait);
            transform.position = new Vector3(transform.position.x - 0.1f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(wait);
            transform.position = new Vector3(transform.position.x + 0.3f, transform.position.y, transform.position.z);
            canDestroy = true;
            yield return new WaitForSeconds(wait);
            transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y, transform.position.z);
            canDestroy = false;
            sprender.enabled = false;
            StartCoroutine(CooldownTimer());
        }
        else if(direction < 0)
        {
            Vector3 pos = transform.position;
            yield return new WaitForSeconds(wait);
            transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(wait);
            transform.position = new Vector3(transform.position.x -0.3f, transform.position.y, transform.position.z);
            canDestroy = true;
            yield return new WaitForSeconds(wait);
            transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            canDestroy = false;
            sprender.enabled = false;
            StartCoroutine(CooldownTimer());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall" && canDestroy)
        {
            Destroy(collision.gameObject);
        }
    }
}
