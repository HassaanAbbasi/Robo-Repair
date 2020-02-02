using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour
{
    [SerializeField]
    private HelmetMole moleScript;

    public void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "Player")
        {
            moleScript.StartChase(other.gameObject);
        }
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            moleScript.EndChase();
        }
    }
}
