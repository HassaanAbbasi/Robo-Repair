using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetMole : moleBase
{

    public void StartChase(GameObject target)
    {
        Debug.Log(walk);
        walk *= 3;
    }

    public void EndChase()
    {
        walk /= 3;
        Debug.Log(walk);
    }
}
