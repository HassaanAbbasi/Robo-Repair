using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    protected SpriteRenderer sprite;
    // Start is called before the first frame update
    protected void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected IEnumerator Flash()
    {
        if(sprite == null)
        {
            yield return null;
        }
        float flashSeconds = 0.1f;
        sprite.color = Color.red;
        yield return new WaitForSeconds(flashSeconds);
        sprite.color = Color.white;
        yield return new WaitForSeconds(flashSeconds);
        sprite.color = Color.red;
        yield return new WaitForSeconds(flashSeconds);
        sprite.color = Color.white;
    }
}
