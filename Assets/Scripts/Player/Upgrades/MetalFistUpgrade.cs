using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalFistUpgrade : PlayerUpgrade
{
    [SerializeField]
    protected float cooldown = 5.0f;
    [SerializeField]
    protected bool canPunch = true;

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
        if (Input.GetKeyDown(KeyCode.F) && canPunch)
        {
            CheckWallBreak(direction);
            canPunch = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckWallBreak(int direction)
    {
        sprender.enabled = true;

        //StartCoroutine(CooldownTimer());
    }

    public IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(cooldown);
        canPunch = true;
    }
}
