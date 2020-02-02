using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideAndDie : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D otherObj)
    {
        string otherTag = otherObj.gameObject.tag;
        if (otherTag == "Player")
        {
            otherObj.gameObject.SendMessageUpwards("DamagePlayer");
            Destroy(this.gameObject);
        }
        else if(otherTag == "Ground" || otherTag == "Wall")
        {
            Destroy(this.gameObject);
        }
        
    }

}
