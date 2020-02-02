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

    bool canDestroy = false;
    GameObject fist;
    SpriteRenderer sprender;
    //when player interacts with enemy type" breakable wall" && player pressing use metal fist button, destroy(wall)

    // Start is called before the first frame update
    void Start()
    {
        fist = GameObject.Find("MetalGauntlet");
        sprender = fist.GetComponent<SpriteRenderer>();
        sprender.enabled = false;
    }

    public override void UseUpgrade(int direction)
    {
        if (Input.GetKeyDown(KeyCode.Q) && canPunch)
        {
            canPunch = false;
            CheckWallBreak(direction);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckWallBreak(int direction)
    {
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
            Vector3 pos = fist.transform.position;
            yield return new WaitForSeconds(wait);
            fist.transform.position = new Vector3(fist.transform.position.x - 0.1f, fist.transform.position.y, fist.transform.position.z);
            yield return new WaitForSeconds(wait);
            fist.transform.position = new Vector3(fist.transform.position.x + 0.3f, fist.transform.position.y, fist.transform.position.z);
            canDestroy = true;
            yield return new WaitForSeconds(wait);
            fist.transform.position = new Vector3(fist.transform.position.x - 0.2f, fist.transform.position.y, fist.transform.position.z);
            canDestroy = false;
            sprender.enabled = false;
            StartCoroutine(CooldownTimer());
        }
        else if(direction < 0)
        {
            Vector3 pos = fist.transform.position;
            yield return new WaitForSeconds(wait);
            fist.transform.position = new Vector3(fist.transform.position.x + 0.1f, fist.transform.position.y, fist.transform.position.z);
            yield return new WaitForSeconds(wait);
            fist.transform.position = new Vector3(fist.transform.position.x -0.3f, fist.transform.position.y, fist.transform.position.z);
            canDestroy = true;
            yield return new WaitForSeconds(wait);
            fist.transform.position = new Vector3(fist.transform.position.x + 0.2f, fist.transform.position.y, fist.transform.position.z);
            canDestroy = false;
            sprender.enabled = false;
            StartCoroutine(CooldownTimer());
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BreakableWall" && canDestroy)
        {
            Destroy(collision.gameObject);
        }
    }
}
