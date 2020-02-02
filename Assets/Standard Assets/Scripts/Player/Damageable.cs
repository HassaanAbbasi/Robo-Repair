using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    protected SpriteRenderer sprite;

    [SerializeField]
    private int m_maxHeatlh = 3;
    public int health = 3;

    [SerializeField]
    protected bool b_isDamageable = true;

    // Start is called before the first frame update
    protected void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    protected IEnumerator Flash()
    {
        b_isDamageable = false;
        if(sprite == null)
        {
            yield return null;
        }
        else
        {
            float flashSeconds = 0.1f;
            sprite.color = Color.red;
            yield return new WaitForSeconds(flashSeconds);
            sprite.color = Color.white;
            yield return new WaitForSeconds(flashSeconds);
            sprite.color = Color.red;
            yield return new WaitForSeconds(flashSeconds);
            sprite.color = Color.white;
        }
        b_isDamageable = true;
    }
}
