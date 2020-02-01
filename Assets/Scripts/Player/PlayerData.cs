using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private float m_maxHeatlh = 100;
    public float health = 100;

    public float maxJump = 10;
    public float jumpForce = 100;

    public float moveSpeed = 10;

    [SerializeField]
    protected List<PlayerUpgrade> upgrades;

    
}
