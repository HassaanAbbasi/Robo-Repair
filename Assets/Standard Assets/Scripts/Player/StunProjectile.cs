using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunProjectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Enemy")
        {
            // Send damage;
            other.attachedRigidbody.gameObject.SendMessage("Stun");
        }

        if (other.gameObject.tag!= "Player")
        {
            Destroy(gameObject);

        }
    }
}
