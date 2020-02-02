using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool b_isGrounded = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            b_isGrounded = true;
        }
        else if(other.gameObject.tag == "Enemy")
        {
            float dist = transform.position.y - other.gameObject.transform.position.y;
            if (dist >= 0.3f)
            {
                other.attachedRigidbody.gameObject.SendMessage("TakeDamage");
            }

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            b_isGrounded = false;
        }
    }
}
