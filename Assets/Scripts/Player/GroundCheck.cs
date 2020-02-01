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
            // Send damage;
            other.SendMessage("TakeDamage");
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
